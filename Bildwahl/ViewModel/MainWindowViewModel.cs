using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Data;
using Bildwahl.DataAccess;
using Bildwahl.Model;
using Bildwahl.Properties;

namespace Bildwahl.ViewModel
{
    /// <summary>
    /// The ViewModel for the application's main window.
    /// </summary>
    public class MainWindowViewModel : WorkspaceViewModel
    {
        #region Fields

        ObservableCollection<CommandViewModel> _commands;
        readonly ScenarioRepository _imageLinksRepository;
        ObservableCollection<WorkspaceViewModel> _workspaces;

        #endregion // Fields

        #region Constructor

        public MainWindowViewModel(string scenarioDataFile)
        {
            base.DisplayName = Strings.MainWindowViewModel_DisplayName;
            _imageLinksRepository = new ScenarioRepository(scenarioDataFile);
            _imageLinksRepository.ScenarioAdded += this.OnScenarioAddedToRepository;
            _imageLinksRepository.ScenarioDeleted += this.OnScenarioDeletedFromRepository;
        }

        #endregion // Constructor

        #region Commands

        /// <summary>
        /// Returns a read-only list of commands 
        /// that the UI can display and execute.
        /// </summary>
        public ObservableCollection<CommandViewModel> Commands
        {
            get
            {
                if (_commands == null)
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _commands = new ObservableCollection<CommandViewModel>(cmds);
                }
                return _commands;
            }
        }

        List<CommandViewModel> CreateCommands()
        {
            int i = 0;
            List<Scenario> all =
                 _imageLinksRepository.GetScenarios();
            List<CommandViewModel> list = new List<CommandViewModel> { };
            
            for (i = 0; i <= all.Count - 1; i++)
            {
                string titel = all.ElementAt(i).Titel;
                list.Add( new CommandViewModel(
                    all.ElementAt(i).Titel,
                     new RelayCommand(param => this.ShowScenario(titel))));

            }

            list.Add(new CommandViewModel(
                    Strings.MainWindowViewModel_Command_CreateNewScenario,
                    new RelayCommand(param => this.CreateNewScenario())));
            list.Add(new CommandViewModel(
                    Strings.MainWindowViewModel_Command_DeleteScenario,
                    new RelayCommand(param => this.LoadScenario())));
            return list;
        }

       

        #endregion // Commands

        #region Workspaces

        /// <summary>
        /// Returns the collection of available workspaces to display.
        /// A 'workspace' is a ViewModel that can request to be closed.
        /// </summary>
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_workspaces == null)
                {
                    _workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _workspaces;
            }
        }

        void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }

        void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            workspace.Dispose();
            this.Workspaces.Remove(workspace);
        }

        #endregion // Workspaces

        #region Private Helpers

        void CreateNewScenario()
        {
            Scenario newScenario = Scenario.CreateNewScenario();
            NewScenarioViewModel workspace = new NewScenarioViewModel(newScenario, _imageLinksRepository);
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        void ShowScenario(string scenario)
        {
            TobiiViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is TobiiViewModel)
                as TobiiViewModel;

                workspace = new TobiiViewModel(_imageLinksRepository, scenario);
                this.Workspaces.Add(workspace);

            this.SetActiveWorkspace(workspace);
        }

        void LoadScenario()
        {

            DeleteScenarioViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is DeleteScenarioViewModel)
                as DeleteScenarioViewModel;

            if (workspace == null)
            {
                workspace = new DeleteScenarioViewModel(_imageLinksRepository);
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }

        void OnScenarioAddedToRepository(object sender, ScenarioAddedEventArgs e)
        {
            List<Scenario> all =
                 _imageLinksRepository.GetScenarios();
            this.Commands.Add(new CommandViewModel(
                    all.ElementAt(all.Count()-1).Titel,
                     new RelayCommand(param => this.ShowScenario(all.ElementAt(all.Count() - 1).Titel))));
        }

        void OnScenarioDeletedFromRepository(object sender, ScenarioDeletedEventArgs e)
        {
            this.Commands.Remove((Commands.SingleOrDefault(i => i.DisplayName == e.ToRemoveScenario.Titel)));
        }

        #endregion // Private Helpers
    }
}
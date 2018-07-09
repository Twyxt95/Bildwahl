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

        public MainWindowViewModel(string customerDataFile)
        {
            base.DisplayName = Strings.MainWindowViewModel_DisplayName;
            _imageLinksRepository = new ScenarioRepository(customerDataFile);
            _imageLinksRepository.ScenarioAdded += this.OnCustomerAddedToRepository;
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
                 _imageLinksRepository.GetCustomers();
            List<CommandViewModel> list = new List<CommandViewModel> { };
            
            for (i = 0; i <= all.Count - 1; i++)
            {
                string titel = all.ElementAt(i).Titel;
                list.Add( new CommandViewModel(
                    all.ElementAt(i).Titel,
                     new RelayCommand(param => this.ShowScenario(titel))));

            }

            list.Add(new CommandViewModel(
                    Strings.MainWindowViewModel_Command_CreateNewCustomer,
                    new RelayCommand(param => this.CreateNewScenario())));
            list.Add(new CommandViewModel(
                    Strings.MainWindowViewModel_Command_LoadScenario,
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
            Scenario newCustomer = Scenario.CreateNewCustomer();
            NewScenarioViewModel workspace = new NewScenarioViewModel(newCustomer, _imageLinksRepository);
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
            
        }

        void ShowScenario(string scenario)
        {
            Console.WriteLine(scenario + " ShowScenario");
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
                workspace = new DeleteScenarioViewModel();
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

        void OnCustomerAddedToRepository(object sender, ScenarioAddedEventArgs e)
        {
            //var viewModel = new NewScenarioViewModel(e.NewCustomer, _imageLinksRepository);
            List<Scenario> all =
                 _imageLinksRepository.GetCustomers();
            this.Commands.Add(new CommandViewModel(
                    all.ElementAt(all.Count()-1).Titel,
                     new RelayCommand(param => this.ShowScenario(all.ElementAt(all.Count() - 1).Titel))));
        }

        #endregion // Private Helpers
    }
}
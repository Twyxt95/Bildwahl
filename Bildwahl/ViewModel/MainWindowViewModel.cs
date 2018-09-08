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
    /// <summary> Das ViewModel für das MainWindow mit dem Navigationsmenü </summary>
    public class MainWindowViewModel : WorkspaceViewModel
    {
        /// <summary> Alle Commands für das Navigationsmenü </summary>
        ObservableCollection<CommandViewModel> _commands;

        /// <summary> Verzeichnis für alle Szenarien </summary>
        readonly ScenarioRepository _scenarioRepository;

        /// <summary> Alle ViewModels </summary>
        ObservableCollection<WorkspaceViewModel> _workspaces;

        /// <summary> Konstruktor </summary>
        /// /// <param name="scenarioDataFile"> Speicherort der Datei in der alle Szenarien gespeichert sind </param>
        public MainWindowViewModel(string scenarioDataFile)
        {
            base.DisplayName = Strings.MainWindowViewModel_DisplayName;
            _scenarioRepository = new ScenarioRepository(scenarioDataFile);
            _scenarioRepository.ScenarioAdded += this.OnScenarioAddedToRepository;
            _scenarioRepository.ScenarioDeleted += this.OnScenarioDeletedFromRepository;
        }

        /// <summary> Gibt eine Liste von Commands zurück, die das UI anzeigen und ausführen kann </summary>
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

        /// <summary> Erstellt das Navigationsmenü </summary>
        List<CommandViewModel> CreateCommands()
        {
            int i = 0;
            List<Scenario> all =
                 _scenarioRepository.GetScenarios();
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
                    new RelayCommand(param => this.DeleteScenario())));
            return list;
        }

        /// <summary> Gibt die Collection der Workspaces zurück, die angezeigt werden können </summary>
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

        /// <summary> Eventhandler wenn der Workspace gewechselt wird </summary>
        /// <param name="sender"> Objekt von dem das Event ausgeht</param>
        /// <param name="e"> Ausgelöstes Event </param>
        void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }

        /// <summary> Eventhandler wenn der Workspace geschlossen wird </summary>
        /// <param name="sender"> Objekt von dem das Event ausgeht</param>
        /// <param name="e"> Ausgelöstes Event </param>
        void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            workspace.Dispose();
            this.Workspaces.Remove(workspace);
        }

        /// <summary> Für die Anzeige des Workspace, um ein neues Szenario zu erstellen </summary>
        void CreateNewScenario()
        {
            Scenario newScenario = Scenario.CreateNewScenario();
            NewScenarioViewModel workspace = new NewScenarioViewModel(newScenario, _scenarioRepository);
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        /// <summary> Für die Anzeige bestehender Szenarien </summary>
        void ShowScenario(string scenario)
        {
            TobiiViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is TobiiViewModel)
                as TobiiViewModel;

                workspace = new TobiiViewModel(_scenarioRepository, scenario);
                this.Workspaces.Add(workspace);

            this.SetActiveWorkspace(workspace);
        }

        /// <summary> Für die Anzeige des Workspace, um ein Szenario zu löschen </summary>
        void DeleteScenario()
        {
            if (!(this.Workspaces.FirstOrDefault(vm => vm is DeleteScenarioViewModel) is DeleteScenarioViewModel workspace))
            {
                workspace = new DeleteScenarioViewModel(_scenarioRepository);
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        /// <summary> Legt den aktiven Worskpace fest </summary>
        void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }

        /// <summary> Eventhandler, wenn ein neues Szenario erstellt wurde, um es im Navigationsmenü anzuzeigen </summary>
        /// /// <param name="sender"> Objekt von dem das Event ausgeht</param>
        /// <param name="e"> Ausgelöstes Event </param>
        void OnScenarioAddedToRepository(object sender, ScenarioAddedEventArgs e)
        {
            List<Scenario> all =
                 _scenarioRepository.GetScenarios();
            this.Commands.Add(new CommandViewModel(
                    all.ElementAt(all.Count()-1).Titel,
                     new RelayCommand(param => this.ShowScenario(all.ElementAt(all.Count() - 1).Titel))));
            this.ShowScenario(all.ElementAt(all.Count() - 1).Titel);
        }

        /// <summary> Eventhandler, wenn ein Szenario glöscht wurde, um es aus dem Navigationsmenü zu entfernen </summary>
        /// /// <param name="sender"> Objekt von dem das Event ausgeht</param>
        /// <param name="e"> Ausgelöstes Event </param>
        void OnScenarioDeletedFromRepository(object sender, ScenarioDeletedEventArgs e)
        {
            this.Commands.Remove((Commands.SingleOrDefault(i => i.DisplayName == e.ToRemoveScenario.Titel)));
        }
    }
}
using Bildwahl.DataAccess;
using Bildwahl.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace Bildwahl.ViewModel
{
    /// <summary> Das ViewModel für das Löschen eines Szenarios </summary>
    class DeleteScenarioViewModel : WorkspaceViewModel
    {
        /// <summary> RelayCommand zum Löschen des Szenarios </summary>
        RelayCommand _deleteScenario;

        /// <summary> Verzeichnis für alle Szenarien </summary>
        readonly ScenarioRepository _scenarioRepository;

        /// <summary> Index des ausgewählten Szenarios </summary>
        int _index;

        /// <summary> ObservableCollection mit alle Szenarien </summary>
        public ObservableCollection<Scenario> AllScenarios { get; private set; }

        /// <summary> Ob ein Item der Liste ausgewählt ist </summary>
        public bool IsListItemSelected { get; private set; }

        /// <summary> Konstruktor </summary>
        /// <param name="scenarioRepository"> Verzeichnis für alle Szenarien </param>
        public DeleteScenarioViewModel(ScenarioRepository scenarioRepository)
        {
            _scenarioRepository = scenarioRepository;
            /// Registrieren des Events
            _scenarioRepository.ScenarioDeleted += this.OnScenarioDeletedFromRepository;         
            IsListItemSelected = false;
            this.CreateAllScenarios();
        }

        /// <summary> Eventhandler wenn Szenario gelöscht wird </summary>
        /// <param name="sender"> Objekt von dem das Event ausgeht</param>
        /// <param name="e"> Ausgelöstes Event </param>
        private void OnScenarioDeletedFromRepository(object sender, ScenarioDeletedEventArgs e)
        {
            AllScenarios.Remove(e.ToRemoveScenario);
        }

        /// <summary> Erstellt alle Szenarien bei Programmstart </summary>
        void CreateAllScenarios()
        {
            List<Scenario> all = _scenarioRepository.GetScenarios();
            foreach (Scenario cvm in all)
                cvm.PropertyChanged += this.OnScenarioPropertyChanged;

            this.AllScenarios = new ObservableCollection<Scenario>(all);
        }

        /// <summary> Event wird ausgelöst, wenn Item in der Liste ausgewählt wird </summary>
        /// <param name="sender"> Objekt von dem das Event ausgeht</param>
        /// <param name="e"> Ausgelöstes Event </param>
        void OnScenarioPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            string IsSelected = "IsSelected";
            (sender as Scenario).VerifyPropertyName(IsSelected);
            IsListItemSelected = false;
            base.OnPropertyChanged("IsListItemSelected");
            if (e.PropertyName == IsSelected)
            {
                if ((sender as Scenario).IsSelected)
                {
                    _index = AllScenarios.IndexOf(AllScenarios.Where(p => p.IsSelected == true).FirstOrDefault());
                    BlueBlue= AllScenarios.ElementAt(_index).BlueBlue;
                    BlueRed = AllScenarios.ElementAt(_index).BlueRed;
                    BlueGreen = AllScenarios.ElementAt(_index).BlueGreen;
                    BlueYellow = AllScenarios.ElementAt(_index).BlueYellow;

                    RedBlue = AllScenarios.ElementAt(_index).RedBlue;
                    RedRed = AllScenarios.ElementAt(_index).RedRed;
                    RedGreen = AllScenarios.ElementAt(_index).RedGreen;
                    RedYellow = AllScenarios.ElementAt(_index).RedYellow;

                    GreenBlue = AllScenarios.ElementAt(_index).GreenBlue;
                    GreenRed = AllScenarios.ElementAt(_index).GreenRed;
                    GreenGreen = AllScenarios.ElementAt(_index).GreenGreen;
                    GreenYellow = AllScenarios.ElementAt(_index).GreenYellow;

                    YellowBlue = AllScenarios.ElementAt(_index).YellowBlue;
                    YellowRed = AllScenarios.ElementAt(_index).YellowRed;
                    YellowGreen = AllScenarios.ElementAt(_index).YellowGreen;
                    YellowYellow = AllScenarios.ElementAt(_index).YellowYellow;

                    IsListItemSelected = true;
                    base.OnPropertyChanged("IsListItemSelected");
                }
            }
        }

        /// <summary> Command über das das Szenario gelöscht wird </summary>
        public ICommand DeleteScenario
        {
            get
            {
                if (_deleteScenario == null)
                {
                    _deleteScenario = new RelayCommand(
                        param => this.Delete()
                        );
                }
                return _deleteScenario;
            }
        }

        /// <summary> Löscht das ausgewählte Szenario </summary>
        public void Delete()
        {
            /// <summary> Index des ausgewählten Szenarios </summary>
            int index = AllScenarios.IndexOf(AllScenarios.Where(p => p.IsSelected == true).FirstOrDefault());
            Scenario scenario = AllScenarios.ElementAt(index);
            _scenarioRepository.DeleteScenario(scenario);
            BlueBlue = null;
            BlueRed = null;
            BlueGreen = null;
            BlueYellow = null;

            RedBlue = null;
            RedRed = null;
            RedGreen = null;
            RedYellow = null;

            GreenBlue = null;
            GreenRed = null;
            GreenGreen = null;
            GreenYellow = null;

            YellowBlue = null;
            YellowRed = null;
            YellowGreen = null;
            YellowYellow = null;
            IsListItemSelected = false;
            base.OnPropertyChanged("IsListItemSelected");
        }

        /// <summary> Titel des ausgewählten Szenarios </summary>
        public string Titel
        {
            get { return AllScenarios.ElementAt(_index).Titel; }
            set
            {
                if (value == AllScenarios.ElementAt(_index).Titel)
                    return;

                AllScenarios.ElementAt(_index).Titel = value;

                base.OnPropertyChanged("Titel");
            }
        }

        /// Alle Bilder
        private string blueBlue;
        private string blueRed;
        private string blueGreen;
        private string blueYellow;

        private string redBlue;
        private string redRed;
        private string redGreen;
        private string redYellow;

        private string greenBlue;
        private string greenRed;
        private string greenGreen;
        private string greenYellow;

        private string yellowBlue;
        private string yellowRed;
        private string yellowGreen;
        private string yellowYellow;

        #region ImageLinks 

        /// Alle Bilder
        public string BlueBlue
        {
            get { return blueBlue; }
            set
            {
                if (value == blueBlue)
                    return;

               blueBlue = value;
               base.OnPropertyChanged("BlueBlue");
            }
        }
        public string BlueRed
        {
            get { return blueRed; }
            set
            {
                if (value == blueRed)
                    return;

                blueRed = value;

                base.OnPropertyChanged("BlueRed");
            }
        }
        public string BlueGreen
        {
            get { return blueGreen; }
            set
            {
                if (value == blueGreen)
                    return;

                blueGreen = value;

                base.OnPropertyChanged("BlueGreen");
            }
        }
        public string BlueYellow
        {
            get { return blueYellow; }
            set
            {
                if (value == blueYellow)
                    return;

                blueYellow = value;

                base.OnPropertyChanged("BlueYellow");
            }
        }

        public string RedBlue
        {
            get { return redBlue; }
            set
            {
                if (value == redBlue)
                    return;

                redBlue = value;

                base.OnPropertyChanged("RedBlue");
            }
        }
        public string RedRed
        {
            get { return redRed; }
            set
            {
                if (value == redRed)
                    return;

                redRed = value;

                base.OnPropertyChanged("RedRed");
            }
        }
        public string RedGreen
        {
            get { return redGreen; }
            set
            {
                if (value == redGreen)
                    return;

                redGreen = value;

                base.OnPropertyChanged("RedGreen");
            }
        }
        public string RedYellow
        {
            get { return redYellow; }
            set
            {
                if (value == redYellow)
                    return;

                redYellow = value;

                base.OnPropertyChanged("RedYellow");
            }
        }

        public string GreenBlue
        {
            get { return greenBlue; }
            set
            {
                if (value == greenBlue)
                    return;

                greenBlue = value;

                base.OnPropertyChanged("GreenBlue");
            }
        }
        public string GreenRed
        {
            get { return greenRed; }
            set
            {
                if (value == greenRed)
                    return;

                greenRed = value;

                base.OnPropertyChanged("GreenRed");
            }
        }
        public string GreenGreen
        {
            get { return greenGreen; }
            set
            {
                if (value == greenGreen)
                    return;

                greenGreen = value;

                base.OnPropertyChanged("GreenGreen");
            }
        }
        public string GreenYellow
        {
            get { return greenYellow; }
            set
            {
                if (value == greenYellow)
                    return;

                greenYellow = value;

                base.OnPropertyChanged("GreenYellow");
            }
        }

        public string YellowBlue
        {
            get { return yellowBlue; }
            set
            {
                if (value == yellowBlue)
                    return;

                yellowBlue = value;

                base.OnPropertyChanged("YellowBlue");
            }
        }
        public string YellowRed
        {
            get { return yellowRed; }
            set
            {
                if (value == yellowRed)
                    return;

                yellowRed = value;

                base.OnPropertyChanged("YellowRed");
            }
        }
        public string YellowGreen
        {
            get { return yellowGreen; }
            set
            {
                if (value == yellowGreen)
                    return;

                yellowGreen = value;

                base.OnPropertyChanged("YellowGreen");
            }
        }
        public string YellowYellow
        {
            get { return yellowYellow; }
            set
            {
                if (value == yellowYellow)
                    return;

                yellowYellow = value;

                base.OnPropertyChanged("YellowYellow");
            }
        }
        #endregion
    }
}

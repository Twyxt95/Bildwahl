using Bildwahl.DataAccess;
using Bildwahl.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bildwahl.ViewModel
{
    class DeleteScenarioViewModel : WorkspaceViewModel
    {
        RelayCommand _deleteScenario;
        RelayCommand _deleteImageCommandBlueBlue;
        RelayCommand _deleteImageCommandBlueRed;
        RelayCommand _deleteImageCommandBlueGreen;
        RelayCommand _deleteImageCommandBlueYellow;

        RelayCommand _deleteImageCommandRedBlue;
        RelayCommand _deleteImageCommandRedRed;
        RelayCommand _deleteImageCommandRedGreen;
        RelayCommand _deleteImageCommandRedYellow;

        RelayCommand _deleteImageCommandGreenBlue;
        RelayCommand _deleteImageCommandGreenRed;
        RelayCommand _deleteImageCommandGreenGreen;
        RelayCommand _deleteImageCommandGreenYellow;

        RelayCommand _deleteImageCommandYellowBlue;
        RelayCommand _deleteImageCommandYellowRed;
        RelayCommand _deleteImageCommandYellowGreen;
        RelayCommand _deleteImageCommandYellowYellow;

        RelayCommand _saveImageCommandBlueBlue;
        RelayCommand _saveImageCommandBlueRed;
        RelayCommand _saveImageCommandBlueGreen;
        RelayCommand _saveImageCommandBlueYellow;

        RelayCommand _saveImageCommandRedBlue;
        RelayCommand _saveImageCommandRedRed;
        RelayCommand _saveImageCommandRedGreen;
        RelayCommand _saveImageCommandRedYellow;

        RelayCommand _saveImageCommandGreenBlue;
        RelayCommand _saveImageCommandGreenRed;
        RelayCommand _saveImageCommandGreenGreen;
        RelayCommand _saveImageCommandGreenYellow;

        RelayCommand _saveImageCommandYellowBlue;
        RelayCommand _saveImageCommandYellowRed;
        RelayCommand _saveImageCommandYellowGreen;
        RelayCommand _saveImageCommandYellowYellow;
        readonly ScenarioRepository _scenarioRepository;
        int _index;

        public DeleteScenarioViewModel(ScenarioRepository scenarioRepository)
        {
            _scenarioRepository = scenarioRepository;
            _scenarioRepository.ScenarioDeleted += this.OnScenarioDeletedFromRepository;
            IsListItemSelected = false;
            this.CreateAllScenarios();
        }

        private void OnScenarioDeletedFromRepository(object sender, ScenarioDeletedEventArgs e)
        {
            AllScenarios.Remove(e.ToRemoveScenario);
        }

        void CreateAllScenarios()
        {
            List<Scenario> all = _scenarioRepository.GetScenarios();
            foreach (Scenario cvm in all)
                cvm.PropertyChanged += this.OnScenarioPropertyChanged;

            this.AllScenarios = new ObservableCollection<Scenario>(all);
        }

        void OnScenarioPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            string IsSelected = "IsSelected";
            // Make sure that the property name we're referencing is valid.
            // This is a debugging technique, and does not execute in a Release build.
            (sender as Scenario).VerifyPropertyName(IsSelected);
            IsListItemSelected = false;
            base.OnPropertyChanged("IsListItemSelected");
            // When a scenario is selected or unselected, we must let the
            // world know that the TotalSelectedSales property has changed,
            // so that it will be queried again for a new value.
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

        public ObservableCollection<Scenario> AllScenarios { get; private set; }

        public bool IsListItemSelected { get; private set; }

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

        public void Delete()
        {
            int index = AllScenarios.IndexOf(AllScenarios.Where(p => p.IsSelected == true).FirstOrDefault());
            Scenario scenario = AllScenarios.ElementAt(index);
            _scenarioRepository.DeleteScenario(scenario);
        }

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

        #region DeleteImageCommands
        public ICommand DeleteImageCommandBlueBlue
        {
            get
            {
                if (_deleteImageCommandBlueBlue == null)
                {
                    _deleteImageCommandBlueBlue = new RelayCommand(
                        param => this.DeleteImage("BlueBlue")
                        );
                }
                return _deleteImageCommandBlueBlue;
            }
        }
        public ICommand DeleteImageCommandBlueRed
        {
            get
            {
                if (_deleteImageCommandBlueRed == null)
                {
                    _deleteImageCommandBlueRed = new RelayCommand(
                        param => this.DeleteImage("BlueRed")
                        );
                }
                return _deleteImageCommandBlueRed;
            }
        }
        public ICommand DeleteImageCommandBlueGreen
        {
            get
            {
                if (_deleteImageCommandBlueGreen == null)
                {
                    _deleteImageCommandBlueGreen = new RelayCommand(
                        param => this.DeleteImage("BlueGreen")
                        );
                }
                return _deleteImageCommandBlueGreen;
            }
        }
        public ICommand DeleteImageCommandBlueYellow
        {
            get
            {
                if (_deleteImageCommandBlueYellow == null)
                {
                    _deleteImageCommandBlueYellow = new RelayCommand(
                        param => this.DeleteImage("BlueYellow")
                        );
                }
                return _deleteImageCommandBlueYellow;
            }
        }

        public ICommand DeleteImageCommandRedBlue
        {
            get
            {
                if (_deleteImageCommandRedBlue == null)
                {
                    _deleteImageCommandRedBlue = new RelayCommand(
                        param => this.DeleteImage("RedBlue")
                        );
                }
                return _deleteImageCommandRedBlue;
            }
        }
        public ICommand DeleteImageCommandRedRed
        {
            get
            {
                if (_deleteImageCommandRedRed == null)
                {
                    _deleteImageCommandRedRed = new RelayCommand(
                        param => this.DeleteImage("RedRed")
                        );
                }
                return _deleteImageCommandRedRed;
            }
        }
        public ICommand DeleteImageCommandRedGreen
        {
            get
            {
                if (_deleteImageCommandRedGreen == null)
                {
                    _deleteImageCommandRedGreen = new RelayCommand(
                        param => this.DeleteImage("RedGreen")
                        );
                }
                return _deleteImageCommandRedGreen;
            }
        }
        public ICommand DeleteImageCommandRedYellow
        {
            get
            {
                if (_deleteImageCommandRedYellow == null)
                {
                    _deleteImageCommandRedYellow = new RelayCommand(
                        param => this.DeleteImage("RedYellow")
                        );
                }
                return _deleteImageCommandRedYellow;
            }
        }

        public ICommand DeleteImageCommandGreenBlue
        {
            get
            {
                if (_deleteImageCommandGreenBlue == null)
                {
                    _deleteImageCommandGreenBlue = new RelayCommand(
                        param => this.DeleteImage("GreenBlue")
                        );
                }
                return _deleteImageCommandGreenBlue;
            }
        }
        public ICommand DeleteImageCommandGreenRed
        {
            get
            {
                if (_deleteImageCommandGreenRed == null)
                {
                    _deleteImageCommandGreenRed = new RelayCommand(
                        param => this.DeleteImage("GreenRed")
                        );
                }
                return _deleteImageCommandGreenRed;
            }
        }
        public ICommand DeleteImageCommandGreenGreen
        {
            get
            {
                if (_deleteImageCommandGreenGreen == null)
                {
                    _deleteImageCommandGreenGreen = new RelayCommand(
                        param => this.DeleteImage("GreenGreen")
                        );
                }
                return _deleteImageCommandGreenGreen;
            }
        }
        public ICommand DeleteImageCommandGreenYellow
        {
            get
            {
                if (_deleteImageCommandGreenYellow == null)
                {
                    _deleteImageCommandGreenYellow = new RelayCommand(
                        param => this.DeleteImage("GreenYellow")
                        );
                }
                return _deleteImageCommandGreenYellow;
            }
        }

        public ICommand DeleteImageCommandYellowBlue
        {
            get
            {
                if (_deleteImageCommandYellowBlue == null)
                {
                    _deleteImageCommandYellowBlue = new RelayCommand(
                        param => this.DeleteImage("YellowBlue")
                        );
                }
                return _deleteImageCommandYellowBlue;
            }
        }
        public ICommand DeleteImageCommandYellowRed
        {
            get
            {
                if (_deleteImageCommandYellowRed == null)
                {
                    _deleteImageCommandYellowRed = new RelayCommand(
                        param => this.DeleteImage("YellowRed")
                        );
                }
                return _deleteImageCommandYellowRed;
            }
        }
        public ICommand DeleteImageCommandYellowGreen
        {
            get
            {
                if (_deleteImageCommandYellowGreen == null)
                {
                    _deleteImageCommandYellowGreen = new RelayCommand(
                        param => this.DeleteImage("YellowGreen")
                        );
                }
                return _deleteImageCommandYellowGreen;
            }
        }
        public ICommand DeleteImageCommandYellowYellow
        {
            get
            {
                if (_deleteImageCommandYellowYellow == null)
                {
                    _deleteImageCommandYellowYellow = new RelayCommand(
                        param => this.DeleteImage("YellowYellow")
                        );
                }
                return _deleteImageCommandYellowYellow;
            }
        }
        #endregion

        #region SaveImageCommands
        public ICommand SaveImageCommandBlueBlue
        {
            get
            {
                if (_saveImageCommandBlueBlue == null)
                {
                    _saveImageCommandBlueBlue = new RelayCommand(
                        param => this.SaveImage("BlueBlue")
                        );
                }
                return _saveImageCommandBlueBlue;
            }
        }

        

        public ICommand SaveImageCommandBlueRed
        {
            get
            {
                if (_saveImageCommandBlueRed == null)
                {
                    _saveImageCommandBlueRed = new RelayCommand(
                        param => this.SaveImage("BlueRed")
                        );
                }
                return _saveImageCommandBlueRed;
            }
        }
        public ICommand SaveImageCommandBlueGreen
        {
            get
            {
                if (_saveImageCommandBlueGreen == null)
                {
                    _saveImageCommandBlueGreen = new RelayCommand(
                        param => this.SaveImage("BlueGreen")
                        );
                }
                return _saveImageCommandBlueGreen;
            }
        }
        public ICommand SaveImageCommandBlueYellow
        {
            get
            {
                if (_saveImageCommandBlueYellow == null)
                {
                    _saveImageCommandBlueYellow = new RelayCommand(
                        param => this.SaveImage("BlueYellow")
                        );
                }
                return _saveImageCommandBlueYellow;
            }
        }

        public ICommand SaveImageCommandRedBlue
        {
            get
            {
                if (_saveImageCommandRedBlue == null)
                {
                    _saveImageCommandRedBlue = new RelayCommand(
                        param => this.SaveImage("RedBlue")
                        );
                }
                return _saveImageCommandRedBlue;
            }
        }
        public ICommand SaveImageCommandRedRed
        {
            get
            {
                if (_saveImageCommandRedRed == null)
                {
                    _saveImageCommandRedRed = new RelayCommand(
                        param => this.SaveImage("RedRed")
                        );
                }
                return _saveImageCommandRedRed;
            }
        }
        public ICommand SaveImageCommandRedGreen
        {
            get
            {
                if (_saveImageCommandRedGreen == null)
                {
                    _saveImageCommandRedGreen = new RelayCommand(
                        param => this.SaveImage("RedGreen")
                        );
                }
                return _saveImageCommandRedGreen;
            }
        }
        public ICommand SaveImageCommandRedYellow
        {
            get
            {
                if (_saveImageCommandRedYellow == null)
                {
                    _saveImageCommandRedYellow = new RelayCommand(
                        param => this.SaveImage("RedYellow")
                        );
                }
                return _saveImageCommandRedYellow;
            }
        }

        public ICommand SaveImageCommandGreenBlue
        {
            get
            {
                if (_saveImageCommandGreenBlue == null)
                {
                    _saveImageCommandGreenBlue = new RelayCommand(
                        param => this.SaveImage("GreenBlue")
                        );
                }
                return _saveImageCommandGreenBlue;
            }
        }
        public ICommand SaveImageCommandGreenRed
        {
            get
            {
                if (_saveImageCommandGreenRed == null)
                {
                    _saveImageCommandGreenRed = new RelayCommand(
                        param => this.SaveImage("GreenRed")
                        );
                }
                return _saveImageCommandGreenRed;
            }
        }
        public ICommand SaveImageCommandGreenGreen
        {
            get
            {
                if (_saveImageCommandGreenGreen == null)
                {
                    _saveImageCommandGreenGreen = new RelayCommand(
                        param => this.SaveImage("GreenGreen")
                        );
                }
                return _saveImageCommandGreenGreen;
            }
        }
        public ICommand SaveImageCommandGreenYellow
        {
            get
            {
                if (_saveImageCommandGreenYellow == null)
                {
                    _saveImageCommandGreenYellow = new RelayCommand(
                        param => this.SaveImage("GreenYellow")
                        );
                }
                return _saveImageCommandGreenYellow;
            }
        }

        public ICommand SaveImageCommandYellowBlue
        {
            get
            {
                if (_saveImageCommandYellowBlue == null)
                {
                    _saveImageCommandYellowBlue = new RelayCommand(
                        param => this.SaveImage("YellowBlue")
                        );
                }
                return _saveImageCommandYellowBlue;
            }
        }
        public ICommand SaveImageCommandYellowRed
        {
            get
            {
                if (_saveImageCommandYellowRed == null)
                {
                    _saveImageCommandYellowRed = new RelayCommand(
                        param => this.SaveImage("YellowRed")
                        );
                }
                return _saveImageCommandYellowRed;
            }
        }
        public ICommand SaveImageCommandYellowGreen
        {
            get
            {
                if (_saveImageCommandYellowGreen == null)
                {
                    _saveImageCommandYellowGreen = new RelayCommand(
                        param => this.SaveImage("YellowGreen")
                        );
                }
                return _saveImageCommandYellowGreen;
            }
        }
        public ICommand SaveImageCommandYellowYellow
        {
            get
            {
                if (_saveImageCommandYellowYellow == null)
                {
                    _saveImageCommandYellowYellow = new RelayCommand(
                        param => this.SaveImage("YellowYellow")
                        );
                }
                return _saveImageCommandYellowYellow;
            }
        }

        #endregion // SaveImageCommands
        private void SaveImage(string v)
        {

        }

        private void DeleteImage(string v)
        {

        }
    }
}

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Input;
using Bildwahl.DataAccess;
using Bildwahl.Model;
using Bildwahl.Properties;
using Microsoft.Win32;

namespace Bildwahl.ViewModel
{
    public class NewScenarioViewModel : WorkspaceViewModel, IDataErrorInfo
    {
        #region Fields

        readonly Scenario _scenario;
        readonly ScenarioRepository _scenarioRepository;
        readonly string _fileName;
        bool _isSelected;

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

        RelayCommand _saveCommand;
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

        #endregion // Fields

        #region Constructor

        public NewScenarioViewModel(Scenario scanario, ScenarioRepository scenarioRepository)
        {
            _scenario = scanario ?? throw new ArgumentNullException("scenario");
            _scenarioRepository = scenarioRepository ?? throw new ArgumentNullException("scenarioRepository");
        }

        #endregion // Constructor

        #region Scenario Properties


        public string Titel
        {
            get { return _scenario.Titel; }
            set
            {
                if (value == _scenario.Titel)
                    return;

                _scenario.Titel = value;

                base.OnPropertyChanged("Titel");
            }
        }

        #region ImageLinks

        public string BlueBlue
        {
            get { return _scenario.BlueBlue; }
            set
            {
                if (value == _scenario.BlueBlue)
                    return;

                _scenario.BlueBlue = value;

                base.OnPropertyChanged("BlueBlue");
            }
        }
        public string BlueRed
        {
            get { return _scenario.BlueRed; }
            set
            {
                if (value == _scenario.BlueRed)
                    return;

                _scenario.BlueRed = value;

                base.OnPropertyChanged("BlueRed");
            }
        }
        public string BlueGreen
        {
            get { return _scenario.BlueGreen; }
            set
            {
                if (value == _scenario.BlueGreen)
                    return;

                _scenario.BlueGreen = value;

                base.OnPropertyChanged("BlueGreen");
            }
        }
        public string BlueYellow
        {
            get { return _scenario.BlueYellow; }
            set
            {
                if (value == _scenario.BlueYellow)
                    return;

                _scenario.BlueYellow = value;

                base.OnPropertyChanged("BlueYellow");
            }
        }

        public string RedBlue
        {
            get { return _scenario.RedBlue; }
            set
            {
                if (value == _scenario.RedBlue)
                    return;

                _scenario.RedBlue = value;

                base.OnPropertyChanged("RedBlue");
            }
        }
        public string RedRed
        {
            get { return _scenario.RedRed; }
            set
            {
                if (value == _scenario.RedRed)
                    return;

                _scenario.RedRed = value;

                base.OnPropertyChanged("RedRed");
            }
        }
        public string RedGreen
        {
            get { return _scenario.RedGreen; }
            set
            {
                if (value == _scenario.RedGreen)
                    return;

                _scenario.RedGreen = value;

                base.OnPropertyChanged("RedGreen");
            }
        }
        public string RedYellow
        {
            get { return _scenario.RedYellow; }
            set
            {
                if (value == _scenario.RedYellow)
                    return;

                _scenario.RedYellow = value;

                base.OnPropertyChanged("RedYellow");
            }
        }

        public string GreenBlue
        {
            get { return _scenario.GreenBlue; }
            set
            {
                if (value == _scenario.GreenBlue)
                    return;

                _scenario.GreenBlue = value;

                base.OnPropertyChanged("GreenBlue");
            }
        }
        public string GreenRed
        {
            get { return _scenario.GreenRed; }
            set
            {
                if (value == _scenario.GreenRed)
                    return;

                _scenario.GreenRed = value;

                base.OnPropertyChanged("GreenRed");
            }
        }
        public string GreenGreen
        {
            get { return _scenario.GreenGreen; }
            set
            {
                if (value == _scenario.GreenGreen)
                    return;

                _scenario.GreenGreen = value;

                base.OnPropertyChanged("GreenGreen");
            }
        }
        public string GreenYellow
        {
            get { return _scenario.GreenYellow; }
            set
            {
                if (value == _scenario.GreenYellow)
                    return;

                _scenario.GreenYellow = value;

                base.OnPropertyChanged("GreenYellow");
            }
        }

        public string YellowBlue
        {
            get { return _scenario.YellowBlue; }
            set
            {
                if (value == _scenario.YellowBlue)
                    return;

                _scenario.YellowBlue = value;

                base.OnPropertyChanged("YellowBlue");
            }
        }
        public string YellowRed
        {
            get { return _scenario.YellowRed; }
            set
            {
                if (value == _scenario.YellowRed)
                    return;

                _scenario.YellowRed = value;

                base.OnPropertyChanged("YellowRed");
            }
        }
        public string YellowGreen
        {
            get { return _scenario.YellowGreen; }
            set
            {
                if (value == _scenario.YellowGreen)
                    return;

                _scenario.YellowGreen = value;

                base.OnPropertyChanged("YellowGreen");
            }
        }
        public string YellowYellow
        {
            get { return _scenario.YellowYellow; }
            set
            {
                if (value == _scenario.YellowYellow)
                    return;

                _scenario.YellowYellow = value;

                base.OnPropertyChanged("YellowYellow");
            }
        }

        #endregion


        #endregion

        #region Presentation Properties


        /// <summary>
        /// Returns a command that saves the scenario.
        /// </summary>
        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(
                        param => this.Save(),
                        param => this.CanSave
                        );
                }
                return _saveCommand;
            }
        }

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
        #endregion // Presentation Properties

        #region Public Methods

        /// <summary>
        /// Saves the scenario to the repository.  This method is invoked by the SaveCommand.
        /// </summary>
        public void Save()
        {
            if (!_scenario.IsValid)
                throw new InvalidOperationException(Strings.NewScenarioViewModel_Exception_CannotSave);

            if (this.IsNewScenario)
                _scenarioRepository.AddScenario(_scenario);

            base.OnPropertyChanged("DisplayName");
        }

        public void DeleteImage(string field)
        {
            switch (field)
            {
                case "BlueBlue":
                    this.BlueBlue = null;
                    _scenario.BlueBlue = null;
                    break;
                case "BlueRed":
                    this.BlueRed = null;
                    _scenario.BlueRed = null;
                    break;
                case "BlueGreen":
                    this.BlueGreen = null;
                    _scenario.BlueGreen = null;
                    break;
                case "BlueYellow":
                    this.BlueYellow = null;
                    _scenario.BlueYellow = null;
                    break;

                case "RedBlue":
                    this.RedBlue = null;
                    _scenario.RedBlue = null;
                    break;
                case "RedRed":
                    this.RedRed = null;
                    _scenario.RedRed = null;
                    break;
                case "RedGreen":
                    this.RedGreen = null;
                    _scenario.RedGreen = null;
                    break;
                case "RedYellow":
                    this.RedYellow = null;
                    _scenario.RedYellow = null;
                    break;

                case "GreenBlue":
                    this.GreenBlue = null;
                    _scenario.GreenBlue = null;
                    break;
                case "GreenRed":
                    this.GreenRed = null;
                    _scenario.GreenRed = null;
                    break;
                case "GreenGreen":
                    this.GreenGreen = null;
                    _scenario.GreenGreen = null;
                    break;
                case "GreenYellow":
                    this.GreenYellow = null;
                    _scenario.GreenYellow = null;
                    break;

                case "YellowBlue":
                    this.YellowBlue = null;
                    _scenario.YellowBlue = null;
                    break;
                case "YellowRed":
                    this.YellowRed = null;
                    _scenario.YellowRed = null;
                    break;
                case "YellowGreen":
                    this.YellowGreen = null;
                    _scenario.YellowGreen = null;
                    break;
                case "YellowYellow":
                    this.YellowYellow = null;
                    _scenario.YellowYellow = null;
                    break;

                default:
                    Debug.Fail("Unexpected property being validated on ImageLinks: " + field);
                    break;
            }
        }

        public void SaveImage(string field)
        {
            OpenFileDialog _importImage = new OpenFileDialog();
            _importImage.Title = "Bild auswählen";
            if (_importImage.ShowDialog() == true)
            {
                string ImportPath = _importImage.FileName;
                string[] splittedPath = ImportPath.Split('\\');
                string fileName = splittedPath[splittedPath.Length - 1];
                Console.WriteLine(ImportPath);
                
                try
                {
                    File.Copy(ImportPath, @"C:\Users\Adrian\Documents\Bildwahl\Bildwahl\Bildwahl\bin\Debug\Pictures\" + fileName, true);
                    string destination = @"C:\Users\Adrian\Documents\Bildwahl\Bildwahl\Bildwahl\bin\Debug\Pictures\" + fileName;
                    switch (field)
                    {
                        case "BlueBlue":
                            this.BlueBlue = destination;
                            _scenario.BlueBlue = destination;
                            break;
                        case "BlueRed":
                            this.BlueRed = destination;
                            _scenario.BlueRed = destination;
                            break;
                        case "BlueGreen":
                            this.BlueGreen = destination;
                            _scenario.BlueGreen = destination;
                            break;
                        case "BlueYellow":
                            this.BlueYellow = destination;
                            _scenario.BlueYellow = destination;
                            break;

                        case "RedBlue":
                            this.RedBlue = destination;
                            _scenario.RedBlue = destination;
                            break;
                        case "RedRed":
                            this.RedRed = destination;
                            _scenario.RedRed = destination;
                            break;
                        case "RedGreen":
                            this.RedGreen = destination;
                            _scenario.RedGreen = destination;
                            break;
                        case "RedYellow":
                            this.RedYellow = destination;
                            _scenario.RedYellow = destination;
                            break;

                        case "GreenBlue":
                            this.GreenBlue = destination;
                            _scenario.GreenBlue = destination;
                            break;
                        case "GreenRed":
                            this.GreenRed = destination;
                            _scenario.GreenRed = destination;
                            break;
                        case "GreenGreen":
                            this.GreenGreen = destination;
                            _scenario.GreenGreen = destination;
                            break;
                        case "GreenYellow":
                            this.GreenYellow = destination;
                            _scenario.GreenYellow = destination;
                            break;

                        case "YellowBlue":
                            this.YellowBlue = destination;
                            _scenario.YellowBlue = destination;
                            break;
                        case "YellowRed":
                            this.YellowRed = destination;
                            _scenario.YellowRed = destination;
                            break;
                        case "YellowGreen":
                            this.YellowGreen = destination;
                            _scenario.YellowGreen = destination;
                            break;
                        case "YellowYellow":
                            this.YellowYellow = destination;
                            _scenario.YellowYellow = destination;
                            break;

                        default:
                            Debug.Fail("Unexpected property being validated on ImageLinks: " + field);
                            break;
                    }
                    Console.WriteLine("Succes");
                }
                catch
                {
                    Console.WriteLine("ERrOR");
                }
            }
        }

        #endregion // Public Methods

        #region Private Helpers

        /// <summary>
        /// Returns true if this scenario was created by the user and it has not yet
        /// been saved to the scenario repository.
        /// </summary>
        bool IsNewScenario
        {
            get { return !_scenarioRepository.ContainsScenario(_scenario); }
        }

        /// <summary>
        /// Returns true if the scenario is valid and can be saved.
        /// </summary>
        bool CanSave
        {
            get { return _scenario.IsValid; }
        }

        #endregion // Private Helpers

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error
        {
            get { return (_scenario as IDataErrorInfo).Error; }
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                string error = null;

                    error = (_scenario as IDataErrorInfo)[propertyName];

                // Dirty the commands registered with CommandManager,
                // such as our Save command, so that they are queried
                // to see if they can execute now.
                CommandManager.InvalidateRequerySuggested();

                return error;
            }
        }
        #endregion // IDataErrorInfo Members
    }
}


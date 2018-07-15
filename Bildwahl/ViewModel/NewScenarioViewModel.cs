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
    /// <summary>
    /// A UI-friendly wrapper for a Customer object.
    /// </summary>
    public class NewScenarioViewModel : WorkspaceViewModel, IDataErrorInfo
    {
        #region Fields

        readonly Scenario _customer;
        readonly ScenarioRepository _customerRepository;
        string _customerType;
        string[] _customerTypeOptions;
        string _fileName;
        bool _isSelected;
        RelayCommand _deleteScenarioCommand;

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

        public NewScenarioViewModel(Scenario customer, ScenarioRepository customerRepository)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            if (customerRepository == null)
                throw new ArgumentNullException("customerRepository");

            _customer = customer;
            _customerRepository = customerRepository;
            _customerType = Strings.CustomerViewModel_CustomerTypeOption_NotSpecified;
        }

        #endregion // Constructor

        #region Customer Properties

        public string ImageLink
        {
            get { return _customer.ImageLink; }
            set
            {
                if (value == _customer.ImageLink)
                    return;

                _customer.ImageLink = value;

                base.OnPropertyChanged("ImageLink");
            }
        }

        public string Titel
        {
            get { return _customer.Titel; }
            set
            {
                if (value == _customer.Titel)
                    return;

                _customer.Titel = value;

                base.OnPropertyChanged("Titel");
            }
        }

        #region ImageLinks

        public string BlueBlue
        {
            get { return _customer.BlueBlue; }
            set
            {
                if (value == _customer.BlueBlue)
                    return;

                _customer.BlueBlue = value;

                base.OnPropertyChanged("BlueBlue");
            }
        }
        public string BlueRed
        {
            get { return _customer.BlueRed; }
            set
            {
                if (value == _customer.BlueRed)
                    return;

                _customer.BlueRed = value;

                base.OnPropertyChanged("BlueRed");
            }
        }
        public string BlueGreen
        {
            get { return _customer.BlueGreen; }
            set
            {
                if (value == _customer.BlueGreen)
                    return;

                _customer.BlueGreen = value;

                base.OnPropertyChanged("BlueGreen");
            }
        }
        public string BlueYellow
        {
            get { return _customer.BlueYellow; }
            set
            {
                if (value == _customer.BlueYellow)
                    return;

                _customer.BlueYellow = value;

                base.OnPropertyChanged("BlueYellow");
            }
        }

        public string RedBlue
        {
            get { return _customer.RedBlue; }
            set
            {
                if (value == _customer.RedBlue)
                    return;

                _customer.RedBlue = value;

                base.OnPropertyChanged("RedBlue");
            }
        }
        public string RedRed
        {
            get { return _customer.RedRed; }
            set
            {
                if (value == _customer.RedRed)
                    return;

                _customer.RedRed = value;

                base.OnPropertyChanged("RedRed");
            }
        }
        public string RedGreen
        {
            get { return _customer.RedGreen; }
            set
            {
                if (value == _customer.RedGreen)
                    return;

                _customer.RedGreen = value;

                base.OnPropertyChanged("RedGreen");
            }
        }
        public string RedYellow
        {
            get { return _customer.RedYellow; }
            set
            {
                if (value == _customer.RedYellow)
                    return;

                _customer.RedYellow = value;

                base.OnPropertyChanged("RedYellow");
            }
        }

        public string GreenBlue
        {
            get { return _customer.GreenBlue; }
            set
            {
                if (value == _customer.GreenBlue)
                    return;

                _customer.GreenBlue = value;

                base.OnPropertyChanged("GreenBlue");
            }
        }
        public string GreenRed
        {
            get { return _customer.GreenRed; }
            set
            {
                if (value == _customer.GreenRed)
                    return;

                _customer.GreenRed = value;

                base.OnPropertyChanged("GreenRed");
            }
        }
        public string GreenGreen
        {
            get { return _customer.GreenGreen; }
            set
            {
                if (value == _customer.GreenGreen)
                    return;

                _customer.GreenGreen = value;

                base.OnPropertyChanged("GreenGreen");
            }
        }
        public string GreenYellow
        {
            get { return _customer.GreenYellow; }
            set
            {
                if (value == _customer.GreenYellow)
                    return;

                _customer.GreenYellow = value;

                base.OnPropertyChanged("GreenYellow");
            }
        }

        public string YellowBlue
        {
            get { return _customer.YellowBlue; }
            set
            {
                if (value == _customer.YellowBlue)
                    return;

                _customer.YellowBlue = value;

                base.OnPropertyChanged("YellowBlue");
            }
        }
        public string YellowRed
        {
            get { return _customer.YellowRed; }
            set
            {
                if (value == _customer.YellowRed)
                    return;

                _customer.YellowRed = value;

                base.OnPropertyChanged("YellowRed");
            }
        }
        public string YellowGreen
        {
            get { return _customer.YellowGreen; }
            set
            {
                if (value == _customer.YellowGreen)
                    return;

                _customer.YellowGreen = value;

                base.OnPropertyChanged("YellowGreen");
            }
        }
        public string YellowYellow
        {
            get { return _customer.YellowYellow; }
            set
            {
                if (value == _customer.YellowYellow)
                    return;

                _customer.YellowYellow = value;

                base.OnPropertyChanged("YellowYellow");
            }
        }

        #endregion


        #endregion // Customer Properties

        #region Presentation Properties

        /// <summary>
        /// Gets/sets a value that indicates what type of customer this is.
        /// This property maps to the IsCompany property of the Customer class,
        /// but also has support for an 'unselected' state.
        /// </summary>
        /*  public string CustomerType
          {
              get { return _customerType; }
              set
              {
                  if (value == _customerType || String.IsNullOrEmpty(value))
                      return;

                  _customerType = value;

                  if (_customerType == Strings.CustomerViewModel_CustomerTypeOption_Company)
                  {
                      _customer.IsCompany = true;
                  }
                  else if (_customerType == Strings.CustomerViewModel_CustomerTypeOption_Person)
                  {
                      _customer.IsCompany = false;
                  }

                  base.OnPropertyChanged("CustomerType");

                  // Since this ViewModel object has knowledge of how to translate
                  // a customer type (i.e. text) to a Customer object's IsCompany property,
                  // it also must raise a property change notification when it changes
                  // the value of IsCompany.  The LastName property is validated 
                  // differently based on whether the customer is a company or not,
                  // so the validation for the LastName property must execute now.
                  base.OnPropertyChanged("LastName");
              }
          }

          /// <summary>
          /// Returns a list of strings used to populate the Customer Type selector.
          /// </summary>
          public string[] CustomerTypeOptions
          {
              get
              {
                  if (_customerTypeOptions == null)
                  {
                      _customerTypeOptions = new string[]
                      {
                          Strings.CustomerViewModel_CustomerTypeOption_NotSpecified,
                          Strings.CustomerViewModel_CustomerTypeOption_Person,
                          Strings.CustomerViewModel_CustomerTypeOption_Company
                      };
                  }
                  return _customerTypeOptions;
              }
          }*/

        public override string DisplayName
        {
            get
            {
                if (this.IsNewCustomer)
                {
                    return Strings.CustomerViewModel_DisplayName;
                }
               /* else if (_customer.IsCompany)
                {
                    return _customer.FirstName;
                }*/
                else
                {
                    return  _customer.ImageLink;
                }
            }
        }

        /// <summary>
        /// Gets/sets whether this customer is selected in the UI.
        /// </summary>
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value == _isSelected)
                    return;

                _isSelected = value;

                base.OnPropertyChanged("IsSelected");
            }
        }

        //public ICommand EliminarCommand => _deleteScenarioCommand ?? _deleteScenarioCommand = new RelayCommand<Scenario>(Delete));

        public ICommand DeleteScenarioCommand
        {
            get
            {
                if (_deleteScenarioCommand == null)
                {
                    _deleteScenarioCommand = new RelayCommand(
                        param => this.Delete(_customer)
                        );
                }
                return _deleteScenarioCommand;
            }
        }

        public void Delete(Scenario scenario)
        {
           _customerRepository.DeleteScenario(scenario);
        }
        /// <summary>
        /// Returns a command that saves the customer.
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
        /// Saves the customer to the repository.  This method is invoked by the SaveCommand.
        /// </summary>
        public void Save()
        {
            if (!_customer.IsValid)
                throw new InvalidOperationException(Strings.CustomerViewModel_Exception_CannotSave);

            if (this.IsNewCustomer)
                _customerRepository.AddCustomer(_customer);

            base.OnPropertyChanged("DisplayName");
        }

        public void DeleteImage(string field)
        {
            switch (field)
            {
                case "BlueBlue":
                    this.BlueBlue = null;
                    _customer.BlueBlue = null;
                    break;
                case "BlueRed":
                    this.BlueRed = null;
                    _customer.BlueRed = null;
                    break;
                case "BlueGreen":
                    this.BlueGreen = null;
                    _customer.BlueGreen = null;
                    break;
                case "BlueYellow":
                    this.BlueYellow = null;
                    _customer.BlueYellow = null;
                    break;

                case "RedBlue":
                    this.RedBlue = null;
                    _customer.RedBlue = null;
                    break;
                case "RedRed":
                    this.RedRed = null;
                    _customer.RedRed = null;
                    break;
                case "RedGreen":
                    this.RedGreen = null;
                    _customer.RedGreen = null;
                    break;
                case "RedYellow":
                    this.RedYellow = null;
                    _customer.RedYellow = null;
                    break;

                case "GreenBlue":
                    this.GreenBlue = null;
                    _customer.GreenBlue = null;
                    break;
                case "GreenRed":
                    this.GreenRed = null;
                    _customer.GreenRed = null;
                    break;
                case "GreenGreen":
                    this.GreenGreen = null;
                    _customer.GreenGreen = null;
                    break;
                case "GreenYellow":
                    this.GreenYellow = null;
                    _customer.GreenYellow = null;
                    break;

                case "YellowBlue":
                    this.YellowBlue = null;
                    _customer.YellowBlue = null;
                    break;
                case "YellowRed":
                    this.YellowRed = null;
                    _customer.YellowRed = null;
                    break;
                case "YellowGreen":
                    this.YellowGreen = null;
                    _customer.YellowGreen = null;
                    break;
                case "YellowYellow":
                    this.YellowYellow = null;
                    _customer.YellowYellow = null;
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
                            _customer.BlueBlue = destination;
                            break;
                        case "BlueRed":
                            this.BlueRed = destination;
                            _customer.BlueRed = destination;
                            break;
                        case "BlueGreen":
                            this.BlueGreen = destination;
                            _customer.BlueGreen = destination;
                            break;
                        case "BlueYellow":
                            this.BlueYellow = destination;
                            _customer.BlueYellow = destination;
                            break;

                        case "RedBlue":
                            this.RedBlue = destination;
                            _customer.RedBlue = destination;
                            break;
                        case "RedRed":
                            this.RedRed = destination;
                            _customer.RedRed = destination;
                            break;
                        case "RedGreen":
                            this.RedGreen = destination;
                            _customer.RedGreen = destination;
                            break;
                        case "RedYellow":
                            this.RedYellow = destination;
                            _customer.RedYellow = destination;
                            break;

                        case "GreenBlue":
                            this.GreenBlue = destination;
                            _customer.GreenBlue = destination;
                            break;
                        case "GreenRed":
                            this.GreenRed = destination;
                            _customer.GreenRed = destination;
                            break;
                        case "GreenGreen":
                            this.GreenGreen = destination;
                            _customer.GreenGreen = destination;
                            break;
                        case "GreenYellow":
                            this.GreenYellow = destination;
                            _customer.GreenYellow = destination;
                            break;

                        case "YellowBlue":
                            this.YellowBlue = destination;
                            _customer.YellowBlue = destination;
                            break;
                        case "YellowRed":
                            this.YellowRed = destination;
                            _customer.YellowRed = destination;
                            break;
                        case "YellowGreen":
                            this.YellowGreen = destination;
                            _customer.YellowGreen = destination;
                            break;
                        case "YellowYellow":
                            this.YellowYellow = destination;
                            _customer.YellowYellow = destination;
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
        /// Returns true if this customer was created by the user and it has not yet
        /// been saved to the customer repository.
        /// </summary>
        bool IsNewCustomer
        {
            get { return !_customerRepository.ContainsCustomer(_customer); }
        }

        /// <summary>
        /// Returns true if the customer is valid and can be saved.
        /// </summary>
        bool CanSave
        {
            get { return true /*String.IsNullOrEmpty(this.ValidateCustomerType()) && _customer.IsValid*/; }
        }

        #endregion // Private Helpers

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error
        {
            get { return (_customer as IDataErrorInfo).Error; }
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                string error = null;

                if (propertyName == "CustomerType")
                {
                    // The IsCompany property of the Customer class 
                    // is Boolean, so it has no concept of being in
                    // an "unselected" state.  The NewScenarioViewModel
                    // class handles this mapping and validation.
                    //error = this.ValidateCustomerType();
                }
                else
                {
                    error = (_customer as IDataErrorInfo)[propertyName];
                }

                // Dirty the commands registered with CommandManager,
                // such as our Save command, so that they are queried
                // to see if they can execute now.
                CommandManager.InvalidateRequerySuggested();

                return error;
            }
        }

        



        /* string ValidateCustomerType()
         {
             if (this.CustomerType == Strings.CustomerViewModel_CustomerTypeOption_Company ||
                this.CustomerType == Strings.CustomerViewModel_CustomerTypeOption_Person)
                 return null;

             return Strings.CustomerViewModel_Error_MissingCustomerType;
         }*/

        #endregion // IDataErrorInfo Members
    }
}


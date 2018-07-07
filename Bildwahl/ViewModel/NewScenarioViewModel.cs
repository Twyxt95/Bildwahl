using System;
using System.ComponentModel;
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

        readonly ImageLinks _customer;
        readonly ImageLinksRepository _customerRepository;
        string _customerType;
        string[] _customerTypeOptions;
        bool _isSelected;
        RelayCommand _saveCommand;
        RelayCommand _saveImageCommand;

        #endregion // Fields

        #region Constructor

        public NewScenarioViewModel(ImageLinks customer, ImageLinksRepository customerRepository)
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

        public ICommand SaveImageCommand
        {
            get
            {
                if (_saveImageCommand == null)
                {
                    _saveImageCommand = new RelayCommand(
                        param => this.SaveImage()
                        );
                }
                return _saveImageCommand;
            }
        }

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

        public void SaveImage()
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
                    _customer.ImageLink = @"C:\Users\Adrian\Documents\Bildwahl\Bildwahl\Bildwahl\bin\Debug\Pictures\" + fileName;
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


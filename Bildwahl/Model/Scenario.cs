using Bildwahl.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bildwahl.Model
{
    public class Scenario : IDataErrorInfo
    {
        bool _isSelected;
        #region Creation

        public static Scenario CreateNewScenario()
        {
            return new Scenario();
        }

        public static Scenario CreateImageLinks(
            string titel,
            string blueBlue,
            string blueRed,
            string blueGreen,
            string blueYellow,

            string redBlue,
            string redRed,
            string redGreen,
            string redYellow,

            string greenBlue,
            string greenRed,
            string greenGreen,
            string greenYellow,

            string yellowBlue,
            string yellowRed,
            string yellowGreen,
            string yellowYellow
            )
        {
            return new Scenario
            {
                Titel = titel,
                BlueBlue = blueBlue,
                BlueRed = blueRed,
                BlueGreen = blueGreen,
                BlueYellow = blueYellow,

                RedBlue = redBlue,
                RedRed = redRed,
                RedGreen = redGreen,
                RedYellow = redYellow,

                GreenBlue = greenBlue,
                GreenRed = greenRed,
                GreenGreen = greenGreen,
                GreenYellow = greenYellow,

                YellowBlue = yellowBlue,
                YellowRed = yellowRed,
                YellowGreen = yellowGreen,
                YellowYellow = yellowYellow

            };
        }

        protected Scenario()
        {
        }

        #endregion // Creation

        #region State Properties

        /// <summary>
        /// Gets/sets the ImageLinks's first name.  If this ImageLinks is a 
        /// company, this value stores the company's name.
        /// </summary>
        public string ImageLink { get; set; }

        #region ImageLinks
        public string BlueBlue { get; set; }
        public string BlueRed { get; set; }
        public string BlueGreen { get; set; }
        public string BlueYellow { get; set; }

        public string RedBlue { get; set; }
        public string RedRed { get; set; }
        public string RedGreen { get; set; }
        public string RedYellow { get; set; }

        public string GreenBlue { get; set; }
        public string GreenRed { get; set; }
        public string GreenGreen { get; set; }
        public string GreenYellow { get; set; }

        public string YellowBlue { get; set; }
        public string YellowRed { get; set; }
        public string YellowGreen { get; set; }
        public string YellowYellow { get; set; }


        #endregion

        /// <summary>
        /// Gets/sets the ImageLinks's first name.  If this ImageLinks is a 
        /// company, this value stores the company's name.
        /// </summary>
        public string Titel { get; set; }


        #endregion // State Properties

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error { get { return null; } }

        string IDataErrorInfo.this[string propertyName]
        {
            get { return this.GetValidationError(propertyName); }
        }

        #endregion // IDataErrorInfo Members

        #region Validation

        /// <summary>
        /// Returns true if this object has no validation errors.
        /// </summary>
        public bool IsValid
        {
            get
            {
                foreach (string property in ValidatedProperties)
                    if (GetValidationError(property) != null)
                        return false;

                return true;
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value == _isSelected)
                    return;

                _isSelected = value;

                this.OnPropertyChanged("IsSelected");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.VerifyPropertyName(propertyName);

            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        public void VerifyPropertyName(string propertyName)
        {
            // Verify that the property name matches a real,  
            // public, instance property on this object.
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = "Invalid property name: " + propertyName;

                if (this.ThrowOnInvalidPropertyName)
                    throw new Exception(msg);
                else
                    Debug.Fail(msg);
            }
        }

        protected virtual bool ThrowOnInvalidPropertyName { get; private set; }


        static readonly string[] ValidatedProperties =
        {
            "Titel"
        };

        string GetValidationError(string propertyName)
        {
            if (Array.IndexOf(ValidatedProperties, propertyName) < 0)
                return null;

            string error = null;

            switch (propertyName)
            {
                case "Titel":
                    error = this.ValidateTitel();
                    break;

                default:
                    Debug.Fail("Unexpected property being validated on ImageLinks: " + propertyName);
                    break;
            }

            return error;
        }

        private string ValidateImageLink()
        {
           return null;
        }

        string ValidateTitel()
        {
            if (IsStringMissing(this.Titel))
            {
                return Strings.Scenario_Error_MissingTitel;
            }
            return null;
        }

        static bool IsStringMissing(string value)
        {
            return
                String.IsNullOrEmpty(value) ||
                value.Trim() == String.Empty;
        }

        #endregion // Validation
    }
}

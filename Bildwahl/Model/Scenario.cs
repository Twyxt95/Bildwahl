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
        #region Creation

        public static Scenario CreateNewCustomer()
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

        static readonly string[] ValidatedProperties =
        {
            "imagelink"
        };

        string GetValidationError(string propertyName)
        {
            if (Array.IndexOf(ValidatedProperties, propertyName) < 0)
                return null;

            string error = null;

            switch (propertyName)
            {
                case "imagelink":
                    error = this.ValidateImageLink();
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

        static bool IsStringMissing(string value)
        {
            return
                String.IsNullOrEmpty(value) ||
                value.Trim() == String.Empty;
        }

        #endregion // Validation
    }
}

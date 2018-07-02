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
    public class ImageLinks : IDataErrorInfo
    {
        #region Creation

        public static ImageLinks CreateNewCustomer()
        {
            return new ImageLinks();
        }

        public static ImageLinks CreateImageLinks(
            string imageLink)
        {
            Console.WriteLine(imageLink);
            return new ImageLinks
            {

                ImageLink = imageLink
            };
        }

        protected ImageLinks()
        {
        }

        #endregion // Creation

        #region State Properties

        /// <summary>
        /// Gets/sets the ImageLinks's first name.  If this ImageLinks is a 
        /// company, this value stores the company's name.
        /// </summary>
        public string ImageLink { get; set; }


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

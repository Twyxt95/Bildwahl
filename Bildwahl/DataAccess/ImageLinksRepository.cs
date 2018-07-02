using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Resources;
using System.Xml;
using System.Xml.Linq;
using Bildwahl.Model;

namespace Bildwahl.DataAccess
{
    /// <summary>
    /// Represents a source of customers in the application.
    /// </summary>
    public class ImageLinksRepository
    {
        #region Fields

        readonly List<ImageLinks> _imageLinks;

        #endregion // Fields

        #region Constructor

        /// <summary>
        /// Creates a new repository of customers.
        /// </summary>
        /// <param name="customerDataFile">The relative path to an XML resource file that contains customer data.</param>
        public ImageLinksRepository(string customerDataFile)
        {
            _imageLinks = LoadCustomers(customerDataFile);
        }

        #endregion // Constructor

        #region Public Interface

        /// <summary>
        /// Raised when a customer is placed into the repository.
        /// </summary>
        public event EventHandler<ScenarioAddedEventArgs> ScenarioAdded;

        /// <summary>
        /// Places the specified customer into the repository.
        /// If the customer is already in the repository, an
        /// exception is not thrown.
        /// </summary>
        public void AddCustomer(ImageLinks customer)
        {
            if (customer == null)
                throw new ArgumentNullException("imagelink");

            if (!_imageLinks.Contains(customer))
            {
                _imageLinks.Add(customer);

                if (this.ScenarioAdded != null)
                    this.ScenarioAdded(this, new ScenarioAddedEventArgs(customer));
            }
        } 

        /// <summary>
        /// Returns true if the specified customer exists in the
        /// repository, or false if it is not.
        /// </summary>
        public bool ContainsCustomer(ImageLinks customer)
        {
            if (customer == null)
                throw new ArgumentNullException("imagelink");

            return _imageLinks.Contains(customer);
        }

        /// <summary>
        /// Returns a shallow-copied list of all customers in the repository.
        /// </summary>
        public List<ImageLinks> GetCustomers()
        {
            return new List<ImageLinks>(_imageLinks);
        }

        #endregion // Public Interface

        #region Private Helpers

        static List<ImageLinks> LoadCustomers(string customerDataFile)
        {
            // In a real application, the data would come from an external source,
            // but for this demo let's keep things simple and use a resource file.
            using (Stream stream = GetResourceStream(customerDataFile))
            using (XmlReader xmlRdr = new XmlTextReader(stream))
                return
                    (from customerElem in XDocument.Load(xmlRdr).Element("imagelinks").Elements("imagelink")
                     select ImageLinks.CreateImageLinks(
                        
                        (string)customerElem.Attribute("imagelink")

                         )).ToList();
        }

        static Stream GetResourceStream(string resourceFile)
        {
            Uri uri = new Uri(resourceFile, UriKind.RelativeOrAbsolute);

            StreamResourceInfo info = Application.GetResourceStream(uri);
            if (info == null || info.Stream == null)
                throw new ApplicationException("Missing resource file: " + resourceFile);

            return info.Stream;
        }

        #endregion // Private Helpers
    }
}

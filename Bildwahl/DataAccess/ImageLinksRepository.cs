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
        static string _customerDataFile;

        #endregion // Fields

        #region Constructor

        /// <summary>
        /// Creates a new repository of customers.
        /// </summary>
        /// <param name="customerDataFile">The relative path to an XML resource file that contains customer data.</param>
        public ImageLinksRepository(string customerDataFile)
        {
            _customerDataFile = customerDataFile;
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
            //if (customer == null)
              //  throw new ArgumentNullException("imagelink");

            //if (!_imageLinks.Contains(customer))
            //{
              //  _imageLinks.Add(customer);

              //  if (this.ScenarioAdded != null)
                    WriteScenario(customer.Titel,customer.ImageLink);
                //this.ScenarioAdded(this, new ScenarioAddedEventArgs(customer));
            //}
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
        public List<ImageLinks> GetCustomers(string scenario)
        {
            Console.WriteLine(scenario + " Look here");
            List<ImageLinks> unfilteredList = new List<ImageLinks>(_imageLinks);
            string test = unfilteredList.ElementAt(0).Titel;
            string test2 = unfilteredList.ElementAt(0).ImageLink;
            int index = unfilteredList.FindIndex(a => a.Titel == scenario);
            Console.WriteLine(test);
            Console.WriteLine(test2);
            Console.WriteLine(index + " Index");
            List<ImageLinks> filteredList= new List<ImageLinks>();
            filteredList.Add(unfilteredList.ElementAt(index));
            return filteredList;
        }

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
                    (from customerElem in XDocument.Load(xmlRdr).Element("imagelinks").Elements("scenario")
                     select ImageLinks.CreateImageLinks(
                        
                        (string)customerElem.Attribute("imagelink"),
                        (string)customerElem.Attribute("titel")

                         )).ToList();
        }

        static void WriteScenario(string titel, string imageLink)
        {

            //file name
            string filename = _customerDataFile;
            //create new instance of XmlDocument
            XmlDocument doc = new XmlDocument();
            Console.WriteLine(filename);
            //load from file
            doc.Load(@"C:\Users\Adrian\Documents\Bildwahl\Bildwahl\Bildwahl\"+ filename);

            //create node and add value
            XmlNode node = doc.CreateNode(XmlNodeType.Element, "scenario", null);
            XmlAttribute attribute = doc.CreateAttribute("titel"); // create attribute
            attribute.Value = titel; //set the appropriate value
            node.Attributes.Append(attribute); // add the attribute to node

            XmlAttribute attributeImageLink = doc.CreateAttribute("imagelink"); // create attribute
            attributeImageLink.Value =imageLink; //set the appropriate value
            node.Attributes.Append(attributeImageLink); // add the attribute to node
            //node.InnerText = "this is new node";

            //create title node
            //XmlNode nodeTitle = doc.CreateElement("Title");
            //add value for it
            //nodeTitle.InnerText = "dritter";

            //create Url node
            //XmlNode nodeUrl = doc.CreateElement("Imagelink");
            //nodeUrl.InnerText = "test";

            //add to parent node
            //node.AppendChild(nodeTitle);
            //node.AppendChild(nodeUrl);

            //add to elements collection
            doc.DocumentElement.AppendChild(node);

            //save back
            doc.Save(@"C:\Users\Adrian\Documents\Bildwahl\Bildwahl\Bildwahl\"+filename);
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

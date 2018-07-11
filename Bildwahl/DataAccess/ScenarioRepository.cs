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
    public class ScenarioRepository
    {
        #region Fields

        List<Scenario> _imageLinks;
        static string _customerDataFile;

        #endregion // Fields

        #region Constructor

        /// <summary>
        /// Creates a new repository of customers.
        /// </summary>
        /// <param name="customerDataFile">The relative path to an XML resource file that contains customer data.</param>
        public ScenarioRepository(string customerDataFile)
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

        public event EventHandler<ScenarioDeletedEventArgs> ScenarioDeleted;

        /// <summary>
        /// Places the specified customer into the repository.
        /// If the customer is already in the repository, an
        /// exception is not thrown.
        /// </summary>
        public void AddCustomer(Scenario customer)
        {
            //if (customer == null)
            //  throw new ArgumentNullException("imagelink");

            if (!_imageLinks.Contains(customer))
            {
                _imageLinks.Add(customer);
            }
              //  if (this.ScenarioAdded != null)
            WriteScenario(
                customer.Titel,
                customer.BlueBlue,
                customer.BlueRed,
                customer.BlueGreen,
                customer.BlueYellow,
                customer.RedBlue,
                customer.RedRed,
                customer.RedGreen,
                customer.RedYellow,
                customer.GreenBlue,
                customer.GreenRed,
                customer.GreenGreen,
                customer.GreenYellow,
                customer.YellowBlue,
                customer.YellowRed,
                customer.YellowGreen,
                customer.YellowYellow
                );

            this.ScenarioAdded(this, new ScenarioAddedEventArgs(customer));

            //}
        } 

        public void DeleteScenario(Scenario scenario)
        {
            DeleteScenarioXml(scenario.Titel);
            this.ScenarioDeleted(this, new ScenarioDeletedEventArgs(scenario));
            
        }

        /// <summary>
        /// Returns true if the specified customer exists in the
        /// repository, or false if it is not.
        /// </summary>
        public bool ContainsCustomer(Scenario customer)
        {
            if (customer == null)
                throw new ArgumentNullException("imagelink");

            return _imageLinks.Contains(customer);
        }

        /// <summary>
        /// Returns a shallow-copied list of all customers in the repository.
        /// </summary>
        public List<Scenario> GetCustomers(string scenario)
        {
            List<Scenario> unfilteredList = new List<Scenario>(_imageLinks);
            int index = unfilteredList.FindIndex(a => a.Titel == scenario);
            List<Scenario> filteredList= new List<Scenario>();
            filteredList.Add(unfilteredList.ElementAt(index));
            return filteredList;
        }

        public List<Scenario> GetCustomers()
        {
            
            return new List<Scenario>(_imageLinks);
        }

        #endregion // Public Interface

        #region Private Helpers

        static List<Scenario> LoadCustomers(string customerDataFile)
        {
            // In a real application, the data would come from an external source,
            // but for this demo let's keep things simple and use a resource file.
            Console.WriteLine("LOADED");
            using (Stream stream = GetResourceStream(customerDataFile))
            using (XmlReader xmlRdr = new XmlTextReader(stream))
                return
                    (from customerElem in XDocument.Load(xmlRdr).Element("imagelinks").Elements("scenario")
                     select Scenario.CreateImageLinks(
                        (string)customerElem.Attribute("titel"),
                        (string)customerElem.Attribute("blueblue"),
                        (string)customerElem.Attribute("bluered"),
                        (string)customerElem.Attribute("bluegreen"),
                        (string)customerElem.Attribute("blueyellow"),

                        (string)customerElem.Attribute("redblue"),
                        (string)customerElem.Attribute("redred"),
                        (string)customerElem.Attribute("redgreen"),
                        (string)customerElem.Attribute("redyellow"),

                        (string)customerElem.Attribute("greenblue"),
                        (string)customerElem.Attribute("greenred"),
                        (string)customerElem.Attribute("greengreen"),
                        (string)customerElem.Attribute("greenyellow"),

                        (string)customerElem.Attribute("yellowblue"),
                        (string)customerElem.Attribute("yellowred"),
                        (string)customerElem.Attribute("yellowgreen"),
                        (string)customerElem.Attribute("yellowyellow")
                         )).ToList();
        }

        static void WriteScenario(
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

            XmlAttribute attributeBlueBlue = doc.CreateAttribute("blueblue"); // create attribute
            attributeBlueBlue.Value = blueBlue; //set the appropriate value
            node.Attributes.Append(attributeBlueBlue); // add the attribute to node
            XmlAttribute attributeBlueRed = doc.CreateAttribute("bluered"); // create attribute
            attributeBlueRed.Value = blueRed; //set the appropriate value
            node.Attributes.Append(attributeBlueRed); // add the attribute to node
            XmlAttribute attributeBlueGreen = doc.CreateAttribute("bluegreen"); // create attribute
            attributeBlueGreen.Value = blueGreen; //set the appropriate value
            node.Attributes.Append(attributeBlueGreen); // add the attribute to node
            XmlAttribute attributeBlueYellow = doc.CreateAttribute("blueyellow"); // create attribute
            attributeBlueYellow.Value = blueYellow; //set the appropriate value
            node.Attributes.Append(attributeBlueYellow); // add the attribute to node

            XmlAttribute attributeRedBlue = doc.CreateAttribute("redblue"); // create attribute
            attributeRedBlue.Value = redBlue; //set the appropriate value
            node.Attributes.Append(attributeRedBlue); // add the attribute to node
            XmlAttribute attributeRedRed = doc.CreateAttribute("redred"); // create attribute
            attributeRedRed.Value = redRed; //set the appropriate value
            node.Attributes.Append(attributeRedRed); // add the attribute to node
            XmlAttribute attributeRedGreen = doc.CreateAttribute("redgreen"); // create attribute
            attributeRedGreen.Value = redGreen; //set the appropriate value
            node.Attributes.Append(attributeRedGreen); // add the attribute to node
            XmlAttribute attributeRedYellow = doc.CreateAttribute("redyellow"); // create attribute
            attributeRedYellow.Value = redYellow; //set the appropriate value
            node.Attributes.Append(attributeRedYellow); // add the attribute to node

            XmlAttribute attributeGreenBlue = doc.CreateAttribute("greenblue"); // create attribute
            attributeGreenBlue.Value = greenBlue; //set the appropriate value
            node.Attributes.Append(attributeGreenBlue); // add the attribute to node
            XmlAttribute attributeGreenRed = doc.CreateAttribute("greenred"); // create attribute
            attributeGreenRed.Value = greenRed; //set the appropriate value
            node.Attributes.Append(attributeGreenRed); // add the attribute to node
            XmlAttribute attributeGreenGreen = doc.CreateAttribute("greengreen"); // create attribute
            attributeGreenGreen.Value = greenGreen; //set the appropriate value
            node.Attributes.Append(attributeGreenGreen); // add the attribute to node
            XmlAttribute attributeGreenYellow = doc.CreateAttribute("greenyellow"); // create attribute
            attributeGreenYellow.Value = greenYellow; //set the appropriate value
            node.Attributes.Append(attributeGreenYellow); // add the attribute to node

            XmlAttribute attributeYellowBlue = doc.CreateAttribute("yellowblue"); // create attribute
            attributeYellowBlue.Value = yellowBlue; //set the appropriate value
            node.Attributes.Append(attributeYellowBlue); // add the attribute to node
            XmlAttribute attributeYellowRed = doc.CreateAttribute("yellowred"); // create attribute
            attributeYellowRed.Value = yellowRed; //set the appropriate value
            node.Attributes.Append(attributeYellowRed); // add the attribute to node
            XmlAttribute attributeYellowGreen = doc.CreateAttribute("yellowgreen"); // create attribute
            attributeYellowGreen.Value = yellowGreen; //set the appropriate value
            node.Attributes.Append(attributeYellowGreen); // add the attribute to node
            XmlAttribute attributeYellowYellow = doc.CreateAttribute("yellowyellow"); // create attribute
            attributeYellowYellow.Value = yellowYellow; //set the appropriate value
            node.Attributes.Append(attributeYellowYellow); // add the attribute to node


            //add to elements collection
            doc.DocumentElement.AppendChild(node);

            //save back
            doc.Save(@"C:\Users\Adrian\Documents\Bildwahl\Bildwahl\Bildwahl\"+filename);
        }

        static void DeleteScenarioXml(string titel)
        {
            string filename = "Data/scenario.xml";
            //create new instance of XmlDocument
            XmlDocument doc = new XmlDocument();
            Console.WriteLine(filename);
            //load from file
            doc.Load(@"C:\Users\Adrian\Documents\Bildwahl\Bildwahl\Bildwahl\" + filename);
            XmlNodeList node= doc.SelectNodes("//scenario[@titel='" + titel + "']");
            //doc.SelectSingleNode("imagelinks");
            doc.SelectSingleNode("imagelinks").RemoveChild(node.Item(0));
            //save back
            doc.Save(@"C:\Users\Adrian\Documents\Bildwahl\Bildwahl\Bildwahl\" + filename);
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

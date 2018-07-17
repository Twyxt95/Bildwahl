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
    /// Represents a source of scenarios in the application.
    /// </summary>
    public class ScenarioRepository
    {
        #region Fields

        List<Scenario> _scenarios;
        static string _scenarioDataFile;

        #endregion // Fields

        #region Constructor

        /// <summary>
        /// Creates a new repository of scenarios.
        /// </summary>
        /// <param name="scenarioDataFile">The relative path to an XML resource file that contains scenario data.</param>
        public ScenarioRepository(string scenarioDataFile)
        {
            _scenarioDataFile = scenarioDataFile;
            _scenarios = LoadScenarios(scenarioDataFile);
            
        }

        #endregion // Constructor

        #region Public Interface

        /// <summary>
        /// Raised when a scenario is placed into the repository.
        /// </summary>
        public event EventHandler<ScenarioAddedEventArgs> ScenarioAdded;

        public event EventHandler<ScenarioDeletedEventArgs> ScenarioDeleted;

        /// <summary>
        /// Places the specified scenario into the repository.
        /// If the scenario is already in the repository, an
        /// exception is not thrown.
        /// </summary>
        public void AddScenario(Scenario scenario)
        {
            if (!_scenarios.Contains(scenario))
            {
                _scenarios.Add(scenario);
            }
            WriteScenario(
                scenario.Titel,
                scenario.BlueBlue,
                scenario.BlueRed,
                scenario.BlueGreen,
                scenario.BlueYellow,
                scenario.RedBlue,
                scenario.RedRed,
                scenario.RedGreen,
                scenario.RedYellow,
                scenario.GreenBlue,
                scenario.GreenRed,
                scenario.GreenGreen,
                scenario.GreenYellow,
                scenario.YellowBlue,
                scenario.YellowRed,
                scenario.YellowGreen,
                scenario.YellowYellow
                );

            this.ScenarioAdded(this, new ScenarioAddedEventArgs(scenario));
        } 

        public void DeleteScenario(Scenario scenario)
        {
            DeleteScenarioXml(scenario.Titel);
            this.ScenarioDeleted(this, new ScenarioDeletedEventArgs(scenario));
            
        }

        /// <summary>
        /// Returns true if the specified scenario exists in the
        /// repository, or false if it is not.
        /// </summary>
        public bool ContainsScenario(Scenario scenario)
        {
            if (scenario == null)
                throw new ArgumentNullException("scenario");

            return _scenarios.Contains(scenario);
        }

        /// <summary>
        /// Returns a shallow-copied list of all scenarios in the repository.
        /// </summary>
        public Scenario GetScenarios(string scenario)
        {
            List<Scenario> unfilteredList = new List<Scenario>(_scenarios);
            int index = unfilteredList.FindIndex(a => a.Titel == scenario);
            Scenario filteredList= unfilteredList.ElementAt(index);
            return filteredList;
        }

        public List<Scenario> GetScenarios()
        {
            
            return new List<Scenario>(_scenarios);
        }

        #endregion // Public Interface

        #region Private Helpers

        static List<Scenario> LoadScenarios(string scenarioDataFile)
        {
            // In a real application, the data would come from an external source,
            // but for this demo let's keep things simple and use a resource file.
            Console.WriteLine("LOADED");
            using (Stream stream = GetResourceStream(scenarioDataFile))
            using (XmlReader xmlRdr = new XmlTextReader(stream))
                return
                    (from scenarioElem in XDocument.Load(xmlRdr).Element("imagelinks").Elements("scenario")
                     select Scenario.CreateImageLinks(
                        (string)scenarioElem.Attribute("titel"),
                        (string)scenarioElem.Attribute("blueblue"),
                        (string)scenarioElem.Attribute("bluered"),
                        (string)scenarioElem.Attribute("bluegreen"),
                        (string)scenarioElem.Attribute("blueyellow"),

                        (string)scenarioElem.Attribute("redblue"),
                        (string)scenarioElem.Attribute("redred"),
                        (string)scenarioElem.Attribute("redgreen"),
                        (string)scenarioElem.Attribute("redyellow"),

                        (string)scenarioElem.Attribute("greenblue"),
                        (string)scenarioElem.Attribute("greenred"),
                        (string)scenarioElem.Attribute("greengreen"),
                        (string)scenarioElem.Attribute("greenyellow"),

                        (string)scenarioElem.Attribute("yellowblue"),
                        (string)scenarioElem.Attribute("yellowred"),
                        (string)scenarioElem.Attribute("yellowgreen"),
                        (string)scenarioElem.Attribute("yellowyellow")
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
            string filename = _scenarioDataFile;
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

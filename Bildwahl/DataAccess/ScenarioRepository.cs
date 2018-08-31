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
            Console.WriteLine("LOADED");
            string directory = System.AppDomain.CurrentDomain.BaseDirectory;
            //string directory = System.AppDomain.CurrentDomain.BaseDirectory;
            //using (Stream stream = GetResourceStream("../"+scenarioDataFile))
            // using (XmlReader xmlRdr = new XmlTextReader(stream))
            //(from scenarioElem in XDocument.Load(xmlRdr).Element("imagelinks").Elements("scenario")
            return
                    (from scenarioElem in XDocument.Load(scenarioDataFile).Element("imagelinks").Elements("scenario")
                     select Scenario.CreateImageLinks(
                        (string)scenarioElem.Attribute("titel"),
                        directory+"//Pictures//"+
                        (string)scenarioElem.Attribute("blueblue"),
                        directory + "//Pictures//" +
                        (string)scenarioElem.Attribute("bluered"),
                        directory + "//Pictures//" +
                        (string)scenarioElem.Attribute("bluegreen"),
                        directory + "//Pictures//" +
                        (string)scenarioElem.Attribute("blueyellow"),

                        directory + "//Pictures//" +
                        (string)scenarioElem.Attribute("redblue"),
                        directory + "//Pictures//" +
                        (string)scenarioElem.Attribute("redred"),
                        directory + "//Pictures//" +
                        (string)scenarioElem.Attribute("redgreen"),
                        directory + "//Pictures//" +
                        (string)scenarioElem.Attribute("redyellow"),

                        directory + "//Pictures//" +
                        (string)scenarioElem.Attribute("greenblue"),
                        directory + "//Pictures//" +
                        (string)scenarioElem.Attribute("greenred"),
                        directory + "//Pictures//" +
                        (string)scenarioElem.Attribute("greengreen"),
                        directory + "//Pictures//" +
                        (string)scenarioElem.Attribute("greenyellow"),

                        directory + "//Pictures//" +
                        (string)scenarioElem.Attribute("yellowblue"),
                        directory + "//Pictures//" +
                        (string)scenarioElem.Attribute("yellowred"),
                        directory + "//Pictures//" +
                        (string)scenarioElem.Attribute("yellowgreen"),
                        directory + "//Pictures//" +
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
            //doc.Load(@"C:\Users\Adrian\Documents\Bildwahl\Bildwahl\Bildwahl\"+ filename);
            string directory = System.AppDomain.CurrentDomain.BaseDirectory;
            doc.Load(directory + filename);

            //create node and add value
            XmlNode node = doc.CreateNode(XmlNodeType.Element, "scenario", null);
            XmlAttribute attribute = doc.CreateAttribute("titel"); // create attribute
            attribute.Value = titel; //set the appropriate value
            node.Attributes.Append(attribute); // add the attribute to node

            string[] splittedPath;

            XmlAttribute attributeBlueBlue = doc.CreateAttribute("blueblue"); // create attribute
            splittedPath = blueBlue.Split('\\');
            attributeBlueBlue.Value = splittedPath[splittedPath.Length - 1]; //set the appropriate value
            node.Attributes.Append(attributeBlueBlue); // add the attribute to node
            XmlAttribute attributeBlueRed = doc.CreateAttribute("bluered"); // create attribute
            splittedPath = blueRed.Split('\\');
            attributeBlueRed.Value = splittedPath[splittedPath.Length - 1]; //set the appropriate value
            node.Attributes.Append(attributeBlueRed); // add the attribute to node
            XmlAttribute attributeBlueGreen = doc.CreateAttribute("bluegreen"); // create attribute
            splittedPath = blueGreen.Split('\\');
            attributeBlueGreen.Value = splittedPath[splittedPath.Length - 1]; //set the appropriate value
            node.Attributes.Append(attributeBlueGreen); // add the attribute to node
            XmlAttribute attributeBlueYellow = doc.CreateAttribute("blueyellow"); // create attribute
            splittedPath = blueYellow.Split('\\');
            attributeBlueYellow.Value = splittedPath[splittedPath.Length - 1];  //set the appropriate value
            node.Attributes.Append(attributeBlueYellow); // add the attribute to node

            XmlAttribute attributeRedBlue = doc.CreateAttribute("redblue"); // create attribute
            splittedPath = redBlue.Split('\\');
            attributeRedBlue.Value = splittedPath[splittedPath.Length - 1]; //set the appropriate value
            node.Attributes.Append(attributeRedBlue); // add the attribute to node
            XmlAttribute attributeRedRed = doc.CreateAttribute("redred"); // create attribute
            splittedPath = redRed.Split('\\');
            attributeRedRed.Value = splittedPath[splittedPath.Length - 1]; //set the appropriate value
            node.Attributes.Append(attributeRedRed); // add the attribute to node
            XmlAttribute attributeRedGreen = doc.CreateAttribute("redgreen"); // create attribute
            splittedPath = redGreen.Split('\\');
            attributeRedGreen.Value = splittedPath[splittedPath.Length - 1]; //set the appropriate value
            node.Attributes.Append(attributeRedGreen); // add the attribute to node
            XmlAttribute attributeRedYellow = doc.CreateAttribute("redyellow"); // create attribute
            splittedPath = redYellow.Split('\\');
            attributeRedYellow.Value = splittedPath[splittedPath.Length - 1]; //set the appropriate value
            node.Attributes.Append(attributeRedYellow); // add the attribute to node

            XmlAttribute attributeGreenBlue = doc.CreateAttribute("greenblue"); // create attribute
            splittedPath = greenBlue.Split('\\');
            attributeGreenBlue.Value = splittedPath[splittedPath.Length - 1]; //set the appropriate value
            node.Attributes.Append(attributeGreenBlue); // add the attribute to node
            XmlAttribute attributeGreenRed = doc.CreateAttribute("greenred"); // create attribute
            splittedPath = greenRed.Split('\\');
            attributeGreenRed.Value = splittedPath[splittedPath.Length - 1]; //set the appropriate value
            node.Attributes.Append(attributeGreenRed); // add the attribute to node
            XmlAttribute attributeGreenGreen = doc.CreateAttribute("greengreen"); // create attribute
            splittedPath = greenGreen.Split('\\');
            attributeGreenGreen.Value = splittedPath[splittedPath.Length - 1]; //set the appropriate value
            node.Attributes.Append(attributeGreenGreen); // add the attribute to node
            XmlAttribute attributeGreenYellow = doc.CreateAttribute("greenyellow"); // create attribute
            splittedPath = greenYellow.Split('\\');
            attributeGreenYellow.Value = splittedPath[splittedPath.Length - 1]; //set the appropriate value
            node.Attributes.Append(attributeGreenYellow); // add the attribute to node

            XmlAttribute attributeYellowBlue = doc.CreateAttribute("yellowblue"); // create attribute
            splittedPath = yellowBlue.Split('\\');
            attributeYellowBlue.Value = splittedPath[splittedPath.Length - 1]; //set the appropriate value
            node.Attributes.Append(attributeYellowBlue); // add the attribute to node
            XmlAttribute attributeYellowRed = doc.CreateAttribute("yellowred"); // create attribute
            splittedPath = yellowRed.Split('\\');
            attributeYellowRed.Value = splittedPath[splittedPath.Length - 1]; //set the appropriate value
            node.Attributes.Append(attributeYellowRed); // add the attribute to node
            XmlAttribute attributeYellowGreen = doc.CreateAttribute("yellowgreen"); // create attribute
            splittedPath = yellowGreen.Split('\\');
            attributeYellowGreen.Value = splittedPath[splittedPath.Length - 1]; //set the appropriate value
            node.Attributes.Append(attributeYellowGreen); // add the attribute to node
            XmlAttribute attributeYellowYellow = doc.CreateAttribute("yellowyellow"); // create attribute
            splittedPath = yellowYellow.Split('\\');
            attributeYellowYellow.Value = splittedPath[splittedPath.Length - 1]; //set the appropriate value
            node.Attributes.Append(attributeYellowYellow); // add the attribute to node


            //add to elements collection
            doc.DocumentElement.AppendChild(node);

            //save back
            doc.Save(directory+filename);
            //doc.Save(@"C:\Users\Adrian\Documents\Bildwahl\Bildwahl\Bildwahl\" + filename);
        }

        static void DeleteScenarioXml(string titel)
        {
            string filename = _scenarioDataFile;
            //create new instance of XmlDocument
            XmlDocument doc = new XmlDocument();
            string directory = System.AppDomain.CurrentDomain.BaseDirectory;
            //load from file
            //doc.Load(@"C:\Users\Adrian\Documents\Bildwahl\Bildwahl\Bildwahl\" + filename);
            doc.Load(directory + filename);
            XmlNodeList node= doc.SelectNodes("//scenario[@titel='" + titel + "']");
            //doc.SelectSingleNode("imagelinks");
            doc.SelectSingleNode("imagelinks").RemoveChild(node.Item(0));
            //save back
            //doc.Save(@"C:\Users\Adrian\Documents\Bildwahl\Bildwahl\Bildwahl\" + filename);
            doc.Save(directory + filename);
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

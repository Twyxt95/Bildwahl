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
    /// <summary> Stellt die Quelle für alle Szenarios in der Anwendung dar </summary>
    public class ScenarioRepository
    {
        #region Fields
        /// <summary> Alle Szenarien </summary>
        List<Scenario> _scenarios;
        /// <summary> Pfad zum Speicherort einer XML-Datei mit den Szenarien </summary>
        static string _scenarioDataFile;

        #endregion // Fields

        #region Constructor

        /// <summary> Konstruktor </summary>
        /// <param name="scenarioDataFile"> Pfad zum Speicherort einer XML-Datei mit den Szenarien </param>
        public ScenarioRepository(string scenarioDataFile)
        {
            _scenarioDataFile = scenarioDataFile;
            _scenarios = LoadScenarios(scenarioDataFile);
            
        }

        #endregion // Constructor

        #region Public Interface

        /// <summary> Ausgelöst, wenn ein Szenario hinzugefügt wird </summary>
        public event EventHandler<ScenarioAddedEventArgs> ScenarioAdded;

        /// <summary> Ausgelöst, wenn ein Szenario entfernt wird </summary>
        public event EventHandler<ScenarioDeletedEventArgs> ScenarioDeleted;

        /// <summary> Fügt ein Szenario dem Verzeichnis hinzu </summary>
        /// <param name="scenario"> Szenario das hinzugefügt werden soll </param>
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

        /// <summary> Entfernt ein Szenario aus dem Verzeichnis </summary>
        /// <param name="scenario"> Szenario das entfernt werden soll </param>
        public void DeleteScenario(Scenario scenario)
        {
            DeleteScenarioXml(scenario.Titel);
            this.ScenarioDeleted(this, new ScenarioDeletedEventArgs(scenario));
        }

        /// <summary> Ob das Szenario im Verzeichnis vorhanden ist </summary>
        public bool ContainsScenario(Scenario scenario)
        {
            if (scenario == null)
                throw new ArgumentNullException("scenario");

            return _scenarios.Contains(scenario);
        }

        /// <summary> Gibt ein bestimmtes Szenario zurück </summary>
        /// <param name="scenario"> Titel des Szenarios, das zurückgegeben werden soll </param>
        public Scenario GetScenarios(string scenario)
        {
            List<Scenario> unfilteredList = new List<Scenario>(_scenarios);
            int index = unfilteredList.FindIndex(a => a.Titel == scenario);
            Scenario filteredList= unfilteredList.ElementAt(index);
            return filteredList;
        }

        /// <summary> Gibt eine Liste mit allen Szenarien zurück </summary>
        public List<Scenario> GetScenarios()
        {
            return new List<Scenario>(_scenarios);
        }

        #endregion // Public Interface

        #region Private Helpers

        /// <summary> Läd alle Szenarien aus der XML-Datei </summary>
        /// <param name="scenarioDataFile"> Pfad zum Speicherort einer XML-Datei mit den Szenarien </param>
        static List<Scenario> LoadScenarios(string scenarioDataFile)
        {
            string directory = System.AppDomain.CurrentDomain.BaseDirectory;
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

        /// <summary> Speichert ein Szenario in der XML-Datei</summary>
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
            string filename = _scenarioDataFile;
            XmlDocument doc = new XmlDocument();
            string directory = System.AppDomain.CurrentDomain.BaseDirectory;
            doc.Load(directory + filename);

            XmlNode node = doc.CreateNode(XmlNodeType.Element, "scenario", null);
            XmlAttribute attribute = doc.CreateAttribute("titel"); 
            attribute.Value = titel; 
            node.Attributes.Append(attribute); 

            string[] splittedPath;

            XmlAttribute attributeBlueBlue = doc.CreateAttribute("blueblue");
            if (!IsStringMissing(blueBlue))
            {
                splittedPath = blueBlue.Split('\\');            
                attributeBlueBlue.Value = splittedPath[splittedPath.Length - 1];
            }
            node.Attributes.Append(attributeBlueBlue);
            XmlAttribute attributeBlueRed = doc.CreateAttribute("bluered");
            if (!IsStringMissing(blueRed))
            {
                splittedPath = blueRed.Split('\\');
                attributeBlueRed.Value = splittedPath[splittedPath.Length - 1];
            }
            node.Attributes.Append(attributeBlueRed); 
            XmlAttribute attributeBlueGreen = doc.CreateAttribute("bluegreen");
            if (!IsStringMissing(blueGreen))
            {
                splittedPath = blueGreen.Split('\\');
                attributeBlueGreen.Value = splittedPath[splittedPath.Length - 1];
            }
            node.Attributes.Append(attributeBlueGreen); 
            XmlAttribute attributeBlueYellow = doc.CreateAttribute("blueyellow");
            if (!IsStringMissing(blueYellow))
            {
                splittedPath = blueYellow.Split('\\');
                attributeBlueYellow.Value = splittedPath[splittedPath.Length - 1];
            }
            node.Attributes.Append(attributeBlueYellow); 

            XmlAttribute attributeRedBlue = doc.CreateAttribute("redblue");
            if (!IsStringMissing(redBlue))
            {
                splittedPath = redBlue.Split('\\');
                attributeRedBlue.Value = splittedPath[splittedPath.Length - 1];
            }
            node.Attributes.Append(attributeRedBlue); 
            XmlAttribute attributeRedRed = doc.CreateAttribute("redred");
            if (!IsStringMissing(redRed))
            {
                splittedPath = redRed.Split('\\');
                attributeRedRed.Value = splittedPath[splittedPath.Length - 1];
            }
            node.Attributes.Append(attributeRedRed); 
            XmlAttribute attributeRedGreen = doc.CreateAttribute("redgreen");
            if (!IsStringMissing(redGreen))
            {
                splittedPath = redGreen.Split('\\');
                attributeRedGreen.Value = splittedPath[splittedPath.Length - 1];
            }
            node.Attributes.Append(attributeRedGreen);
            XmlAttribute attributeRedYellow = doc.CreateAttribute("redyellow");
            if (!IsStringMissing(redYellow))
            {
                splittedPath = redYellow.Split('\\');
                attributeRedYellow.Value = splittedPath[splittedPath.Length - 1];
            }
            node.Attributes.Append(attributeRedYellow); 

            XmlAttribute attributeGreenBlue = doc.CreateAttribute("greenblue");
            if (!IsStringMissing(greenBlue))
            {
                splittedPath = greenBlue.Split('\\');
                attributeGreenBlue.Value = splittedPath[splittedPath.Length - 1];
            }
            node.Attributes.Append(attributeGreenBlue);
            XmlAttribute attributeGreenRed = doc.CreateAttribute("greenred");
            if (!IsStringMissing(greenRed))
            {
                splittedPath = greenRed.Split('\\');
                attributeGreenRed.Value = splittedPath[splittedPath.Length - 1];
            }
            node.Attributes.Append(attributeGreenRed); 
            XmlAttribute attributeGreenGreen = doc.CreateAttribute("greengreen");
            if (!IsStringMissing(greenGreen))
            {
                splittedPath = greenGreen.Split('\\');
                attributeGreenGreen.Value = splittedPath[splittedPath.Length - 1];
            }
            node.Attributes.Append(attributeGreenGreen);
            XmlAttribute attributeGreenYellow = doc.CreateAttribute("greenyellow");
            if (!IsStringMissing(greenYellow))
            {
                splittedPath = greenYellow.Split('\\');
                attributeGreenYellow.Value = splittedPath[splittedPath.Length - 1];
            }
            node.Attributes.Append(attributeGreenYellow); 

            XmlAttribute attributeYellowBlue = doc.CreateAttribute("yellowblue");
            if (!IsStringMissing(yellowBlue))
            {
                splittedPath = yellowBlue.Split('\\');
                attributeYellowBlue.Value = splittedPath[splittedPath.Length - 1];
            }
            node.Attributes.Append(attributeYellowBlue); 
            XmlAttribute attributeYellowRed = doc.CreateAttribute("yellowred");
            if (!IsStringMissing(yellowRed))
            {
                splittedPath = yellowRed.Split('\\');
                attributeYellowRed.Value = splittedPath[splittedPath.Length - 1];
            }
            node.Attributes.Append(attributeYellowRed); 
            XmlAttribute attributeYellowGreen = doc.CreateAttribute("yellowgreen");
            if (!IsStringMissing(yellowGreen))
            {
                splittedPath = yellowGreen.Split('\\');
                attributeYellowGreen.Value = splittedPath[splittedPath.Length - 1];
            }
            node.Attributes.Append(attributeYellowGreen); 
            XmlAttribute attributeYellowYellow = doc.CreateAttribute("yellowyellow");
            if (!IsStringMissing(yellowYellow))
            {
                splittedPath = yellowYellow.Split('\\');
                attributeYellowYellow.Value = splittedPath[splittedPath.Length - 1];
            }
            node.Attributes.Append(attributeYellowYellow); 

            doc.DocumentElement.AppendChild(node);

            doc.Save(directory+filename);
        }

        /// <summary> Löscht ein bestimmtes Szenario aus der XML-Datei </summary>
        /// <param name="titel"> Titel des Szenarios, das gelöscht werden soll </param>
        static void DeleteScenarioXml(string titel)
        {
            string filename = _scenarioDataFile;
            XmlDocument doc = new XmlDocument();
            string directory = System.AppDomain.CurrentDomain.BaseDirectory;
            doc.Load(directory + filename);
            XmlNodeList node= doc.SelectNodes("//scenario[@titel='" + titel + "']");
            doc.SelectSingleNode("imagelinks").RemoveChild(node.Item(0));
            doc.Save(directory + filename);
        }

        /// <summary> Überprüft ob ein String existiert </summary>
        /// /// <param name="value">STring der überprüft werden soll</param>
        static bool IsStringMissing(string value)
        {
            return
                String.IsNullOrEmpty(value) ||
                value.Trim() == String.Empty;
        }
        #endregion // Private Helpers
    }
}

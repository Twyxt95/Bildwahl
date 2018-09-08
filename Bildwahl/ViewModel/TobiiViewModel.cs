using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Bildwahl.DataAccess;
using Bildwahl.Model;
using Bildwahl.Properties;
using Tobii.Interaction.Wpf;

namespace Bildwahl.ViewModel
{
    /// <summary> Das ViewModel für das Durchführen eines Szenarios </summary>
    public class TobiiViewModel : WorkspaceViewModel
    {
        /// <summary> Verzeichnis für alle Szenarien </summary>
        readonly ScenarioRepository _scenarioRepository;

        /// <summary> Das aktuelle Szenario </summary>
        Scenario scenario;

        /// <summary> Konstruktor </summary>
        /// <param name="scenarioRepository"> Verzeichnis für alle Szenarien </param>
        /// <param name="scenarioName"> Titel des Szenarios </param>
        public TobiiViewModel(ScenarioRepository scenarioRepository, string scenarioName)
        {
            base.DisplayName = Strings.TobiiViewModel_DisplayName;

            _scenarioRepository = scenarioRepository ?? throw new ArgumentNullException("scenarioRepository");
            scenario = _scenarioRepository.GetScenarios(scenarioName);
        }

        #region ImageLinks
        /// Bilder die angezeigt werden
        public string BlueBlue
        {
            get { return scenario.BlueBlue; }
            set
            {
                if (value == scenario.BlueBlue)
                    return;

                scenario.BlueBlue = value;

                base.OnPropertyChanged("BlueBlue");
            }
        }
        public string BlueRed
        {
            get { return scenario.BlueRed; }
            set
            {
                if (value == scenario.BlueRed)
                    return;

                scenario.BlueRed = value;

                base.OnPropertyChanged("BlueRed");
            }
        }
        public string BlueGreen
        {
            get { return scenario.BlueGreen; }
            set
            {
                if (value == scenario.BlueGreen)
                    return;

                scenario.BlueGreen = value;

                base.OnPropertyChanged("BlueGreen");
            }
        }
        public string BlueYellow
        {
            get { return scenario.BlueYellow; }
            set
            {
                if (value == scenario.BlueYellow)
                    return;

                scenario.BlueYellow = value;

                base.OnPropertyChanged("BlueYellow");
            }
        }

        public string RedBlue
        {
            get { return scenario.RedBlue; }
            set
            {
                if (value == scenario.RedBlue)
                    return;

                scenario.RedBlue = value;

                base.OnPropertyChanged("RedBlue");
            }
        }
        public string RedRed
        {
            get { return scenario.RedRed; }
            set
            {
                if (value == scenario.RedRed)
                    return;

                scenario.RedRed = value;

                base.OnPropertyChanged("RedRed");
            }
        }
        public string RedGreen
        {
            get { return scenario.RedGreen; }
            set
            {
                if (value == scenario.RedGreen)
                    return;

                scenario.RedGreen = value;

                base.OnPropertyChanged("RedGreen");
            }
        }
        public string RedYellow
        {
            get { return scenario.RedYellow; }
            set
            {
                if (value == scenario.RedYellow)
                    return;

                scenario.RedYellow = value;

                base.OnPropertyChanged("RedYellow");
            }
        }

        public string GreenBlue
        {
            get { return scenario.GreenBlue; }
            set
            {
                if (value == scenario.GreenBlue)
                    return;

                scenario.GreenBlue = value;

                base.OnPropertyChanged("GreenBlue");
            }
        }
        public string GreenRed
        {
            get { return scenario.GreenRed; }
            set
            {
                if (value == scenario.GreenRed)
                    return;

                scenario.GreenRed = value;

                base.OnPropertyChanged("GreenRed");
            }
        }
        public string GreenGreen
        {
            get { return scenario.GreenGreen; }
            set
            {
                if (value == scenario.GreenGreen)
                    return;

                scenario.GreenGreen = value;

                base.OnPropertyChanged("GreenGreen");
            }
        }
        public string GreenYellow
        {
            get { return scenario.GreenYellow; }
            set
            {
                if (value == scenario.GreenYellow)
                    return;

                scenario.GreenYellow = value;

                base.OnPropertyChanged("GreenYellow");
            }
        }

        public string YellowBlue
        {
            get { return scenario.YellowBlue; }
            set
            {
                if (value == scenario.YellowBlue)
                    return;

                scenario.YellowBlue = value;

                base.OnPropertyChanged("YellowBlue");
            }
        }
        public string YellowRed
        {
            get { return scenario.YellowRed; }
            set
            {
                if (value == scenario.YellowRed)
                    return;

                scenario.YellowRed = value;

                base.OnPropertyChanged("YellowRed");
            }
        }
        public string YellowGreen
        {
            get { return scenario.YellowGreen; }
            set
            {
                if (value == scenario.YellowGreen)
                    return;

                scenario.YellowGreen = value;

                base.OnPropertyChanged("YellowGreen");
            }
        }
        public string YellowYellow
        {
            get { return scenario.YellowYellow; }
            set
            {
                if (value == scenario.YellowYellow)
                    return;

                scenario.YellowYellow = value;

                base.OnPropertyChanged("YellowYellow");
            }
        }
        #endregion

        #region Bools
        ///Welcher Button ausgewählt wurde
        public bool BlueClicked { get; private set; }
        public bool GreenClicked { get; private set; }
        public bool RedClicked { get; private set; }
        public bool YellowClicked { get; private set; }

        public bool BlueSecondStageClicked { get; private set; }
        public bool GreenSecondStageClicked { get; private set; }
        public bool RedSecondStageClicked { get; private set; }
        public bool YellowSecondStageClicked { get; private set; }
        public bool ResetClicked { get; private set; }
        #endregion

        /// <summary> Eventhandler für hasGaze </summary>
        /// <param name="hasGaze"> Ob der Button betrachtet wird</param>
        /// <param name="name"> Betrachteter Button </param>
        public void NotifyHasGazeChanged(bool hasGaze, string name)
        {
            if (hasGaze)  
            {
                switch (name)
                {
                    case "UpperLeft":
                        BlueClicked = true;
                        base.OnPropertyChanged("BlueClicked");
                        break;
                    case "LowerLeft":
                        GreenClicked = true;
                        base.OnPropertyChanged("GreenClicked");
                        break;
                    case "UpperRight":
                        RedClicked = true;
                        base.OnPropertyChanged("RedClicked");
                        break;
                    case "LowerRight":
                        YellowClicked = true;
                        base.OnPropertyChanged("YellowClicked");
                        break;
                    case "UpperLeftSecondStage":
                        BlueSecondStageClicked = true;
                        base.OnPropertyChanged("BlueSecondStageClicked");
                        break;
                    case "LowerLeftSecondStage":
                        GreenSecondStageClicked = true;
                        base.OnPropertyChanged("GreenSecondStageClicked");
                        break;
                    case "UpperRightSecondStage":
                        RedSecondStageClicked = true;
                        base.OnPropertyChanged("RedSecondStageClicked");
                        break;
                    case "LowerRightSecondStage":
                        YellowSecondStageClicked = true;
                        base.OnPropertyChanged("YellowSecondStageClicked");
                        break;
                    case "ResetButton":
                        ResetClicked = true;
                        base.OnPropertyChanged("ResetClicked");
                        break;
                }
            }
        }
    }
}

using Bildwahl.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Bildwahl.Model
{
    /// <summary> Datenhalterklasse für ein Szenario </summary>
    public class Scenario : IDataErrorInfo
    {
        /// <summary> Ob das Szenario im DeleteScenario-Worskpace ausgewählt wurde </summary>
        bool _isSelected;

        /// <summary> Konstruktor </summary>
        protected Scenario()
        {
        }

        /// <summary> Erstellt ein neues Szenario </summary>
        public static Scenario CreateNewScenario()
        {
            return new Scenario();
        }

        /// <summary> Der Titel und die Bilder werden in Variablen gespeichert </summary>
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

        #region ImageLinks
        /// Alle Bilder des Szenarios
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

        /// <summary> Titel des Szenarios </summary>
        public string Titel { get; set; }


        #region IDataErrorInfo Members

        string IDataErrorInfo.Error { get { return null; } }

        string IDataErrorInfo.this[string propertyName]
        {
            get { return this.GetValidationError(propertyName); }
        }

        #endregion // IDataErrorInfo Members

        #region Validation

        /// <summary> Gibt True zurück, wenn keine Validation Errors bestehen </summary>
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

        /// <summary> Ob das Szenario im DeleteScenario-Worskpace ausgewählt wurde </summary>
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

        /// <summary> Event das ausgelöst wird, wenn das Szenario ausgewählt wird </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Löst PropertyChangedEvent aus </summary>
        /// <param name="propertyName">Property die geändert werden soll </param>
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

        /// <summary> Verifiziert, dass das Objekt die Property besitzt die geändert werden soll </summary>
        /// <param name="propertyName">Property die geändert werden soll </param>
        public void VerifyPropertyName(string propertyName)
        {
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

        /// <summary> Gibt falls Fehler in der Validierung entshen Fehlermeldung zurück </summary>
        /// <param name="propertyName">Property die geändert werden soll </param>
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

        /// <summary> Validiert ob ein Titel eingeben wurde, ansonsten wird Fehlermeldung zurückgegeben </summary>
        string ValidateTitel()
        {
            if (IsStringMissing(this.Titel))
            {
                return Strings.Scenario_Error_MissingTitel;
            }
            return null;
        }

        /// <summary> Überprüft ob ein String existiert </summary>
        /// /// <param name="value">STring der überprüft werden soll</param>
        static bool IsStringMissing(string value)
        {
            return
                String.IsNullOrEmpty(value) ||
                value.Trim() == String.Empty;
        }

        #endregion // Validation
    }
}

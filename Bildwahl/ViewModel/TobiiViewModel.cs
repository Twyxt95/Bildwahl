using System;
using System.ComponentModel;
using System.Windows.Input;
using Bildwahl.DataAccess;
using Bildwahl.Model;
using Bildwahl.Properties;
using Tobii.Interaction.Framework;
using Tobii.Interaction;
using Tobii.Interaction.Wpf;
using System.IO;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Bildwahl.ViewModel
{
    public class TobiiViewModel : WorkspaceViewModel
    {
        RelayCommand _doSomething;
        readonly ScenarioRepository _imageLinksRepository;
        Boolean hasGaze = false;
        string _scenarioName;
        Scenario scenario;
        public TobiiViewModel(ScenarioRepository imageLinksRepository, string scenarioName)
        {
            if (imageLinksRepository == null)
                throw new ArgumentNullException("customerRepository");
            base.DisplayName = Strings.TobiiViewModel_DisplayName;

            _imageLinksRepository = imageLinksRepository;
            scenario = _imageLinksRepository.GetCustomers(scenarioName);
            _scenarioName = scenarioName;
        }



        /// <summary>
        /// Returns a collection of all the CustomerViewModel objects.
        /// </summary>
        public ObservableCollection<NewScenarioViewModel> AllCustomers { get; private set; }
        #region ImageLinks
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




        public ICommand DoSomethingCommand
        {
            get
            {
                if (_doSomething == null)
                {
                    _doSomething = new RelayCommand(
                        param => this.TestingThis()
                        );
                }
                return _doSomething;
            }
        }

        private void TestingThis()
        {
            hasGaze = !hasGaze;
            if (hasGaze)
            {
                Console.WriteLine("Catched");
            }
        }

        public string GetImage()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Pictures", "Koala.jpg");
            Console.WriteLine(path);

            return path;
        }

        public string GetImagePath
        {
            
            get { return GetImage(); }
        }

    }
}

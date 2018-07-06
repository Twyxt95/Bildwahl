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
        readonly ImageLinksRepository _imageLinksRepository;
        Boolean hasGaze = false;
        string _scenario;
        public TobiiViewModel(ImageLinksRepository imageLinksRepository, string scenario)
        {
            if (imageLinksRepository == null)
                throw new ArgumentNullException("customerRepository");
            base.DisplayName = Strings.TobiiViewModel_DisplayName;

            _imageLinksRepository = imageLinksRepository;

            _scenario = scenario;

            // Subscribe for notifications of when a new customer is saved.
            _imageLinksRepository.ScenarioAdded += this.OnCustomerAddedToRepository;

            // Populate the AllCustomers collection with CustomerViewModels.
            this.CreateAllImageLinks();
        }

        void CreateAllImageLinks()
        {
            List<NewScenarioViewModel> all =
                (from cust in _imageLinksRepository.GetCustomers(_scenario)
                 select new NewScenarioViewModel(cust, _imageLinksRepository)).ToList();

            foreach (NewScenarioViewModel cvm in all)
                cvm.PropertyChanged += this.OnCustomerViewModelPropertyChanged;

            this.AllCustomers = new ObservableCollection<NewScenarioViewModel>(all);
            this.AllCustomers.CollectionChanged += this.OnCollectionChanged;
        }

        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (NewScenarioViewModel custVM in e.NewItems)
                    custVM.PropertyChanged += this.OnCustomerViewModelPropertyChanged;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (NewScenarioViewModel custVM in e.OldItems)
                    custVM.PropertyChanged -= this.OnCustomerViewModelPropertyChanged;
        }

        void OnCustomerAddedToRepository(object sender, ScenarioAddedEventArgs e)
        {
            var viewModel = new NewScenarioViewModel(e.NewCustomer, _imageLinksRepository);
            this.AllCustomers.Add(viewModel);
        }

        /// <summary>
        /// Returns a collection of all the CustomerViewModel objects.
        /// </summary>
        public ObservableCollection<NewScenarioViewModel> AllCustomers { get; private set; }

        void OnCustomerViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            string IsSelected = "IsSelected";

            // Make sure that the property name we're referencing is valid.
            // This is a debugging technique, and does not execute in a Release build.
            (sender as NewScenarioViewModel).VerifyPropertyName(IsSelected);

            // When a customer is selected or unselected, we must let the
            // world know that the TotalSelectedSales property has changed,
            // so that it will be queried again for a new value.
            if (e.PropertyName == IsSelected)
                this.OnPropertyChanged("TotalSelectedSales");
        }

        protected override void OnDispose()
        {
            foreach (NewScenarioViewModel custVM in this.AllCustomers)
                custVM.Dispose();

            this.AllCustomers.Clear();
            this.AllCustomers.CollectionChanged -= this.OnCollectionChanged;

            _imageLinksRepository.ScenarioAdded -= this.OnCustomerAddedToRepository;
        }

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

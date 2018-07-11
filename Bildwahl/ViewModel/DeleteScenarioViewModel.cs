using Bildwahl.DataAccess;
using Bildwahl.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bildwahl.ViewModel
{
    class DeleteScenarioViewModel : WorkspaceViewModel
    {
        RelayCommand _deleteScenario;
        readonly ScenarioRepository _scenarioRepository;

        public DeleteScenarioViewModel(ScenarioRepository scenarioRepository)
        {
            _scenarioRepository = scenarioRepository;
            _scenarioRepository.ScenarioDeleted += this.OnCustomerDeletedToRepository;

            // Populate the AllCustomers collection with CustomerViewModels.
            this.CreateAllCustomers();
        }

        private void OnCustomerDeletedToRepository(object sender, ScenarioDeletedEventArgs e)
        {
            AllScenarios.Remove(e.ToRemoveScenario);
        }

        void CreateAllCustomers()
        {
            List<Scenario> all = _scenarioRepository.GetCustomers();

            /*foreach (NewScenarioViewModel cvm in all)
                cvm.PropertyChanged += this.OnCustomerViewModelPropertyChanged;*/

            this.AllScenarios = new ObservableCollection<Scenario>(all);
            //this.AllCustomers.CollectionChanged += this.OnCollectionChanged;
        }



        public ObservableCollection<Scenario> AllScenarios { get; private set; }

       /* void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (NewScenarioViewModel custVM in e.NewItems)
                    custVM.PropertyChanged += this.OnCustomerViewModelPropertyChanged;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (NewScenarioViewModel custVM in e.OldItems)
                    custVM.PropertyChanged -= this.OnCustomerViewModelPropertyChanged;
        }

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

        void OnCustomerAddedToRepository(object sender, CustomerAddedEventArgs e)
        {
            var viewModel = new CustomerViewModel(e.NewCustomer, _customerRepository);
            this.AllCustomers.Add(viewModel);
        }*/

        public ICommand DeleteScenario
        {
            get
            {
                if (_deleteScenario == null)
                {
                    _deleteScenario = new RelayCommand(
                        param => this.Delete()
                        );
                }
                return _deleteScenario;
            }
        }

        public void Delete()
        {
            int index = AllScenarios.IndexOf(AllScenarios.Where(p => p.IsSelected == true).FirstOrDefault());
            Console.WriteLine(index + "HERE!!!!!!");
            Scenario scenario = AllScenarios.ElementAt(index);
            _scenarioRepository.DeleteScenario(scenario);
        }
    }
}

using Bildwahl.DataAccess;
using System;
using System.Collections.Generic;
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
        }

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

        private void Delete()
        {
            _scenarioRepository.DeleteScenario();
        }
    }
}

using Bildwahl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bildwahl.DataAccess
{
    /// <summary> Event, das ausgelöst wird, wenn ein Szenario gelöscht wird </summary>
    public class ScenarioDeletedEventArgs : EventArgs
    {
        public ScenarioDeletedEventArgs(Scenario toRemoveScenario)
        {
            this.ToRemoveScenario = toRemoveScenario;
        }

        public Scenario ToRemoveScenario { get; private set; }
    }
}

using System;
using Bildwahl.Model;

namespace Bildwahl.DataAccess
{
    /// <summary>
    /// Event arguments used by ScenarioRepository's ScenarioAdded event.
    /// </summary>
    public class ScenarioAddedEventArgs : EventArgs
    {
        public ScenarioAddedEventArgs(Scenario newScenario)
        {
            this.NewScenario = newScenario;
        }

        public Scenario NewScenario { get; private set; }
    }
}

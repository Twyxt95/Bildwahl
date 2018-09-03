using System;
using Bildwahl.Model;

namespace Bildwahl.DataAccess
{
    /// <summary> Event, das ausgelöst wird, wenn ein Szenario erstellt wird </summary>
    public class ScenarioAddedEventArgs : EventArgs
    {
        public ScenarioAddedEventArgs(Scenario newScenario)
        {
            this.NewScenario = newScenario;
        }

        public Scenario NewScenario { get; private set; }
    }
}

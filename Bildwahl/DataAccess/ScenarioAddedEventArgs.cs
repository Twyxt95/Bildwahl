using System;
using Bildwahl.Model;

namespace Bildwahl.DataAccess
{
    /// <summary>
    /// Event arguments used by CustomerRepository's CustomerAdded event.
    /// </summary>
    public class ScenarioAddedEventArgs : EventArgs
    {
        public ScenarioAddedEventArgs(ImageLinks newCustomer)
        {
            this.NewCustomer = newCustomer;
        }

        public ImageLinks NewCustomer { get; private set; }
    }
}

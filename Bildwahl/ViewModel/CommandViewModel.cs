using System;
using System.Windows.Input;

namespace Bildwahl.ViewModel
{
    /// <summary>Stellt ein aktivierbares Objekt dar, das von einer View angezeigt wird </summary>
    public class CommandViewModel : ViewModelBase
    {
        public CommandViewModel(string displayName, ICommand command)
        {
            base.DisplayName = displayName;
            this.Command = command ?? throw new ArgumentNullException("command");
        }

        public ICommand Command { get; private set; }
    }
}
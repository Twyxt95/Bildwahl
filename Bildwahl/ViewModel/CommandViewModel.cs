using System;
using System.Windows.Input;

namespace Bildwahl.ViewModel
{
    /// <summary>
    /// Represents an actionable item displayed by a View.
    /// </summary>
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
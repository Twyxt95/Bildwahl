using System;
using System.Windows.Input;

namespace Bildwahl.ViewModel
{
    public abstract class WorkspaceViewModel : ViewModelBase
    {
        #region Fields

        RelayCommand _closeCommand;

        #endregion // Fields

        #region Constructor

        protected WorkspaceViewModel()
        {
        }

        #endregion // Constructor

        #region CloseCommand

        /// <summary>Schließt den aktuellen Workspace </summary>
        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                    _closeCommand = new RelayCommand(param => this.OnRequestClose());

                return _closeCommand;
            }
        }

        #endregion // CloseCommand

        #region RequestClose [event]

        /// <summary>Ausgelöst, wenn der Workspace netfernt werden soll </summary>
        public event EventHandler RequestClose;

        void OnRequestClose()
        {
            this.RequestClose?.Invoke(this, EventArgs.Empty);
        }

        #endregion // RequestClose [event]
    }
}

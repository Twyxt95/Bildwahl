using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Bildwahl.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        /// <summary> Konstruktor </summary>
        protected ViewModelBase()
        {
        }

        /// <summary>Name des Viewmodels </summary>
        public virtual string DisplayName { get; protected set; }

        /// <summary> Nur Debug, Überprüft ob Property existiert </summary>
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void VerifyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = "Invalid property name: " + propertyName;

                if (this.ThrowOnInvalidPropertyName)
                    throw new Exception(msg);
                else
                    Debug.Fail(msg);
            }
        }

        protected virtual bool ThrowOnInvalidPropertyName { get; private set; }


        #region INotifyPropertyChanged Members

        /// <summary> Ausgelöst wenn eine Property dieses Objekts einen neuen Wert hat </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>Löst PropertyChanged Event aus</summary>
        /// <param name="propertyName"> Die Property, die einen neuen Namen hat </param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.VerifyPropertyName(propertyName);

            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        #endregion // INotifyPropertyChanged Members

        #region IDisposable Members

        /// <summary>Ausgelöst, wenn das Objekt aus der Apllikation entfernt wird</summary>
        public void Dispose()
        {
            this.OnDispose();
        }

        /// <summary> Logik, wenn Objekt entfernt wird </summary>
        protected virtual void OnDispose()
        {
        }

#if DEBUG
        /// <summary> Nützlich, um zu überprüfen ob ViewModel-Klassen gelöscht wurden </summary>
        ~ViewModelBase()
        {
            string msg = string.Format("{0} ({1}) ({2}) Finalized", this.GetType().Name, this.DisplayName, this.GetHashCode());
            System.Diagnostics.Debug.WriteLine(msg);
        }
#endif

        #endregion // IDisposable Members
    }
}

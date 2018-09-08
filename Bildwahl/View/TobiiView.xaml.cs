using Tobii.Interaction.Wpf;
using System.Windows.Controls;
using System.Windows;
using Bildwahl.ViewModel;

namespace Bildwahl.View
{
    public partial class TobiiView : System.Windows.Controls.UserControl
    {
        public TobiiView()
        {
            InitializeComponent();
        }

        /// <summary> Eventhandler für hasGazeChanged </summary>
        /// <param name="sender"> Objekt das das Event ausgelöst hat </param>
        /// <param name="e"> Das Event </param>
        public void Instruction_OnHasGazeChanged(object sender, RoutedEventArgs e)
        {
            if (!(e.Source is Button button)) { return; }

            var model = (TobiiViewModel)DataContext;
            var hasGaze = button.GetHasGaze();
            model.NotifyHasGazeChanged(hasGaze,button.Name);
        }
    }
}
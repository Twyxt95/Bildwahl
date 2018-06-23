using Tobii.Interaction.Framework;
using Tobii.Interaction;
using Tobii.Interaction.Wpf;
namespace Bildwahl.View
{
    public partial class TobiiTest : System.Windows.Controls.UserControl
    {
        public TobiiTest()
        {
            InitializeComponent();
        }

        private void DoSomething(object sender, HasGazeChangedRoutedEventArgs e)
        {
            
        }
    }
}
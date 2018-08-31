using Tobii.Interaction.Framework;
using Tobii.Interaction;
using Tobii.Interaction.Wpf;
using System.Windows.Controls;
using System.Windows;
using Bildwahl.ViewModel;
using System;

namespace Bildwahl.View
{
    public partial class TobiiView : System.Windows.Controls.UserControl
    {
        public TobiiView()
        {
            InitializeComponent();
        }

        public void Instruction_OnHasGazeChanged(object sender, RoutedEventArgs e)
        {
            var textBlock = e.Source as Button;
            if (null == textBlock) { return; }

            var model = (TobiiViewModel)DataContext;
            var hasGaze = textBlock.GetHasGaze();
            model.NotifyHasGazeChanged(hasGaze,textBlock.Name);
        }
    }
}
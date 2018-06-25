﻿using System;
using System.ComponentModel;
using System.Windows.Input;
using Bildwahl.DataAccess;
using Bildwahl.Model;
using Bildwahl.Properties;
using Tobii.Interaction.Framework;
using Tobii.Interaction;
using Tobii.Interaction.Wpf;

namespace Bildwahl.ViewModel
{
    public class TobiiTestViewModel : WorkspaceViewModel
    {
        RelayCommand _doSomething;
        Boolean hasGaze = false;
        public TobiiTestViewModel()
            {
            base.DisplayName = Strings.TobiiTestViewModel_DisplayName;
        }

        public ICommand DoSomethingCommand
        {
            get
            {
                if (_doSomething == null)
                {
                    _doSomething = new RelayCommand(
                        param => this.TestingThis()
                        );
                }
                return _doSomething;
            }
        }

        private void TestingThis()
        {
            hasGaze = !hasGaze;
            if (hasGaze)
            {
                Console.WriteLine("Catched");
            }
        }

    }
}

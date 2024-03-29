﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace FileExplorerMVVM.Infrastructure.CustomControls
{
    class NavigationMenuButton : RadioButton
    {
        public PathGeometry Icon
        {
            get => (PathGeometry)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(PathGeometry), typeof(NavigationMenuButton));

        public ICommand UnPinCommand
        {
            get => (ICommand)GetValue(UnPinCommandProperty);
            set => SetValue(UnPinCommandProperty, value);
        }

        public static readonly DependencyProperty UnPinCommandProperty =
            DependencyProperty.Register("UnPinCommand", typeof(ICommand), typeof(NavigationMenuButton));

    }
}

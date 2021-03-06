﻿using System.Windows.Controls;
using CBRN_Project.MVVM.ViewModels;

namespace CBRN_Project.MVVM.Views
{
    public partial class InputView : Page
    {
        public InputView()
        {
            InputViewModel inputViewModel = new InputViewModel();

            InitializeComponent();

            this.DataContext = inputViewModel;
            this.InputInnerFrame.Navigated += inputViewModel.ClearFrameCache;
        }
    }
}

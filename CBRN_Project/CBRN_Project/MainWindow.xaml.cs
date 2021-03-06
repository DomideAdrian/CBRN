﻿using System.Windows;
using CBRN_Project.MVVM.ViewModels;

namespace CBRN_Project
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            MainViewModel mainViewModel = new MainViewModel();

            InitializeComponent();

            this.DataContext = mainViewModel;
            this.MainFrame.Navigated += mainViewModel.ClearFrameCache;
        }
    }
}

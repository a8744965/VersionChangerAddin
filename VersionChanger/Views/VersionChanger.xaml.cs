﻿using DSoft.VersionChanger.ViewModel;
using EnvDTE;
using Microsoft.VisualStudio.PlatformUI;
using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DSoft.VersionChanger.Views
{
    /// <summary>
    /// Interaction logic for VersionChanger.xaml
    /// </summary>
    public partial class VersionChanger : DialogWindow
    {
        private ProjectViewModel mViewModel;

        private const float heightShort = 500;
        private const float heightTall = 500;

        public VersionChanger(DTE applicationObject)
        {
            InitializeComponent();

            mViewModel = new ProjectViewModel(applicationObject);

            this.DataContext = mViewModel;
        }

        private void OnBeginClicked(object sender, RoutedEventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            try
            {
                mViewModel.ProcessUpdates();

                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DSoft - Version Changer");
            }
        }

        private void edtVersion_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void OnToggleAllClicked(object sender, RoutedEventArgs e)
        {
            mViewModel.SelectAll = !mViewModel.SelectAll;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void FilterClick(object sender, RoutedEventArgs e)
        {
            mViewModel.FilterProjects();
        }
    }
}

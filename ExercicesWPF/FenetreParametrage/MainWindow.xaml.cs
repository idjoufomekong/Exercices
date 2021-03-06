﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FenetreParametrage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UCGeneral _ucGeneral;
        public MainWindow()
        {
            InitializeComponent();
            tiGeneral.Loaded += TiGeneral_Loaded;
        }

        private void TiGeneral_Loaded(object sender, RoutedEventArgs e)
        {
            if (_ucGeneral == null)
                _ucGeneral = new FenetreParametrage.UCGeneral();
            tiGeneral.Content = _ucGeneral;
        }
    }
}

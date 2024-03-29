﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using TouristGuide.WP7.ViewModels;
using System.Device.Location;
using Microsoft.Phone.Controls.Maps;

namespace TouristGuide.WP7
{
    public partial class AttractionPage : PhoneApplicationPage
    {
        private AttractionViewModel viewModel = new AttractionViewModel();

        public AttractionPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = viewModel;
            this.Loaded += new RoutedEventHandler(PhoneApplicationPage_Loaded);
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            string idString = "";
            if (NavigationContext.QueryString.TryGetValue("id", out idString))
            {
                int id = 0;
                int.TryParse(idString, out id);
                viewModel.LoadData(id);
                //webBrowserDescription.NavigateToString(viewModel.Description);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/TouristGuide.WP7;component/AttractionMapPage.xaml?id=" + viewModel.Id, UriKind.Relative));
        }
    }
}
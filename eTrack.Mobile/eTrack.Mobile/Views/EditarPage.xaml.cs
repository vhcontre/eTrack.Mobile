﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTrack.Mobile.ViewModels.Asset;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eTrack.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarPage : ContentPage
    {
        public EditarPage()
        {
            InitializeComponent();
            this.BindingContext = new AssetEditViewModel(Navigation);
        }
    }
}
using eTrack.Mobile.ViewModels;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eTrack.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePasswordPopup : PopupPage
    {
        public ChangePasswordPopup()
        {
            InitializeComponent();
            BindingContext = new ChangePasswordViewModel();
        }

        protected override bool OnBackgroundClicked()
        {
            return false;
        }
    }
}
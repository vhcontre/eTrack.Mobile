using eTrack.Mobile.ViewModels.Asset;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eTrack.Mobile.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExecutePage : PopupPage
    {
        readonly AssetActionViewModel viewModel;
        public ExecutePage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AssetActionViewModel(Navigation);
        }
        protected override bool OnBackgroundClicked()
        {
            return false;
        }
    }
}
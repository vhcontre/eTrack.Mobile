using eTrack.Mobile.ViewModels;
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
    public partial class AuditarPage : ContentPage
    {
        public AuditarPage()
        {
            InitializeComponent();
            BindingContext = new AuditarViewModel(Navigation);
        }
    }
}
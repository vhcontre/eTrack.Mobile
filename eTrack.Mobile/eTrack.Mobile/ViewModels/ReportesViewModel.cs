using eTrack.Mobile.Models;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using eTrack.Mobile.Views;
using System.Collections.Generic;
using System.Diagnostics;
using Acr.UserDialogs;
using System;

namespace eTrack.Mobile.ViewModels
{
    //ResultadoReportePage
    public class ResultadoReporteViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ICommand AcceptCommand { get; protected set; }
        public ICommand CancelCommand { get; protected set; }


        public ResultadoReporteViewModel() { }

        public ResultadoReporteViewModel(INavigation navigation)
        {
            Title = "Auditorías registradas";
            this.Navigation = navigation;
            //this.CancelCommand = new Command(async () => await Application.Current.MainPage.DisplayAlert("Command Cancelar", "Se hizo clic en Cancelar", "Ok"));
            //this.AcceptCommand = new Command(async () => await ResultadoReporte());

        }
        private async Task ResultadoReporte()
        {
            //await Application.Current.MainPage.DisplayAlert("Command Aceptar", "Se hizo clic en Aceptar", "Yes", "No");
            //await this.Navigation.PushAsync(new ResultadoReportePage());
            //await this.Navigation.PushAsync(new ResultadoHistorialPage());
        }
    }
    public class ReportesViewModel : BaseViewModel
    {
        public string SearchArgument { get; set; }
        public DateTime SelectedDate { get; set; }
        public INavigation Navigation { get; set; }

        #region Constructores
        public ReportesViewModel() { }
        public ReportesViewModel(INavigation navigation)
        {
            Title = "Reportes de auditorías";
            this.Navigation = navigation;

            this.SearchArgumentList = new List<string>() { "Tag", "Código", "Fecha de alta" };
            this.SearchArgumentFilters = new List<string>() { "Menor igual", "Mayor igual", "Igual", "Distinto", "Todos" };
            this.IsVisible = false;
            this.SelectedDate = DateTime.Now;

        }
        #endregion

        public ICommand FindCommand
        {
            get
            {
                return new Command(() =>
                {
                    var data = string.Format("Item: {0} - Argument: {1} - Filtro: {2}",
                        this.SelectedItem,
                        (SelectedItem == "Fecha de alta") ? SelectedDate.ToString("dd/MM/yyyy") : SearchArgument, this.SelectedFilter);
                    UserDialogs.Instance.Alert(data, "Valores");
                    Navigation.PushAsync(new ResultadoBusquedaPage());
                });
            }
        }
        public ICommand ChangeOptionCommand
        {
            get
            {
                return new Command<string>(ChangeOption);
            }
        }
        public void ChangeOption(string selectedOption)
        {

            switch (selectedOption)
            {
                case "Tag":
                    this.IsVisible = true;
                    this.IsVisibleDate = false;
                    this.Placeholder = string.Format("Ingrese el valor del {0}", selectedOption);
                    break;
                case "Código":
                    this.IsVisible = true;
                    this.IsVisibleDate = false;
                    this.Placeholder = string.Format("Ingrese el valor del {0}", selectedOption);
                    break;
                case "Fecha de alta":
                    this.IsVisible = false;
                    this.IsVisibleDate = true;
                    break;
                default:
                    break;
            }

        }
    }
}
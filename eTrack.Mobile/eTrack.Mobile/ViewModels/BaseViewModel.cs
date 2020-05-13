using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using eTrack.Mobile.Models;
using eTrack.Mobile.Services;

namespace eTrack.Mobile.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private string _message;
        private bool _isContentEnabled;
        private double _contentOpacity;
        bool _isBusy = false;
        string _title = string.Empty;

        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();
        public IDataStore<AssetAuditModel> AssetAuditDb => DependencyService.Get<IDataStore<AssetAuditModel>>();        
        //public IDataStore<AssetModel> AssetDb => DependencyService.Get<IDataStore<AssetModel>>();

        
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                IsContentEnabled = !value;
                SetProperty(ref _isBusy, value);
            }
        }


        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


        public bool IsContentEnabled
        {
            get { return _isContentEnabled; }
            set
            {
                var opacity = value ? 1 : 0.5;
                ContentOpacity = opacity;
                SetProperty(ref _isContentEnabled, value);
            }
        }

        public double ContentOpacity
        {
            get { return _contentOpacity; }
            set { SetProperty(ref _contentOpacity, value); }
        }


        public virtual Command BackCommand
        {
            get
            {
                return new Command(() =>
                {
                    Application.Current.MainPage.Navigation.PopAsync();
                });
            }
        }



        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Buscar por Tag, Código o Fecha
        public IList<string> SearchArgumentList { get; set; }
        string _argName;
        public string SelectedItem
        {
            get { return _argName; }
            set
            {
                if (_argName != value)
                {
                    if (string.IsNullOrWhiteSpace(value))
                        _argName = "Tag";
                    _argName = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region Aplicar filtros
        public IList<string> SearchArgumentFilters { get; set; }
        string _argFilter;
        public string SelectedFilter
        {
            get { return _argFilter; }
            set
            {
                if (_argFilter != value)
                {
                    if (string.IsNullOrWhiteSpace(value))
                        _argFilter = "Menor igual";
                    _argFilter = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region Cost Center List
        public IList<string> CostCenterList { get; set; }
        string _costCenter;
        public string CostCenterSelectedItem
        {
            get { return _costCenter; }
            set
            {
                if (_costCenter != value)
                {
                    _costCenter = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region Location List
        public IList<string> LocationList { get; set; }
        string _locationList;
        public string LocationSelectedItem
        {
            get { return _locationList; }
            set
            {
                if (_locationList != value)
                {
                    _locationList = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
    }
}

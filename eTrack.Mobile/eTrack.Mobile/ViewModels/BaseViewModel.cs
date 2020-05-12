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
    }
}

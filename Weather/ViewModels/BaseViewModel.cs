using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

namespace Weather
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public CloudDataStore DataStore => DependencyService.Get<CloudDataStore>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        bool isNotBusy = false;
        public bool IsNotBusy
        {
            get { return isNotBusy; }
            set { SetProperty(ref isNotBusy, value); }
        }


        bool isCelsius = true;
        public bool IsCelsius
        {
            get { return isCelsius; }
            set { SetProperty(ref isCelsius, value); }
        }

        bool isFah = false;
        public bool IsFah
        {
            get { return isFah; }
            set { SetProperty(ref isFah, value); }
        }

        bool isKph = true;
        public bool IsKph
        {
            get { return isKph; }
            set { SetProperty(ref isKph, value); }
        }

        bool isMph = false;
        public bool IsMph
        {
            get { return isMph; }
            set { SetProperty(ref isMph, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
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

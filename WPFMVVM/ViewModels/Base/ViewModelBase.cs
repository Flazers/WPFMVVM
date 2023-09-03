﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Documents;

namespace WPFMVVM.ViewModels.Base
{
    internal abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool Set<T>(ref T feild, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(feild, value)) return false;
            feild = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
        private bool _Disposed;
        protected virtual void Dispose(bool disposing)
        {
            if(!disposing || _Disposed) return;
            _Disposed = true;
        }
    }
}

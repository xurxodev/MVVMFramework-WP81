using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFramework.WP81
{
    public class ObservableObject:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string caller)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(caller));
            }
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName]string caller = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;

            field = value;
            OnPropertyChanged(caller);
            return true;
        }
    }
}

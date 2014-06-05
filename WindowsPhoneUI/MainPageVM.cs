using MVVMFramework.WP81;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WindowsPhoneUI
{
    public class MainPageVM : ObservableObject
    {

        public MainPageVM()
        {
            CalculateCommand = new RelayCommand(() => CalculateResult(), () => op1 > 0 && op2 > 0);
        }

        public ICommand CalculateCommand { get;private set; }


        private int op1;
        public int Op1
        {
            get { return op1; }
            set
            {
                SetField(ref op1, value);
                (CalculateCommand as RelayCommand).RaiseCanExecuteChanged();
            }
        }

        private int op2;
        public int Op2
        {
            get { return op2; }
            set
            {
                SetField(ref op2, value);
                (CalculateCommand as RelayCommand).RaiseCanExecuteChanged();
            }
        }


        private void CalculateResult()
        {
            Result = op1 + op2;
        }

        private int result;
        public int Result
        {
            get { return result; }
            set { SetField(ref result, value); }
        }
    }
}

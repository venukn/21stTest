using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using System.Linq;

namespace _21stMortgageInterviewApplication
{
    public class clsMortgageAppViewModel : INotifyPropertyChanged
    {

        public clsMortgageAppViewModel() { }

        private string _inputValues;
        public string InputValues
        {
            get { return _inputValues; }

            set
            {
                _inputValues = value;

                OnPropertyChanged("InputValues");
            }
        }

        private string _outputValues;
        public string OutputValue
        {
            get { return _outputValues; }
            set
            {
                _outputValues = value;
                OnPropertyChanged("OutputValue");
            }
        }

        #region Commands

        private ICommand _cmdLargestValue;
        public ICommand cmdLargestValue
        {
            get
            {   if (_cmdLargestValue == null)
                    _cmdLargestValue = new RelayCommand(FindLargestValue,  IsInputValueValid);
                return _cmdLargestValue;
            }
        }

        private ICommand _cmdSumOfOdd;
        public ICommand cmdSumOfOdd
        {
            get
            {
                if (_cmdSumOfOdd == null)
                    _cmdSumOfOdd = new RelayCommand(FindSumOfOdd, IsInputValueValid);
                return _cmdSumOfOdd;
            }
        }

        private ICommand _cmdSumOfEven;
        public ICommand cmdSumOfEven
        {
            get
            {
                if (_cmdSumOfEven == null)
                    _cmdSumOfEven = new RelayCommand(FindSumOfEven, IsInputValueValid);
                return _cmdSumOfEven;
            }
        }

        #endregion


        private void FindLargestValue(object param)
        {
            try
            {
                if (string.IsNullOrEmpty(InputValues)) return;

                var lstValues = InputValues.Split(',').Select(int.Parse).ToList();
                var a = lstValues.OrderByDescending(x => x);
                OutputValue = a.FirstOrDefault().ToString();
            }
            catch (Exception ex)
            {
                OutputValue = ex.Message;
            }
        }
        private  bool IsInputValueValid(object param)
        {
            return !string.IsNullOrEmpty(InputValues);
        }
        private void FindSumOfOdd(object param)
        {
            try
            {
                if (string.IsNullOrEmpty(InputValues)) return;

                var lstValues = InputValues.Split(',').Select(int.Parse).ToList();
                int total = 0;

                total = lstValues.Where(x => x % 2 != 0).Sum();
                //foreach (var i in lstValues)
                //{
                //    if (i % 2 != 0) total += i;
                //}

                OutputValue = total.ToString();
            }

            catch (Exception ex)
            {
                OutputValue = ex.Message;
            }
        }

        private void FindSumOfEven(object param)
        {
            try
            {
                if (string.IsNullOrEmpty(InputValues)) return;

                var lstValues = InputValues.Split(',').Select(int.Parse).ToList();

                int total = 0;

                total = lstValues.Where(x => x % 2 == 0).Sum();

                //foreach (var i in lstValues)
                //{
                //    if (i % 2 == 0) total += i;
                //}
                OutputValue = total.ToString();
            }
            catch (Exception ex)
            {
                OutputValue = ex.Message;
            }
        }






















        #region ProPertyChange Handler

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}

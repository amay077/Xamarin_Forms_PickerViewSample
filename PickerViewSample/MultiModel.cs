using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PickerViewSample.Annotations;

namespace PickerViewSample
{
	internal class MultiModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

		private int[] _numbers;
		public int[] Numbers {
            get { return _numbers; }
            set
            {
                _numbers = value;
                OnPropertyChanged();
            }
        }

        private decimal _value;
        public decimal Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }

        private int _selectedIndex0;
        public int SelectedIndex0
        {
            get { return _selectedIndex0; }
            set
            {
                _selectedIndex0 = value;
                OnPropertyChanged();
            }
        }

		private int _selectedIndex1;
		public int SelectedIndex1
        {
            get { return _selectedIndex1; }
            set
            {
                _selectedIndex1 = value;
                OnPropertyChanged();
            }
        }

		private int _selectedIndex2;
		public int SelectedIndex2
        {
            get { return _selectedIndex2; }
            set
            {
                _selectedIndex2 = value;
                OnPropertyChanged();
            }
        }

		private int _selectedIndex3;
		public int SelectedIndex3
        {
            get { return _selectedIndex3; }
            set
            {
                _selectedIndex3 = value;
                OnPropertyChanged();
            }
        }

		private int _selectedIndex4;
		public int SelectedIndex4
        {
            get { return _selectedIndex4; }
            set
            {
                _selectedIndex4 = value;
                OnPropertyChanged();
            }
        }

		private int _selectedIndex5;
		public int SelectedIndex5
        {
            get { return _selectedIndex5; }
            set
            {
                _selectedIndex5 = value;
                OnPropertyChanged();
            }
        }

        readonly IList<Action<int>> _setters = new List<Action<int>>();
        readonly IList<Func<int>> _getters = new List<Func<int>>();

        public MultiModel()
        {
            Numbers = new int[] {0,1,2,3,4,5,6,7,8,9};
            Value = 12345;

            _setters.Add(digitValue => SelectedIndex0 = digitValue);
            _setters.Add(digitValue => SelectedIndex1 = digitValue);
            _setters.Add(digitValue => SelectedIndex2 = digitValue);
            _setters.Add(digitValue => SelectedIndex3 = digitValue);
            _setters.Add(digitValue => SelectedIndex4 = digitValue);
            _setters.Add(digitValue => SelectedIndex5 = digitValue);

            _getters.Add(() => SelectedIndex0);
            _getters.Add(() => SelectedIndex1);
            _getters.Add(() => SelectedIndex2);
            _getters.Add(() => SelectedIndex3);
            _getters.Add(() => SelectedIndex4);
            _getters.Add(() => SelectedIndex5);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

			if (propertyName.StartsWith("SelectedIndex"))
            {
				var digitIndex = int.Parse(propertyName.Replace("SelectedIndex", ""));
				UpdateDigit(digitIndex, _getters[digitIndex].Invoke());
            }
            else if (propertyName == "Value")
            {
                UpdateValue();
            }
        }

        private void UpdateDigit(int digitIndex, int digitValue)
        {
			var numStr = Value.ToString(new string('0', _getters.Count));
            var index = numStr.Length - (digitIndex + 1);
            var newNum = numStr.Substring(0, index) + digitValue.ToString() +  numStr.Substring(index + 1);

            Value = decimal.Parse(newNum);
        }

        private void UpdateValue()
        {
            for (int i = 0; i < _getters.Count; i++)
            {
                var digitValue = GetDigitValue(i);
                if (digitValue != _getters[i].Invoke())
                {
                    _setters[i].Invoke(digitValue);
                }
            }
        }

        private int GetDigitValue(int digitIndex)
        {
            var numStr = Value.ToString();
            var index = numStr.Length - (digitIndex + 1);

            if (index < 0)
            {
                return 0;
            }

            return Convert.ToInt32(numStr.Substring(index, 1));
        }
    }
}
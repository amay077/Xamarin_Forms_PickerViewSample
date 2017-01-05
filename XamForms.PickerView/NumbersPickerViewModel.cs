using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace XamForms.PickerView
{
    internal class NumbersPickerViewModel : INotifyPropertyChanged
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
                if (_value == value)
                {
                    return;
                }
                _value = value;
                OnPropertyChanged();
            }
        }

        private int _integerDigit0;
        public int IntegerDigit0
        {
            get { return _integerDigit0; }
            set
            {
                _integerDigit0 = value;
                OnPropertyChanged();
            }
        }

        private int _integerDigit1;
        public int IntegerDigit1
        {
            get { return _integerDigit1; }
            set
            {
                _integerDigit1 = value;
                OnPropertyChanged();
            }
        }

        private int _integerDigit2;
        public int IntegerDigit2
        {
            get { return _integerDigit2; }
            set
            {
                _integerDigit2 = value;
                OnPropertyChanged();
            }
        }

        private int _integerDigit3;
        public int IntegerDigit3
        {
            get { return _integerDigit3; }
            set
            {
                _integerDigit3 = value;
                OnPropertyChanged();
            }
        }

        private int _integerDigit4;
        public int IntegerDigit4
        {
            get { return _integerDigit4; }
            set
            {
                _integerDigit4 = value;
                OnPropertyChanged();
            }
        }

        private int _integerDigit5;
        public int IntegerDigit5
        {
            get { return _integerDigit5; }
            set
            {
                _integerDigit5 = value;
                OnPropertyChanged();
            }
        }

		private int _integerDigit6;
		public int IntegerDigit6
		{
			get { return _integerDigit6; }
			set
			{
				_integerDigit6 = value;
				OnPropertyChanged();
			}
		}

		private int _integerDigit7;
		public int IntegerDigit7
		{
			get { return _integerDigit7; }
			set
			{
				_integerDigit7 = value;
				OnPropertyChanged();
			}
		}

		private int _integerDigit8;
		public int IntegerDigit8
		{
			get { return _integerDigit8; }
			set
			{
				_integerDigit8 = value;
				OnPropertyChanged();
			}
		}

		private int _integerDigit9;
		public int IntegerDigit9
		{
			get { return _integerDigit9; }
			set
			{
				_integerDigit9 = value;
				OnPropertyChanged();
			}
		}

		private int _decimalDigit0;
        public int DecimalDigit0
        {
            get { return _decimalDigit0; }
            set
			{
                _decimalDigit0 = value;
                OnPropertyChanged();
            }
        }

        private int _decimalDigit1;
        public int DecimalDigit1
        {
            get { return _decimalDigit1; }
            set
            {
                _decimalDigit1 = value;
                OnPropertyChanged();
            }
        }

        private int _decimalDigit2;
        public int DecimalDigit2
        {
            get { return _decimalDigit2; }
            set
            {
                _decimalDigit2 = value;
                OnPropertyChanged();
            }
        }

        private int _integerDigitLength;
        public int IntegerDigitLength
        {
            get { return _integerDigitLength; }
            set
            {
				if (!(0 < value && value <= MaxIntegerDigitLength))
				{
					throw new IndexOutOfRangeException($"{nameof(IntegerDigitLength)} should between 1 and {MaxIntegerDigitLength}.");
				}
    
				_integerDigitLength = value;
                OnPropertyChanged();
            }
        }

        private int _decimalDigitLength;
        public int DecimalDigitLength
        {
            get { return _decimalDigitLength; }
            set
            {
				if (!(0 <= value && value <= MaxDecimalDigitLength))
				{
					throw new IndexOutOfRangeException($"{nameof(DecimalDigitLength)} should between 0 and {MaxDecimalDigitLength}.");
				}

                _decimalDigitLength = value;
                OnPropertyChanged();
            }
        }

        private double _fontSize = -1;
        public double FontSize
        {
            get { return _fontSize; }
            set
            {
                _fontSize = value;
                OnPropertyChanged();
            }
        }

        private double _columnWidth = 20;
        public double ColumnWidth
        {
            get { return _columnWidth; }
            set
            {
                _columnWidth = value;
                OnPropertyChanged();
            }
        }

		private int MaxIntegerDigitLength
		{
			get { return _intSetters.Count; }
		}

		private int MaxDecimalDigitLength
		{
			get { return _decSetters.Count; }
		}

        readonly IList<Action<int>> _intSetters = new List<Action<int>>();
        readonly IList<Func<int>> _intGetters = new List<Func<int>>();

        readonly IList<Action<int>> _decSetters = new List<Action<int>>();
        readonly IList<Func<int>> _decGetters = new List<Func<int>>();

        public NumbersPickerViewModel()
        {
            Numbers = new int[] {0,1,2,3,4,5,6,7,8,9};

            _intSetters.Add(digitValue => IntegerDigit0 = digitValue);
            _intSetters.Add(digitValue => IntegerDigit1 = digitValue);
            _intSetters.Add(digitValue => IntegerDigit2 = digitValue);
            _intSetters.Add(digitValue => IntegerDigit3 = digitValue);
            _intSetters.Add(digitValue => IntegerDigit4 = digitValue);
			_intSetters.Add(digitValue => IntegerDigit5 = digitValue);
			_intSetters.Add(digitValue => IntegerDigit6 = digitValue);
			_intSetters.Add(digitValue => IntegerDigit7 = digitValue);
			_intSetters.Add(digitValue => IntegerDigit8 = digitValue);
			_intSetters.Add(digitValue => IntegerDigit9 = digitValue);

            _intGetters.Add(() => IntegerDigit0);
            _intGetters.Add(() => IntegerDigit1);
            _intGetters.Add(() => IntegerDigit2);
            _intGetters.Add(() => IntegerDigit3);
            _intGetters.Add(() => IntegerDigit4);
			_intGetters.Add(() => IntegerDigit5);
			_intGetters.Add(() => IntegerDigit6);
			_intGetters.Add(() => IntegerDigit7);
			_intGetters.Add(() => IntegerDigit8);
			_intGetters.Add(() => IntegerDigit9);

            _decSetters.Add(digitValue => DecimalDigit0 = digitValue);
            _decSetters.Add(digitValue => DecimalDigit1 = digitValue);
            _decSetters.Add(digitValue => DecimalDigit2 = digitValue);

            _decGetters.Add(() => DecimalDigit0);
            _decGetters.Add(() => DecimalDigit1);
            _decGetters.Add(() => DecimalDigit2);

            FontSize = -1;
            Value = 0M;
            IntegerDigitLength = 4;
            DecimalDigitLength = 2;
        }

        // [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            Debug.WriteLine($"OnPropertyChanged:{propertyName}");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            if (propertyName == "IntegerDigitLength")
            {
                UpdateIntegerDigitLength();
            }
            else if (propertyName == "DecimalDigitLength")
            {
                UpdateDecimalDigitLength();
            }
            else if (propertyName.StartsWith("IntegerDigit", StringComparison.Ordinal))
            {
                var digitIndex = int.Parse(propertyName.Replace("IntegerDigit", ""));
                UpdateIntDigit(digitIndex, _intGetters[digitIndex].Invoke());
            }
            else if (propertyName.StartsWith("DecimalDigit", StringComparison.Ordinal))
            {
                var digitIndex = int.Parse(propertyName.Replace("DecimalDigit", ""));
                UpdateDecDigit(digitIndex, _decGetters[digitIndex].Invoke());
            }
            else if (propertyName == "Value")
            {
                UpdateValue();
            }
        }

        private void UpdateIntDigit(int digitIndex, int digitValue)
        {
            if (digitIndex >= IntegerDigitLength)
            {
                return;
            }

            var numStr = FormatValue();
            var index = IntegerDigitLength - digitIndex - 1;
            var newNum = numStr.Substring(0, index) + digitValue.ToString() +  numStr.Substring(index + 1);

            Value = decimal.Parse(newNum);
        }

        private void UpdateDecDigit(int digitIndex, int digitValue)
        {
            if (digitIndex >= DecimalDigitLength)
            {
                return;
            }

            var numStr = FormatValue(); // 123.45 -> 0123.456
            var index = IntegerDigitLength + digitIndex + 1;
            var newNum = numStr.Substring(0, index) + digitValue.ToString() +  numStr.Substring(index + 1);

            Value = decimal.Parse(newNum);
        }

        private string FormatValue()
        {
            // ex) IntegerDigitLength=2, DecimalDigitLength=1
            var len = new Decimal(Math.Pow(10, DecimalDigitLength));
            var floored = Math.Floor(Value * len) / len;  // 1234.567 -> 1234.5

            // 1234.5 -> 1234.5, 1234 -> 1234.0
            var formatted = floored.ToString(new string('0', IntegerDigitLength)
                                             + (DecimalDigitLength > 0 ? "." + new string('0', DecimalDigitLength) : ""));

            // 1234.5 -> 34.5, 1234 -> 34.0, 1234 -> 34
            return formatted.Substring(formatted.Length - (IntegerDigitLength + DecimalDigitLength + (DecimalDigitLength > 0 ? 1 : 0)));
        }

        private void UpdateValue()
        {
            for (int i = 0; i < IntegerDigitLength; i++)
            {
                var digitValue = GetIntDigitValue(i);
                if (digitValue != _intGetters[i].Invoke())
                {
                    _intSetters[i].Invoke(digitValue);
                }
            }

            for (int i = 0; i < DecimalDigitLength; i++)
            {
                var digitValue = GetDecDigitValue(i);
                if (digitValue != _decGetters[i].Invoke())
                {
                    _decSetters[i].Invoke(digitValue);
                }
            }
        }

        private int GetIntDigitValue(int digitIndex)
        {
            var numStr = Math.Floor(Value).ToString("0");
            var index = numStr.Length - (digitIndex + 1);

            if (index < 0)
            {
                return 0;
            }

            return Convert.ToInt32(numStr.Substring(index, 1));
        }

        private int GetDecDigitValue(int digitIndex)
        {
            var numStr = Value.ToString("0." + new string('0', DecimalDigitLength)); // 12.3 -> 12.30
            var index = Value.ToString("0").Length + (digitIndex + 1);

            if (index < 0)
            {
                return 0;
            }

            return Convert.ToInt32(numStr.Substring(index, 1));
        }

        private void UpdateIntegerDigitLength()
        {
        }

        private void UpdateDecimalDigitLength()
        {
        }


    }
}
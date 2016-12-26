using System.ComponentModel;
using System.Runtime.CompilerServices;
using PickerViewSample.Annotations;

namespace PickerViewSample
{
    public class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _selectedIndex;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;
                OnPropertyChanged();
            }
        }

        private string _itemsSource;
        public string ItemsSource {
            get { return _itemsSource; }
            set
            {
                _itemsSource = value;
                OnPropertyChanged();
            }
        }

        public Model()
        {
            ItemsSource = "a,b,c,d";
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
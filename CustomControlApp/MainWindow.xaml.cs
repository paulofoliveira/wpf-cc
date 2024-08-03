using CustomControlLib;
using System.ComponentModel;
using System.Windows;

namespace CustomControlApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Formas diferentes de setar um valor a uma Attached Property:

            _stackPanel.SetValue(MyCustomControl.IncludeChildCountProperty, true);
            //MyCustomControl.SetIncludeChildCount(_stackPanel, true);
        }
    }

    public class DataObject : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name == value) return;
                _name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
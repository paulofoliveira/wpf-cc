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

            var obj1 = new DataObject() { Name = "Paulo Silva" };
            var obj2 = new DataObject() { Name = "Cecilia Oliveira" };

            _list1.Items.Add(obj1);
            _list2.Items.Add(obj2);
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
        public override string ToString() => $"Name: {Name}";
    }
}
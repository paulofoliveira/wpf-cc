using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

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
        }

        private void CommandBinding_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            //if (!string.IsNullOrEmpty(textBox1.SelectedText))
            //    e.CanExecute = true;
        }

        private void CommandBinding_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            //textBox1.Text = "I cut this out!";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ApplicationCommands.Cut.Execute(null, textBox1);
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
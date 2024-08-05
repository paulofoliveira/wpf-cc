using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

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

            // Configura um Routed Event manualmente a partir do click de um Botão.

            AddHandler(Button.ClickEvent, new RoutedEventHandler(Window_Click));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true; // Cancela automaticamente eventos posteriores de elementos da arvore pela estratégia de Struggling.
        }

        private void Window_Click(object sender, RoutedEventArgs e)
        {

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
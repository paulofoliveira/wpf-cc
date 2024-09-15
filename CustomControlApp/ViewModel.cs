using System;
using System.ComponentModel;

namespace CustomControlApp
{
    public class ViewModel : INotifyPropertyChanged
    {
        private DataObject _model;

        public ViewModel()
        {
            Model = new DataObject() { Name = "Paulo Fernando" };
            UpdateCommand = new RelayCommand(UpdateModel);
        }
        public DataObject Model
        {
            get => _model;
            set
            {
                if (_model == value) return;
                _model = value;
                NotifyPropertyChanged(nameof(Model));
            }
        }
        public RelayCommand UpdateCommand { get; private set; }

        private void UpdateModel(object param)
        {
            Model.Name = DateTime.Now.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
using System;
using System.Windows.Input;

namespace CustomControlApp
{
    // FONTE: https://docs.telerik.com/data-access/quick-start-scenarios/wpf/quickstart-wpf-viewmodelbase-and-relaycommand#implementing_relaycommand
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        private readonly Action<object> _methodToExecute;
        private readonly Func<bool> _canExecuteEvaluator;
        public RelayCommand(Action<object> methodToExecute, Func<bool> canExecuteEvaluator)
        {
            _methodToExecute = methodToExecute;
            _canExecuteEvaluator = canExecuteEvaluator;
        }
        public RelayCommand(Action<object> methodToExecute)
            : this(methodToExecute, null) { }
        public bool CanExecute(object parameter)
        {
            if (_canExecuteEvaluator == null)
                return true;

            return _canExecuteEvaluator.Invoke();
        }
        public void Execute(object parameter) => _methodToExecute.Invoke(parameter);
    }
}
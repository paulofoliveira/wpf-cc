using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomControlLib
{
    public class MyCustomControl : Control
    {
        private Button _button;
        static MyCustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCustomControl), new FrameworkPropertyMetadata(typeof(MyCustomControl)));
        }
        public MyCustomControl()
        {
            CommandBindings.Add(new CommandBinding(ControlCommands.UpdateTextCommand, ExecuteUpdate, CanExecuteUpdate));
        }
        private void CanExecuteUpdate(object sender, CanExecuteRoutedEventArgs e)
        {
            var param = e.Parameter as string;

            if (param != null)
                e.CanExecute = true;
        }

        private void ExecuteUpdate(object sender, ExecutedRoutedEventArgs e)
        {
            if (_button != null)
            {
                _button.Content = e.Parameter;
            }
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _button = GetTemplateChild("PART_Button") as Button;
        }
    }

    public static class ControlCommands
    {
        private static RoutedCommand _updateTextCommand = new RoutedCommand();
        public static RoutedCommand UpdateTextCommand => _updateTextCommand;
    }
}

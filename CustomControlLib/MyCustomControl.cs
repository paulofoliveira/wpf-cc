using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomControlLib
{
    public class MyCustomControl : Control, ICommandSource
    {
        private Border _border;
        static MyCustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCustomControl), new FrameworkPropertyMetadata(typeof(MyCustomControl)));
        }

        // Mantem uma cópia do CanExecuteChanged handler então não é coletada pela GC.

        private EventHandler _canExecuteChangedHandler;

        [TypeConverter(typeof(CommandConverter))]
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(MyCustomControl), new PropertyMetadata(null, new PropertyChangedCallback(OnCommandChanged)));
        private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as MyCustomControl;
            control?.OnCommandChanged((ICommand)e.OldValue, (ICommand)e.NewValue);
        }
        private void OnCommandChanged(ICommand oldValue, ICommand newValue)
        {
            if (oldValue != null)
                UnhookCommand(oldValue, newValue);

            HookupCommmand(oldValue, newValue);

            CanExecuteChanged(null, null);
        }

        private void UnhookCommand(ICommand oldCommand, ICommand newCommand)
        {
            EventHandler handler = CanExecuteChanged;
            oldCommand.CanExecuteChanged -= CanExecuteChanged;
        }

        private void HookupCommmand(ICommand oldCommand, ICommand newCommand)
        {
            var handler = new EventHandler(CanExecuteChanged);
            _canExecuteChangedHandler = handler;

            if (newCommand != null)
                newCommand.CanExecuteChanged += _canExecuteChangedHandler;
        }

        private void CanExecuteChanged(object sender, EventArgs e)
        {
            if (Command != null)
            {
                var routedCommand = Command as RoutedCommand;
                IsEnabled = routedCommand != null ? routedCommand.CanExecute(CommandParameter, CommandTarget) : Command.CanExecute(CommandParameter);
            }
        }

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register("CommandParameter", typeof(object), typeof(MyCustomControl), new PropertyMetadata(null));
        public IInputElement CommandTarget
        {
            get { return (IInputElement)GetValue(CommandTargetProperty); }
            set { SetValue(CommandTargetProperty, value); }
        }

        public static readonly DependencyProperty CommandTargetProperty = DependencyProperty.Register("CommandTarget", typeof(IInputElement), typeof(MyCustomControl), new PropertyMetadata(null));
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (_border != null)
                _border.MouseLeftButtonUp -= Border_MouseLeftButtonUp;

            _border = GetTemplateChild("PART_Border") as Border;

            if (_border != null)
                _border.MouseLeftButtonUp += Border_MouseLeftButtonUp;
        }
        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RaiseCommand();
        }

        private void RaiseCommand()
        {
            if (Command != null)
            {
                var routedCommand = Command as RoutedCommand;

                if (routedCommand != null)
                    routedCommand.Execute(CommandParameter, CommandTarget);
                else
                    Command.Execute(CommandParameter);
            }
        }
    }
}

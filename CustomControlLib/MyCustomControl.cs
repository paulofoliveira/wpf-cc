using System.Windows;
using System.Windows.Controls;

namespace CustomControlLib
{
    public class MyCustomControl : Control
    {
        static MyCustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCustomControl), new FrameworkPropertyMetadata(typeof(MyCustomControl)));
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            // TODO: Para propósito de demo, check instâncias antes de remover o handler primeiro afim de evitar memory leaks.

            var button = GetTemplateChild("PART_Button") as Button;

            if (button != null)
            {
                button.Click += Button_Click;
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RaiseClickEvent();
        }

        // Registrar o evento como um RoutedEvent
        // Naming convention: <EVENT NAME>Event

        public static readonly RoutedEvent ClickEvent = EventManager.RegisterRoutedEvent("Click",
            RoutingStrategy.Bubble,
            typeof(MyRoutedEventHandler),
            typeof(MyCustomControl));

        // O nome do evento deve bater com a string registrada no EventManager.

        public event MyRoutedEventHandler Click
        {
            add { AddHandler(ClickEvent, value); }
            remove { RemoveHandler(ClickEvent, value); }
        }
        protected virtual void RaiseClickEvent()
        {
            var args = new MyRoutedEventArgs(ClickEvent, "Test");
            RaiseEvent(args);
        }

        public delegate void MyRoutedEventHandler(object sender, MyRoutedEventArgs e);
    }

    /// <summary>
    /// Instance of MyRoutedEventArgs' class
    /// </summary>
    public class MyRoutedEventArgs : RoutedEventArgs
    {
        public MyRoutedEventArgs(RoutedEvent @event, string param)
        {
            Param = param;
        }
        public string Param { get; }
    }
}

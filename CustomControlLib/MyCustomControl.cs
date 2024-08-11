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
            typeof(RoutedEventHandler),
            typeof(MyCustomControl));

        // O nome do evento deve bater com a string registrada no EventManager.

        public event RoutedEventHandler Click
        {
            add { AddHandler(ClickEvent, value); }
            remove { RemoveHandler(ClickEvent, value); }
        }
        protected virtual void RaiseClickEvent()
        {
            var args = new RoutedEventArgs(ClickEvent);
            RaiseEvent(args);
        }

    }
}

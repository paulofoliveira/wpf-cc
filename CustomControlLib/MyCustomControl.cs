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

        public MyCustomControl()
        {

        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(MyCustomControl),
                new FrameworkPropertyMetadata(string.Empty,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    new PropertyChangedCallback(OnTextPropertyChanged),
                    new CoerceValueCallback(OnTextPropertyCoerce)));

        private static object OnTextPropertyCoerce(DependencyObject d, object baseValue)
        {
            //return "Value Changed";
            return baseValue;
        }

        private static void OnTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as MyCustomControl;
            if (control == null) return;
            control.OnTextPropertyChanged((string)e.OldValue, (string)e.NewValue);
        }
        protected virtual void OnTextPropertyChanged(string oldValue, string newValue)
        {

        }

        public void DoSomething()
        {

        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
    }
}


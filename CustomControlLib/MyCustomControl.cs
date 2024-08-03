using System.Windows;
using System.Windows.Controls;

namespace CustomControlLib
{
    public class MyCustomControl : Control
    {
        private const string ButtonPartName = "PART_Button";
        static MyCustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCustomControl), new FrameworkPropertyMetadata(typeof(MyCustomControl)));
        }

        private Button _button;
        public Button Button
        {
            get => _button;
            set
            {
                if (_button != null)
                    _button.Click -= Button_Click;

                _button = value;
                if (_button == null) return;
                _button.Click += Button_Click;
            }
        }

        private static readonly DependencyPropertyKey HasBeenClickedPropertyKey =
            DependencyProperty.RegisterReadOnly("HasBeenClicked",
                typeof(bool),
                typeof(MyCustomControl),
                new PropertyMetadata(false));

        private static readonly DependencyProperty HasBeenClickedProperty = HasBeenClickedPropertyKey.DependencyProperty;
        public bool HasBeenClicked => (bool)GetValue(HasBeenClickedProperty);
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Button = GetTemplateChild(ButtonPartName) as Button;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SetValue(HasBeenClickedPropertyKey, true);
        }
    }
}

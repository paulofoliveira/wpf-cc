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

            // TODO: Demo purposes only, check for previous instances and remove handler first.

            var button = GetTemplateChild("PART_Button") as Button;

            if (button != null)
            {
                button.Click += Button_Click;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SetValue(HasBeenClickedPropertyKey, true);
        }
    }
}

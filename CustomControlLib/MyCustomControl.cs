using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomControlLib
{
    public class MyCustomControl : Control
    {
        static MyCustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCustomControl), new FrameworkPropertyMetadata(typeof(MyCustomControl)));
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(MyCustomControl), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        private void UpdateVisualState(bool useTransitions)
        {
            if (IsMouseOver)
                VisualStateManager.GoToState(this, "MouseOver", useTransitions);
            else
                VisualStateManager.GoToState(this, "Normal", useTransitions);
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            UpdateVisualState(true);
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            UpdateVisualState(true);
        }
    }
}

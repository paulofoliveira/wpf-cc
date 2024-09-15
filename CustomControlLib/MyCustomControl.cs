using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomControlLib
{
    public class MyCustomControl : Control
    {
        private Border _border;
        static MyCustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCustomControl), new FrameworkPropertyMetadata(typeof(MyCustomControl)));
        }

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

        }
    }
}

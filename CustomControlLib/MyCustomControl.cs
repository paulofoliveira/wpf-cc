using System;
using System.Windows;
using System.Windows.Controls;

namespace CustomControlLib
{
    public class MyCustomControl : ContentControl
    {
        static MyCustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCustomControl), new FrameworkPropertyMetadata(typeof(MyCustomControl)));
        }

        public int ChildCount
        {
            get => (int)GetValue(ChildCountProperty);
            set => SetValue(ChildCountProperty, value);
        }

        public static readonly DependencyProperty ChildCountProperty =
            DependencyProperty.Register("ChildCount", typeof(int), typeof(MyCustomControl), new PropertyMetadata(0));

        public static readonly DependencyProperty IncludeChildCountProperty =
            DependencyProperty.RegisterAttached("IncludeChildCount", typeof(bool), typeof(MyCustomControl), new PropertyMetadata(false));
        public static bool GetIncludeChildCount(DependencyObject obj) => (bool)obj.GetValue(IncludeChildCountProperty);
        public static void SetIncludeChildCount(DependencyObject obj, bool value) => obj.SetValue(IncludeChildCountProperty, value);

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            if (Content == null) return;

            if (GetIncludeChildCount(Content as DependencyObject))
                ChildCount++;

            var panel = Content as Panel;
            if (panel == null) return;

            foreach (FrameworkElement child in panel.Children)
                if (GetIncludeChildCount(child))
                    ChildCount++;
        }
    }
}

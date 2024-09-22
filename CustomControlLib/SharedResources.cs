using System.Windows;

namespace CustomControlLib
{
    public static class SharedResources
    {
        private static ComponentResourceKey _brushKey = new ComponentResourceKey(typeof(SharedResources), "CommonBrush");
        public static ComponentResourceKey CommonBrushKey => _brushKey;
    }
}

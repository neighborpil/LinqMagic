using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Ex4_1
{
    public static class VisualTreeExtensions
    {
        // 指摘した型の子孫要素を取得
        public static IEnumerable<T> Descendants<T>(this DependencyObject control) where T : DependencyObject
        {
            return control.Descendants().OfType<T>();
        }

        // すべての子孫要素を取得
        public static IEnumerable<DependencyObject> Descendants(this DependencyObject control)
        {
            foreach (var child in control.Children())
            {
                yield return child;
                foreach (var c in child.Descendants())
                {
                    yield return c;
                }
            }
        }

        // 直接の子要素を取得
        public static IEnumerable<DependencyObject> Children(this DependencyObject control)
        {
            var count = VisualTreeHelper.GetChildrenCount(control);
            for (int i = 0; i < count; i++)
            {
                yield return VisualTreeHelper.GetChild(control, i);
            }
        }
    }
}

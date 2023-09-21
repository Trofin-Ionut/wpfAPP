using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows;

namespace WpfApp1.Refresh
{
    public static class UiRefresh
    {

        private static Action EmptyDelegate = delegate () { };


        public static void Refresh(this UIElement uiElement)
        {
            uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }
}

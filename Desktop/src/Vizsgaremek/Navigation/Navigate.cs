using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Futóverseny.Navigation
{
    public static class Navigate
    {
        //Eltároljuk a mainwindowt, hogy tudjunk váltani ablakot (pages)
        public static MainWindow mainWindow;


        /// <summary>
        /// Egy új ablakra vált 
        /// </summary>
        /// <param name="userControl">Erre az ablakra váltunk</param>
        public static void Navigation(UserControl userControl)
        {
            mainWindow.PageContent.Children.Clear();
            mainWindow.PageContent.Children.Add(userControl);
        }

        public static void Navigation(Page userpPage)
        {
            mainWindow.PageContent.Children.Add(userpPage);
        }
    }

    
}

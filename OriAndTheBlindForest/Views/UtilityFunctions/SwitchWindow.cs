using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OriAndTheBlindForest.Views.UtilityFunctions
{
    public class SwitchWindow
    {
        public static void Switch(Window incoming, Window outgoing)
        {
            incoming.Close();
            outgoing.WindowState = WindowState.Maximized;
            outgoing.WindowStyle = WindowStyle.ToolWindow;
            outgoing.Show();
        }


    }
}

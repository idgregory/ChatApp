using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApp
{
    public static class Globals
    {
        public static string ConnString = "Server=localhost;" + "Database=DemoDB;" + "Integrated Security=True;";
        public static int? UserID { get; set; } = null;
        public static MainWindow MainWindow {get; set;} 
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Globals.MainWindow = new MainWindow();
            Application.Run(Globals.MainWindow);
        }
}
}

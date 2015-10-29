using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentAdministration
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //Ik heb deze file nu aangepast. Superveel extra features enzo.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StudentForm());
            String s = "Supermooie nuttige string ofzo";
            String test = "Hallo dit is een test";
            test += ".";
            test += "...";
        }
    }
}

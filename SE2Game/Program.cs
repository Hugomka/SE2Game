using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE2Game
{
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
<<<<<<< HEAD:w8-student_administration/Program.cs
            Application.Run(new StudentForm());
            String s = "Supermooie nuttige string ofzo";
            String test = "Hallo dit is een test";
            test += ".";
=======
            Application.Run(new SE2GameForm());
>>>>>>> 1e00c66bb1f5f487c7e311bb9256399c839ecf0d:SE2Game/Program.cs
        }
    }
}

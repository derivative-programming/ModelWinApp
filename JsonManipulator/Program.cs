using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonManipulator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            List<string> argList = new List<string>();
            if (args != null)
                argList.AddRange(args);

            string initModelPath = string.Empty;

            for (int i = 0; i < argList.Count; i++)
            {
                if (argList[i].ToLower() == "-f" && (argList.Count - 1) > i)
                {
                    initModelPath = argList[i + 1];
                }
            }

            Application.Run(new Form1(initModelPath));
        }
    }
}

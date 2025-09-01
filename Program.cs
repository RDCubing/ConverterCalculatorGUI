using System;
using System.Windows.Forms;

namespace ConverterCalculatorGUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();               // Modern look
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());                  // Launch main form
        }
    }
}

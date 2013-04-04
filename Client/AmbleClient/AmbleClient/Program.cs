using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using log4net;
using System.IO;


namespace AmbleClient
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new Login());
            }
            catch (Exception ex)
            {
                MessageBox.Show("System error,please restart the program");
                Logger.Fatal(ex.Message);
                Logger.Fatal(ex.StackTrace);
            }
            
       }

    }
}

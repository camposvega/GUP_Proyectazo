using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pro00081511
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
            CManage.Instance.User = new CUser();
            String txt = Prompt.ShowDialog("UserName", "Username");
            CManage.Instance.User.Username = txt.Equals("") ? "user" : txt;
            CManage.Instance.createUser(txt);
            CManage.Instance.FormMain = new Form1();
            
            Application.Run(CManage.Instance.FormMain);
            
        }
    }
}
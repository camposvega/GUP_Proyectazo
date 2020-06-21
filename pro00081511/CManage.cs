using System.Windows.Forms;

namespace pro00081511
{
    public class CManage
    {
        private static CManage instance = null;

        private Form1 formMain;
        private UserControl current = null;
        private IJBase playerBase;

    private CManage()
        {
        }
        
        public static CManage Instance
        {
            get
            {
                if (instance==null)
                {
                    instance = new CManage();
                }
                return instance;
            }
        }

        public Form1 FormMain
        {
            get => formMain;
            set => formMain = value;
        }

        public UserControl Current
        {
            get => current;
            set => current = value;
        }

        public IJBase PlayerBase
        {
            get => playerBase;
            set => playerBase = value;
        }
    }
}
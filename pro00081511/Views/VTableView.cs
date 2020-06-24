using System;
using System.Drawing;
using System.Windows.Forms;

namespace pro00081511.Views
{
    public partial class VTableView : UserControl
    {
        public VTableView()
        {
            InitializeComponent();
            tableLayoutPanel1.BackgroundImage = Image.FromFile("../../images/fondo.jpeg");
            tableLayoutPanel1.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CManage.Instance.FormMain.TableLayoutPanel1.Controls.Remove(this);
            CManage.Instance.Current = new VMainView();
            CManage.Instance.FormMain.TableLayoutPanel1.Controls.Add(CManage.Instance.Current,0,0);
            CManage.Instance.FormMain.TableLayoutPanel1.SetColumnSpan(CManage.Instance.Current,1); 
            
        }

        public TableLayoutPanel TableLayoutPanel1
        {
            get => tableLayoutPanel1;
            set => tableLayoutPanel1 = value;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000; // WS_EX_COMPOSITED       
                return handleParam;
            }
        }
    }
}
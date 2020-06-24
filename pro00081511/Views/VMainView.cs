using System;
using System.Drawing;
using System.Windows.Forms;

namespace pro00081511.Views
{
    public partial class VMainView : UserControl
    {
        
        public VMainView()
        {
            InitializeComponent();
            tableLayoutPanel1.BackgroundImage = Image.FromFile("../../images/fondo.jpeg");
            tableLayoutPanel1.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CManage.Instance.FormMain.TableLayoutPanel1.Controls.Remove(this);
            CManage.Instance.Current = new VTableView();
            //CManager.Instance.cambiarStrBtn(((Login)current).Button1,"Guardar");
            //CManager.Instance.cambiarReadO(((Login)current).TextBox1, true);
            CManage.Instance.FormMain.TableLayoutPanel1.Controls.Add(CManage.Instance.Current,0,0);
            CManage.Instance.FormMain.TableLayoutPanel1.SetColumnSpan(CManage.Instance.Current,1);
            CManage.Instance.showTopTen();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CManage.Instance.FormMain.TableLayoutPanel1.Controls.Remove(this);
            CManage.Instance.Current = new VMasterLevelView();
            CManage.Instance.FormMain.TableLayoutPanel1.Controls.Add(CManage.Instance.Current,0,0);
            CManage.Instance.FormMain.TableLayoutPanel1.SetColumnSpan(CManage.Instance.Current,1); 
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
using System;
using System.Drawing;
using System.Windows.Forms;

namespace pro00081511.Views
{
    public partial class VMasterLevelView : UserControl
    {
        public VMasterLevelView()
        {
            InitializeComponent();
            CManage.Instance.PlayerBase = new JBase();
        }

        private void VMasterLevelView_Load(object sender, EventArgs e)
        {
            
            pictureBox1.BackgroundImage = Image.FromFile(CManage.Instance.PlayerBase.Style);
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Top = CManage.Instance.PlayerBase.StartY;
            pictureBox1.Left = CManage.Instance.PlayerBase.StartX;

        }

        private void VMasterLevelView_KeyDown(object sender, KeyEventArgs e)
        {
            //e.KeyCode
            if (e.KeyCode.ToString().Equals("d") || e.KeyCode.ToString().Equals("D"))
            {
                //MessageBox.Show(pictureBox1.Left.ToString());
                if (pictureBox1.Left < 512  - pictureBox1.Width - 16)
                {
                    pictureBox1.Left = pictureBox1.Left + 4;   
                }
                else
                {
                    //MessageBox.Show(pictureBox1.Left.ToString());
                    //MessageBox.Show(pictureBox1.Left.ToString() + pictureBox1.Width.ToString()); 
                    //MessageBox.Show(pictureBox1.Width.ToString());
                }
            }
            
            if (e.KeyCode.ToString().Equals("a") || e.KeyCode.ToString().Equals("A"))
            {
                //MessageBox.Show(pictureBox1.Left.ToString());
                if (pictureBox1.Left > 0 )
                {
                    pictureBox1.Left = pictureBox1.Left - 4;    
                }
                
            }
            
        }

        private void VMasterLevelView_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show(e.KeyChar.ToString());
        }
    }
}
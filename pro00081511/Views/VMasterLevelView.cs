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
            CManage.Instance.PlayerBall = new JBall();
            CManage.Instance.CurrentLevel = new CLevel();
        }

        private void VMasterLevelView_Load(object sender, EventArgs e)
        {
            loadBase();
            loadBall();
            loadBlocks();
            timer1.Start();

        }

        private void VMasterLevelView_KeyDown(object sender, KeyEventArgs e)
        {
            moverPlayerBase(sender,e);
            if (!CManage.Instance.StartGame)
            {
                moverPelotaIni(sender,e);
            }
            continueGame(e);

        }

        private void loadBase()
        {
            pictureBox1.BackgroundImage = Image.FromFile(CManage.Instance.PlayerBase.Style);
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Top = CManage.Instance.PlayerBase.StartY;
            pictureBox1.Left = CManage.Instance.PlayerBase.StartX;
        }

        private void loadBall()
        {
            pictureBox2.BackgroundImage = Image.FromFile(CManage.Instance.PlayerBall.Style);
            pictureBox2.Width = CManage.Instance.PlayerBall.Width;
            pictureBox2.Height = CManage.Instance.PlayerBall.Heigth;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Top = CManage.Instance.PlayerBall.StartY;
            pictureBox2.Left = pictureBox1.Left + (pictureBox1.Bounds.Width / 2)
                               - (pictureBox2.Bounds.Width/2);
        }

        private void loadBlocks()
        {
            //JBlock bl = new JBlock(0,0);

            CManage.Instance.createBlocks();

        }

        private void VMasterLevelView_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show(e.KeyChar.ToString());
        }

        private void moverPlayerBase(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString().Equals("d") || e.KeyCode.ToString().Equals("D"))
            {
                //MessageBox.Show(pictureBox1.Left.ToString());
                if (pictureBox1.Left < 512  - pictureBox1.Width - 16)
                {
                    pictureBox1.Left = pictureBox1.Left + 8;   
                }
                else
                {
                    //MessageBox.Show(pictureBox1.Left.ToString());
                    //MessageBox.Show(pictureBox1.Left.ToString() + pictureBox1.Width.ToString()); 
                    //MessageBox.Show(pictureBox1.Width.ToString());
                }
            }
            
            else if (e.KeyCode.ToString().Equals("a") || e.KeyCode.ToString().Equals("A"))
            {
                //MessageBox.Show(pictureBox1.Left.ToString());
                if (pictureBox1.Left > 0 )
                {
                    pictureBox1.Left = pictureBox1.Left - 8;    
                }
                
            }
        }

        private void moverPelotaIni(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString().Equals("d") || e.KeyCode.ToString().Equals("D"))
            {
                //MessageBox.Show(pictureBox1.Left.ToString());
                pictureBox2.Left = pictureBox1.Left + (pictureBox1.Bounds.Width / 2)
                    - (pictureBox2.Bounds.Width/2);
            }
            
            else if (e.KeyCode.ToString().Equals("a") || e.KeyCode.ToString().Equals("A"))
            {
                //MessageBox.Show(pictureBox1.Left.ToString());
                pictureBox2.Left = pictureBox1.Left + (pictureBox1.Bounds.Width / 2)
                                   - (pictureBox2.Bounds.Width/2);

            }
        }

        private void continueGame(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space  && !CManage.Instance.StartGame)
            {
                CManage.Instance.StartGame = true;
                CManage.Instance.PauseGame = true;
            }else if (e.KeyCode == Keys.Space)
            {
                CManage.Instance.PauseGame = !CManage.Instance.PauseGame;
            }
        }

        private void bounceBall()
        {
            if (pictureBox2.Left < 0)
            {
                CManage.Instance.BallX = 8;
                return;
            }
            if (pictureBox2.Right > (512 - pictureBox2.Width))
            {
                CManage.Instance.BallX = -8;
                return;
            }
            if (pictureBox2.Top < 0)
            {
                CManage.Instance.BallY = 8;
                return;
            }

            if (pictureBox2.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                CManage.Instance.BallY = -8;
                return;
            }

            for (int i = 0; i < CManage.Instance.DimensionX; i++)
            {
                for (int j = 0; j < CManage.Instance.DimensionY; j++)
                {
                    if (pictureBox2.Bounds.IntersectsWith(CManage.Instance.MBlocks[i,j].Bounds))
                    {
                        if (((IJBlock)CManage.Instance.MBlocks[i, j]).aLive())
                        {
                            CManage.Instance.PauseGame = false;
                        }
                        if (((IJBlock)CManage.Instance.MBlocks[i, j]).aLive() 
                            && (pictureBox2.Top + Constants.MARGIN_OFF == CManage.Instance.MBlocks[i, j].Bottom))
                        {
                            CManage.Instance.BallY = 8;
                            ((IJBlock) CManage.Instance.MBlocks[i, j]).takeDamage(
                                CManage.Instance.PlayerBall.MakeDamage());
                            if(!((IJBlock)CManage.Instance.MBlocks[i,j]).aLive()){
                                CManage.Instance.Current.Controls.Remove(CManage.Instance.MBlocks[i,j]);
                            }
                            
                            CManage.Instance.PauseGame = true;
                            return;
                        }
                        if (((IJBlock)CManage.Instance.MBlocks[i, j]).aLive() 
                        && pictureBox2.Right - 2 == CManage.Instance.MBlocks[i,j].Left)
                        {
                            CManage.Instance.BallX = -8;
                            ((IJBlock) CManage.Instance.MBlocks[i, j]).takeDamage(
                                CManage.Instance.PlayerBall.MakeDamage());
                            if(!((IJBlock)CManage.Instance.MBlocks[i,j]).aLive()){
                                CManage.Instance.Current.Controls.Remove(CManage.Instance.MBlocks[i,j]);
                            }
                            
                            CManage.Instance.PauseGame = true;
                            return;
                        }if (((IJBlock)CManage.Instance.MBlocks[i, j]).aLive() 
                             && pictureBox2.Right - 8 == CManage.Instance.MBlocks[i,j].Left)
                        {
                            CManage.Instance.BallX = -8;
                            ((IJBlock) CManage.Instance.MBlocks[i, j]).takeDamage(
                                CManage.Instance.PlayerBall.MakeDamage());
                            if(!((IJBlock)CManage.Instance.MBlocks[i,j]).aLive()){
                                CManage.Instance.Current.Controls.Remove(CManage.Instance.MBlocks[i,j]);
                            }
                            
                            CManage.Instance.PauseGame = true;
                            return;
                        }
                        if (((IJBlock)CManage.Instance.MBlocks[i, j]).aLive() 
                             && pictureBox2.Right - 8 == CManage.Instance.MBlocks[i,j].Left)
                        {
                            CManage.Instance.BallX = -8;
                            ((IJBlock) CManage.Instance.MBlocks[i, j]).takeDamage(
                                CManage.Instance.PlayerBall.MakeDamage());
                            if(!((IJBlock)CManage.Instance.MBlocks[i,j]).aLive()){
                                CManage.Instance.Current.Controls.Remove(CManage.Instance.MBlocks[i,j]);
                            }
                            
                            CManage.Instance.PauseGame = true;
                            return;
                        }
                        
                        if (((IJBlock)CManage.Instance.MBlocks[i, j]).aLive() 
                             && pictureBox2.Right  == CManage.Instance.MBlocks[i,j].Right+2)
                        {
                            CManage.Instance.BallX = 8;
                            ((IJBlock) CManage.Instance.MBlocks[i, j]).takeDamage(
                                CManage.Instance.PlayerBall.MakeDamage());
                            if(!((IJBlock)CManage.Instance.MBlocks[i,j]).aLive()){
                                CManage.Instance.Current.Controls.Remove(CManage.Instance.MBlocks[i,j]);
                            }
                            
                            CManage.Instance.PauseGame = true;
                            return;
                        }if (((IJBlock)CManage.Instance.MBlocks[i, j]).aLive() 
                             && pictureBox2.Left + 6  == CManage.Instance.MBlocks[i,j].Right)
                        {
                            CManage.Instance.BallX = 8;
                            ((IJBlock) CManage.Instance.MBlocks[i, j]).takeDamage(
                                CManage.Instance.PlayerBall.MakeDamage());
                            if(!((IJBlock)CManage.Instance.MBlocks[i,j]).aLive()){
                                CManage.Instance.Current.Controls.Remove(CManage.Instance.MBlocks[i,j]);
                            }
                            
                            CManage.Instance.PauseGame = true;
                            return;
                        }
                        if (((IJBlock)CManage.Instance.MBlocks[i, j]).aLive() 
                            && (pictureBox2.Left + 8 == CManage.Instance.MBlocks[i, j].Right))
                        {
                            CManage.Instance.BallX = 8;
                            ((IJBlock) CManage.Instance.MBlocks[i, j]).takeDamage(
                                CManage.Instance.PlayerBall.MakeDamage());
                            if(!((IJBlock)CManage.Instance.MBlocks[i,j]).aLive()){
                                CManage.Instance.Current.Controls.Remove(CManage.Instance.MBlocks[i,j]);
                            }
                            
                            CManage.Instance.PauseGame = true;
                            return;
                        }
                        
                        if (((IJBlock)CManage.Instance.MBlocks[i, j]).aLive() 
                            && pictureBox2.Bottom - 5  == CManage.Instance.MBlocks[i,j].Top)
                        {
                            CManage.Instance.BallY = -8;
                            ((IJBlock) CManage.Instance.MBlocks[i, j]).takeDamage(
                                CManage.Instance.PlayerBall.MakeDamage());
                            if(!((IJBlock)CManage.Instance.MBlocks[i,j]).aLive()){
                                CManage.Instance.Current.Controls.Remove(CManage.Instance.MBlocks[i,j]);
                            }
                            CManage.Instance.PauseGame = true;
                            return;
                        }
                        if(((IJBlock)CManage.Instance.MBlocks[i, j]).aLive() )
                        {
                            CManage.Instance.BallY = -8;
                            ((IJBlock) CManage.Instance.MBlocks[i, j]).takeDamage(
                                CManage.Instance.PlayerBall.MakeDamage());
                            if(!((IJBlock)CManage.Instance.MBlocks[i,j]).aLive()){
                                CManage.Instance.Current.Controls.Remove(CManage.Instance.MBlocks[i,j]);
                            }
                            
                            CManage.Instance.PauseGame = true;
                            return;
                            
                        }
                    }
                }
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!CManage.Instance.PauseGame) return;
            pictureBox2.Left += CManage.Instance.BallX;
            pictureBox2.Top += CManage.Instance.BallY;
            bounceBall();
        }
        
    }
}
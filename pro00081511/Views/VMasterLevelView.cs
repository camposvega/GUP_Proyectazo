﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace pro00081511.Views
{
    public partial class VMasterLevelView : UserControl
    {
        private String lastKey = "";
        public VMasterLevelView()
        {
            InitializeComponent();
            
            CManage.Instance.PlayerBase = new JBase();
            CManage.Instance.PlayerBall = new JBall();
            CManage.Instance.CurrentLevel = new CLevel();
        }

        private void VMasterLevelView_Load(object sender, EventArgs e)
        {
            BackgroundImage = Image.FromFile("../../images/gameBG.jpeg");
            BackgroundImageLayout = ImageLayout.Stretch;
            CManage.Instance.User.Healt = Constants.HEART_NUMBER;
            CManage.Instance.Healts = new List<PictureBox>();
            loadBase();
            loadBall();
            loadBlocks();
            timer1.Start();
            CManage.Instance.healtUser();
        }

        private void VMasterLevelView_KeyDown(object sender, KeyEventArgs e)
        {
            if ((!CManage.Instance.StartGame && !CManage.Instance.PauseGame) ||
                (CManage.Instance.StartGame && CManage.Instance.PauseGame))
            {
                moverPlayerBase(sender,e);
            }
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
            pictureBox1.BackColor = Color.FromArgb(45, 47, 124);
            pictureBox1.Top = CManage.Instance.PlayerBase.StartY;
            pictureBox1.Left = CManage.Instance.PlayerBase.StartX;
        }

        private void loadBall()
        {
            pictureBox2.BackgroundImage = Image.FromFile(CManage.Instance.PlayerBall.Style);
            pictureBox2.Width = CManage.Instance.PlayerBall.Width;
            pictureBox2.Height = CManage.Instance.PlayerBall.Heigth;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.BackColor = Color.FromArgb(45, 47, 124);
            pictureBox2.Top = CManage.Instance.PlayerBall.StartY;
            pictureBox2.Left = pictureBox1.Left + (pictureBox1.Bounds.Width / 2)
                               - (pictureBox2.Bounds.Width/2);
        }

        private void loadBlocks()
        {
            //JBlock bl = new JBlock(0,0);

            CManage.Instance.createBlocks();

        }

        private void moverPlayerBase(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString().Equals("d") || e.KeyCode.ToString().Equals("D"))
            {
                //MessageBox.Show(pictureBox1.Left.ToString());
                if (pictureBox1.Left < 512  - pictureBox1.Width - 16)
                {
                    pictureBox1.Left = pictureBox1.Left + 16;
                    lastKey = "d";
                }
            }
            
            else if (e.KeyCode.ToString().Equals("a") || e.KeyCode.ToString().Equals("A"))
            {
                //MessageBox.Show(pictureBox1.Left.ToString());
                if (pictureBox1.Left > 0 )
                {
                    pictureBox1.Left = pictureBox1.Left - 16; 
                    lastKey = "a";
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
            if (bounceWindow()) return;
            if (bounceWithPlayer()) return;
            bounceWithBlock();
            outOfWindow();

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!CManage.Instance.PauseGame) return;
            pictureBox2.Left += CManage.Instance.BallX;
            pictureBox2.Top += CManage.Instance.BallY;
            bounceBall();
        }

        private void outOfWindow()
        {
            if (pictureBox2.Top > 512)
            {
                CManage.Instance.StartGame = false;
                CManage.Instance.PauseGame = false;

                if (stillAlive())
                {
                    CManage.Instance.BallX = Constants.BALL_MOVEMENT;
                    CManage.Instance.BallY = -Constants.BALL_MOVEMENT;
                
                    pictureBox1.Top = CManage.Instance.PlayerBase.StartY;
                    pictureBox1.Left = CManage.Instance.PlayerBase.StartX;
                
                    pictureBox2.Top = CManage.Instance.PlayerBall.StartY;
                    pictureBox2.Left = pictureBox1.Left + (pictureBox1.Bounds.Width / 2)
                                       - (pictureBox2.Bounds.Width/2);
                }
                else
                {
                    CManage.Instance.FormMain.TableLayoutPanel1.Controls.Remove(this);
                    CManage.Instance.Current = new VMainView();
                    
                    CManage.Instance.FormMain.TableLayoutPanel1.Controls.Add(CManage.Instance.Current,0,0);
                    CManage.Instance.FormMain.TableLayoutPanel1.SetColumnSpan(CManage.Instance.Current,1);
                    CManage.Instance.saveScore(CManage.Instance.User.Score);
                }
                
            }
            
        }

        private bool stillAlive()
        {
            CManage.Instance.User.Healt = CManage.Instance.User.Healt - 1;
            CManage.Instance.Current.Controls.Remove(CManage.Instance.Healts[CManage.Instance.User.Healt]);
            
            if (CManage.Instance.User.Healt < 1)
            {
                return false;
            }
            
            return true;
        }

        private bool bounceWindow()
        {
            if (pictureBox2.Left < 0)
            {
                CManage.Instance.BallX = Constants.BALL_MOVEMENT;
                return true;
            }
            if (pictureBox2.Right > (512 - pictureBox2.Width))
            {
                CManage.Instance.BallX = -Constants.BALL_MOVEMENT;
                return true;
            }
            if (pictureBox2.Top < 0)
            {
                CManage.Instance.BallY = Constants.BALL_MOVEMENT;
                return true;
            }

            return false;
        }

        private bool bounceWithPlayer()
        {
            if (pictureBox2.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                CManage.Instance.BallY = -Constants.BALL_MOVEMENT;
                CManage.Instance.BallX = lastKey.Equals("d") ? 
                    Constants.BALL_MOVEMENT : -Constants.BALL_MOVEMENT;
                return true;
            }

            return false;
        }

        private void bounceWithBlock()
        {
            for (int i = 0; i < CManage.Instance.DimensionX; i++)
            {
                for (int j = 0; j < CManage.Instance.DimensionY; j++)
                {
                    if (((IJBlock)CManage.Instance.MBlocks[i, j]).aLive() &&
                        pictureBox2.Bounds.IntersectsWith(CManage.Instance.MBlocks[i,j].Bounds))
                    {
                        CManage.Instance.User.Score = CManage.Instance.User.Score + 2;
                        CManage.Instance.PauseGame = false;
                        if ((pictureBox2.Top + Constants.MARGIN_OFF == CManage.Instance.MBlocks[i, j].Bottom) )
                        {
                            CManage.Instance.BallY = Constants.BALL_MOVEMENT;
                            ((IJBlock) CManage.Instance.MBlocks[i, j]).takeDamage(
                                CManage.Instance.PlayerBall.MakeDamage());
                            if(!((IJBlock)CManage.Instance.MBlocks[i,j]).aLive()){
                                CManage.Instance.Current.Controls.Remove(CManage.Instance.MBlocks[i,j]);
                            }
                            
                            CManage.Instance.PauseGame = true;
                            return;
                        }
                        if (pictureBox2.Right - 2 == CManage.Instance.MBlocks[i,j].Left)
                        {
                            CManage.Instance.BallX = -Constants.BALL_MOVEMENT;
                            ((IJBlock) CManage.Instance.MBlocks[i, j]).takeDamage(
                                CManage.Instance.PlayerBall.MakeDamage());
                            if(!((IJBlock)CManage.Instance.MBlocks[i,j]).aLive()){
                                CManage.Instance.Current.Controls.Remove(CManage.Instance.MBlocks[i,j]);
                            }
                            
                            CManage.Instance.PauseGame = true;
                            return;
                        }
                        if (pictureBox2.Right - 8 == CManage.Instance.MBlocks[i,j].Left)
                        {
                            CManage.Instance.BallX = -Constants.BALL_MOVEMENT;
                            ((IJBlock) CManage.Instance.MBlocks[i, j]).takeDamage(
                                CManage.Instance.PlayerBall.MakeDamage());
                            if(!((IJBlock)CManage.Instance.MBlocks[i,j]).aLive()){
                                CManage.Instance.Current.Controls.Remove(CManage.Instance.MBlocks[i,j]);
                            }
                            
                            CManage.Instance.PauseGame = true;
                            return;
                        }
                        if (pictureBox2.Right - 8 == CManage.Instance.MBlocks[i,j].Left)
                        {
                            CManage.Instance.BallX = -Constants.BALL_MOVEMENT;
                            ((IJBlock) CManage.Instance.MBlocks[i, j]).takeDamage(
                                CManage.Instance.PlayerBall.MakeDamage());
                            if(!((IJBlock)CManage.Instance.MBlocks[i,j]).aLive()){
                                CManage.Instance.Current.Controls.Remove(CManage.Instance.MBlocks[i,j]);
                            }
                            
                            CManage.Instance.PauseGame = true;
                            return;
                        }
                        if (pictureBox2.Right  == CManage.Instance.MBlocks[i,j].Right+2)
                        {
                            CManage.Instance.BallX = Constants.BALL_MOVEMENT;
                            ((IJBlock) CManage.Instance.MBlocks[i, j]).takeDamage(
                                CManage.Instance.PlayerBall.MakeDamage());
                            if(!((IJBlock)CManage.Instance.MBlocks[i,j]).aLive()){
                                CManage.Instance.Current.Controls.Remove(CManage.Instance.MBlocks[i,j]);
                            }
                            
                            CManage.Instance.PauseGame = true;
                            return;
                        }if ( pictureBox2.Left + 6  == CManage.Instance.MBlocks[i,j].Right)
                        {
                            CManage.Instance.BallX = Constants.BALL_MOVEMENT;
                            ((IJBlock) CManage.Instance.MBlocks[i, j]).takeDamage(
                                CManage.Instance.PlayerBall.MakeDamage());
                            if(!((IJBlock)CManage.Instance.MBlocks[i,j]).aLive()){
                                CManage.Instance.Current.Controls.Remove(CManage.Instance.MBlocks[i,j]);
                            }
                            
                            CManage.Instance.PauseGame = true;
                            return;
                        }
                        if ((pictureBox2.Left + 8 == CManage.Instance.MBlocks[i, j].Right))
                        {
                            CManage.Instance.BallX = Constants.BALL_MOVEMENT;
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
                            CManage.Instance.BallY = -Constants.BALL_MOVEMENT;
                            ((IJBlock) CManage.Instance.MBlocks[i, j]).takeDamage(
                                CManage.Instance.PlayerBall.MakeDamage());
                            if(!((IJBlock)CManage.Instance.MBlocks[i,j]).aLive()){
                                CManage.Instance.Current.Controls.Remove(CManage.Instance.MBlocks[i,j]);
                            }
                            CManage.Instance.PauseGame = true;
                            return;
                        }
                        
                        CManage.Instance.BallY = -Constants.BALL_MOVEMENT;
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
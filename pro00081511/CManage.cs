using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using pro00081511.Views;

namespace pro00081511
{
    public class CManage
    {
        private static CManage instance = null;
        private bool startGame = false;
        private bool pauseGame = false;
        private Form1 formMain;
        private UserControl current = null;
        private IJBase playerBase;
        private IJBall playerBall;
        private int ballX = 8;
        private int ballY = -8;
        private PictureBox[,] mBlocks;
        private int dimensionX = 7;
        private int dimensionY = 4;
        private CLevel currentLevel;
        private CUser user;
        private List<PictureBox> healts;

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

        public void healtUser()
        {
            for (int i = 0; i < user.Healt; i++)
            {
                healts.Add(new PictureBox());
                healts[i].BackgroundImage = Image.FromFile("../../images/heart.png");
                healts[i].BackgroundImageLayout = ImageLayout.Stretch; 
                healts[i].Width = Constants.HEART_WIDTH_HEIGTH;
                healts[i].Height = Constants.HEART_WIDTH_HEIGTH;
                healts[i].Top = 0;
                healts[i].Left = i * Constants.HEART_WIDTH_HEIGTH + 4;
                current.Controls.Add(healts[i]);
                
            }
        }

        public void createBlocks()
        {
            mBlocks = currentLevel.showLevel(new PictureBox[dimensionX,dimensionY], 
                current, dimensionX, dimensionY);
        }

        public void createUser(String txt)
        {
            try
            {
                ConnectioBDD.executeNonQuery($"INSERT INTO PRO_USER (USERNAME) VALUES ('{txt}')");
            }
            catch (Exception e)
            {
                //MessageBox.Show("Ocurrio un error en conn a la BD: " + e);
                
            }
        }
        
        public void saveScore(int txt)
        {
            try
            {
                ConnectioBDD.executeNonQuery($"INSERT INTO PRO_SCORE (ID_USER, SCORE) " +
                                             $"SELECT ID_USER, '{txt}' FROM PRO_USER WHERE " +
                                             $"USERNAME = '{user.Username}'");
            }
            catch (Exception e)
            {
                //MessageBox.Show("Ocurrio un error en conn a la BD: " + e);
                
            }
        }

        public void showTopTen()
        {
            try
            {
                DataTable dataT = ConnectioBDD.executeQuery("SELECT a.username, b.score FROM PRO_score b "+ 
                "inner join pro_user a on b.id_user = a.id_user order by b.score desc limit 10");
                //MessageBox.Show(data.Rows[0][0].ToString());
                for (int i = 0; i < dataT.Rows.Count; i++)
                {
                    var label = new Label();
                    label.Dock = DockStyle.Fill;
                    label.Text = dataT.Rows[i][0].ToString();
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    var label2 = new Label();
                    label2.Dock = DockStyle.Fill;
                    label2.Text = dataT.Rows[i][1].ToString();
                    label2.TextAlign = ContentAlignment.MiddleCenter;

                    label.BackColor = Color.Transparent;
                    label.Parent = current;
                    
                    label2.BackColor = Color.Transparent;
                    label2.Parent = current;
                    
                    ((VTableView)current).TableLayoutPanel1.Controls.Add(label,0,i+1);
                    ((VTableView)current).TableLayoutPanel1.Controls.Add(label2,1,i+1);
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show("Ocurrio un error en conn a la BD: " + e);
                
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

        public IJBall PlayerBall
        {
            get => playerBall;
            set => playerBall = value;
        }

        public bool StartGame
        {
            get => startGame;
            set => startGame = value;
        }

        public int BallX
        {
            get => ballX;
            set => ballX = value;
        }

        public int BallY
        {
            get => ballY;
            set => ballY = value;
        }

        public bool PauseGame
        {
            get => pauseGame;
            set => pauseGame = value;
        }

        public CLevel CurrentLevel
        {
            get => currentLevel;
            set => currentLevel = value;
        }

        public int DimensionX
        {
            get => dimensionX;
            set => dimensionX = value;
        }

        public int DimensionY
        {
            get => dimensionY;
            set => dimensionY = value;
        }

        public PictureBox[,] MBlocks
        {
            get => mBlocks;
            set => mBlocks = value;
        }

        public CUser User
        {
            get => user;
            set => user = value;
        }

        public List<PictureBox> Healts
        {
            get => healts;
            set => healts = value;
        }
    }
}
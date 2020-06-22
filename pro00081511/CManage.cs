using System.Drawing;
using System.Windows.Forms;

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
        private int dimensionY = 3;
        private CLevel currentLevel;

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

        public void createBlocks()
        {
            mBlocks = currentLevel.showLevel(new PictureBox[dimensionX,dimensionY], 
                current, dimensionX, dimensionY);
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
    }
}
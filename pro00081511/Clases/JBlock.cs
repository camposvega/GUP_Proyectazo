using System.Windows.Forms;

namespace pro00081511
{
    public class JBlock :  PictureBox, IJBlock
    {
        public string Type { get; set; }
        public int Resistence { get; set; }
        public string Style { get; set; }

        public JBlock(int x,int y,string type = "1", int resistence = 4, string style = "../../images/1.png", 
            int width = Constants.BLOCK_DX, int heigth = Constants.BLOCK_DY) : base()
        {
            Height = heigth;
            Width = width;
            Top = y;
            Left = x;
            
            Type = type;
            Resistence = resistence;
            Style = style;
            
        }

        public int takeDamage(int damage)
        {
            Resistence = Resistence - damage;
            return Resistence;
        }

        public bool aLive()
        {
            if (Resistence < 0)
            {
                return false;
            }

            return true;
        }
    }
}
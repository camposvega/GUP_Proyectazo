using System.Windows.Forms;

namespace pro00081511
{
    public class JBlockStrength : PictureBox, IJBlock
    {
        public string Type { get; set; }
        public int Resistence { get; set; }
        public string Style { get; set; }

        public JBlockStrength(int x,int y,string type = "1", int resistence = 12, string style = "../../images/3.png", 
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
            throw new System.NotImplementedException();
        }

        public bool aLive()
        {
            if (Resistence <= 0)
            {
                return false;
            }

            return true;
        }
    }
}
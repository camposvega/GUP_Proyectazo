namespace pro00081511
{
    public class JBasePower : IJBase
    {
        public int Large { get; set; }
        public string Style { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }
        
        public JBasePower(int startX, int startY,int large = 256, string style = "../../images/playerDos.png")
        {
            Large = large;
            Style = style;
            StartX = startX;
            StartY = startY;
        }
    }
}
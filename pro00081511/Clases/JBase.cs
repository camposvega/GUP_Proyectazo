namespace pro00081511
{
    public class JBase : IJBase
    {
        public int Large { get; set; }
        public string Style { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }

        public JBase(int large = 128, string style = "../../images/player.png", int startX = 64, int startY = 436)
        {
            Large = large;
            Style = style;
            StartX = startX;
            StartY = startY;
        }
    }
}
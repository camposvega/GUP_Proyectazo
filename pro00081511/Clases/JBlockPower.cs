namespace pro00081511
{
    public class JBlockPower : IJBlock
    {
        public string Type { get; set; }
        public int Resistence { get; set; }
        public string Style { get; set; }

        public JBlockPower(string type="", int resistence = 8, string style="")
        {
            Type = type;
            Resistence = resistence;
            Style = style;
        }

        public void takeDamage(int damage)
        {
            int dmg = damage - 1;
            Resistence = Resistence - dmg;
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
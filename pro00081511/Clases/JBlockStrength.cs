namespace pro00081511
{
    public class JBlockStrength : IJBlock
    {
        public string Type { get; set; }
        public int Resistence { get; set; }
        public string Style { get; set; }

        public JBlockStrength(string type="", int resistence = 12, string style="")
        {
            Type = type;
            Resistence = resistence;
            Style = style;
        }

        public void takeDamage(int damage)
        {
            int dmg = damage / 2;
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
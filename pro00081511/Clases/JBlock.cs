﻿namespace pro00081511
{
    public class JBlock : IJBlock
    {
        public string Type { get; set; }
        public int Resistence { get; set; }
        public string Style { get; set; }

        public JBlock(string type="", int resistence = 4, string style="")
        {
            Type = type;
            Resistence = resistence;
            Style = style;
        }

        public void takeDamage(int damage)
        {
            Resistence = Resistence - damage;
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
﻿namespace pro00081511
{
    public class JBase : IJBase
    {
        public int Large { get; set; }
        public string Style { get; set; }

        public JBase(int large = 0, string style = "")
        {
            Large = large;
            Style = style;
        }
    }
}
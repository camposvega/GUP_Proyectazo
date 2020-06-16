namespace pro00081511
{
    public class JBasePower : IJBase
    {
        public int Large { get; set; }
        public string Style { get; set; }
        
        public JBasePower(int large = 0, string style = "")
        {
            Large = large;
            Style = style;
        }
    }
}
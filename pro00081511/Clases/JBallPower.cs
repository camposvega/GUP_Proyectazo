using System;

namespace pro00081511
{
    public class JBallPower : IJBall
    {
        
        public String Color { get; set; }
        public int Damage { get; set; }
        public String Nombre { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }
        public String Style { get; set; }
        public int Width{ get; set; }
        public int Heigth { get; set; }

        public JBallPower(string color, int damage, string nombre)
        {
            Color = color;
            Damage = damage;
            Nombre = nombre;
        }

        public int MakeDamage()
        {
            return Damage * 2;
        }
    }
}
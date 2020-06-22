using System;

namespace pro00081511
{
    public class JBall : IJBall
    {
        public String Color { get; set; }
        public int Damage { get; set; }
        public string Nombre { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }
        public String Style { get; set; }
        
        public int Width { get; set; }
        public int Heigth { get; set; }

        public JBall(String color = "", int damage = 4, String nombre = "Pelota basica", 
            int startX = 90, int startY = 413, String style = "../../images/ball.png", int w = 16
            , int h = 16)
        {
            Color = color;
            Damage = damage;
            Nombre = nombre;
            StartX = startX;
            StartY = startY;
            Style = style;
            Width = w;
            Heigth = h;
        }
        
        public int MakeDamage()
        {
            return Damage;
        }
    }
}
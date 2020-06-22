using System;

namespace pro00081511
{
    public interface IJBall
    {
        String Color { get; set; }
        int Damage { get; set; }
        String Nombre { get; set; }
        int StartX { get; set; }
        int StartY { get; set; }
        
        int Width { get; set; }
        int Heigth { get; set; }
        
        String Style { get; set; }

        int MakeDamage();

    }
}
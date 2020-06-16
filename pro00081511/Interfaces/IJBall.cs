using System;

namespace pro00081511
{
    public interface IJBall
    {
        String Color { get; set; }
        int Damage { get; set; }
        String Nombre { get; set; }

        int MakeDamage();

    }
}
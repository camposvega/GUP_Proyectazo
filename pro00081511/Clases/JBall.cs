﻿using System;

namespace pro00081511
{
    public class JBall : IJBall
    {
        
        public String Color { get; set; }
        public int Damage { get; set; }
        public string Nombre { get; set; }

        public JBall(string color, int damage, string nombre)
        {
            Color = color;
            Damage = damage;
            Nombre = nombre;
        }
        
        public int MakeDamage()
        {
            return Damage;
        }
    }
}
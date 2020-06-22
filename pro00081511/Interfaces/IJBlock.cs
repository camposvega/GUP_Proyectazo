using System;
using System.Windows.Forms;

namespace pro00081511
{
    public interface IJBlock 
    {
        
        String Type { get; set; }
        int Resistence { get; set; }
        String Style { get; set; }

        
        int takeDamage(int damage);

        bool aLive();
    }
}
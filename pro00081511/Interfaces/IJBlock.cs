using System;

namespace pro00081511
{
    public interface IJBlock
    {
        String Type { get; set; }
        int Resistence { get; set; }
        String Style { get; set; }

        void takeDamage(int damage);

        bool aLive();
    }
}
using System;

namespace pro00081511
{
    public class CUser
    {
        private String username;
        private int score;
        private int healt;

        public CUser(string username = "user", int score = 0, int healt = 3)
        {
            this.username = username;
            this.score = score;
            this.healt = healt;
        }

        public string Username
        {
            get => username;
            set => username = value;
        }

        public int Score
        {
            get => score;
            set => score = value;
        }

        public int Healt
        {
            get => healt;
            set => healt = value;
        }
    }
}
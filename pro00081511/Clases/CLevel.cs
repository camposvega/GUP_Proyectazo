namespace pro00081511
{
    public class CLevel
    {
        private int numBlocks;
        private int difficult;

        public CLevel(int numBlocks = 0, int difficult = 0)
        {
            this.numBlocks = numBlocks;
            this.difficult = difficult;
        }

        public int NumBlocks
        {
            get => numBlocks;
            set => numBlocks = value;
        }

        public int Difficult
        {
            get => difficult;
            set => difficult = value;
        }
    }
}
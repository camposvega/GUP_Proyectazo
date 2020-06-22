using System.Drawing;
using System.Windows.Forms;

namespace pro00081511
{
    public class CLevel
    {
        private int numBlocks;
        private int difficult;

        public CLevel(int numBlocks = 28, int difficult = 1)
        {
            this.numBlocks = numBlocks;
            this.difficult = difficult;
        }

        public PictureBox[,] showLevel(PictureBox[,] mBlocks, UserControl current,int dimensionX,
            int dimensionY)
        {
            for (int i = 0; i < dimensionX; i++)
            {
                for (int j = 0; j < dimensionY; j++)
                {
                    if (i == 0)
                    {
                        mBlocks[i,j] = new JBlock(0, (j * Constants.BLOCK_DY) + Constants.BLOCK_Distance_TOP);
                        mBlocks[i, j].BackgroundImage = Image.FromFile(((IJBlock)mBlocks[i,j]).Style);
                        mBlocks[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (i > 0 && i < 3)
                    {
                        if(i == 1)
                        {
                            mBlocks[i, j] = new JBlockPower(Constants.BLOCK_DX + Constants.BLOCK_SEPARADOR
                                , (j * Constants.BLOCK_DY) + Constants.BLOCK_Distance_TOP);
                        }
                        else
                        {
                            mBlocks[i, j] = new JBlockPower((Constants.BLOCK_DX*i) + Constants.BLOCK_SEPARADOR
                                , (j * Constants.BLOCK_DY) + Constants.BLOCK_Distance_TOP);
                        }
                        mBlocks[i, j].BackgroundImage = Image.FromFile(((IJBlock)mBlocks[i,j]).Style);
                        mBlocks[i, j].BackgroundImageLayout = ImageLayout.Stretch;   
                    }else if(i == 3)
                    {
                        mBlocks[i, j] = new JBlockStrength((Constants.BLOCK_DX*i) + Constants.BLOCK_SEPARADOR
                            , (j * Constants.BLOCK_DY) + Constants.BLOCK_Distance_TOP);
                        mBlocks[i, j].BackgroundImage = Image.FromFile(((IJBlock)mBlocks[i,j]).Style);
                        mBlocks[i, j].BackgroundImageLayout = ImageLayout.Stretch;  
                    }
                    else if (i > 3 && i < 6)
                    {
                        mBlocks[i, j] = new JBlockPower((Constants.BLOCK_DX*i) + Constants.BLOCK_SEPARADOR
                            , (j * Constants.BLOCK_DY) + Constants.BLOCK_Distance_TOP);
                        mBlocks[i, j].BackgroundImage = Image.FromFile(((IJBlock)mBlocks[i,j]).Style);
                        mBlocks[i, j].BackgroundImageLayout = ImageLayout.Stretch;   
                    }
                    else if(i == 6)
                    {
                        mBlocks[i, j] = new JBlock((Constants.BLOCK_DX*i) + (Constants.BLOCK_SEPARADOR*2)
                            , (j * Constants.BLOCK_DY) + Constants.BLOCK_Distance_TOP);
                        mBlocks[i, j].BackgroundImage = Image.FromFile(((IJBlock)mBlocks[i,j]).Style);
                        mBlocks[i, j].BackgroundImageLayout = ImageLayout.Stretch;  
                    }

                    //mBlocks[i, j].Margin = [0,0,0,0];
                    current.Controls.Add(mBlocks[i,j]);
                }
            }

            return mBlocks;
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
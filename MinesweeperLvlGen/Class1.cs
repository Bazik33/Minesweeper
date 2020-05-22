using System;

namespace MinesweeperLvlGen
{
    class Minesweeper
    {
        public readonly int xSize; public readonly int ySize; public readonly int bombAmount; public bool gameState = true; 
        public int[,] level;

        public char[,] levelLayer; 

        public void RevealMap(int x, int y)
        {
            if (level[x, y] == 0)
            {
                levelLayer[x, y] = 'R';

                if (x == 0)
                {
                    if (y == 0)
                    {
                        if (levelLayer[x, y + 1] != 'R') RevealMap(x, y + 1);
                        if (levelLayer[x + 1, y] != 'R') RevealMap(x + 1, y);
                    }
                    else if (y == ySize - 1)
                    {
                        if (levelLayer[x, y - 1] != 'R') RevealMap(x, y - 1);
                        if (levelLayer[x + 1, y] != 'R') RevealMap(x + 1, y);
                    }
                    else
                    {
                        if (levelLayer[x + 1, y] != 'R') RevealMap(x + 1, y);
                        if (levelLayer[x, y - 1] != 'R') RevealMap(x, y - 1);
                        if (levelLayer[x, y + 1] != 'R') RevealMap(x, y + 1);
                    }
                }
                else if (x == xSize - 1)
                {
                    if (y == 0)
                    {
                        if (levelLayer[x - 1, y] != 'R') RevealMap(x - 1, y);
                        if (levelLayer[x, y + 1] != 'R') RevealMap(x, y + 1);
                    }
                    else if (y == ySize - 1)
                    {
                        if (levelLayer[x - 1, y] != 'R') RevealMap(x - 1, y);
                        if (levelLayer[x, y - 1] != 'R') RevealMap(x, y - 1);
                    }
                    else
                    {
                        if (levelLayer[x - 1, y] != 'R') RevealMap(x - 1, y);
                        if (levelLayer[x, y - 1] != 'R') RevealMap(x, y - 1);
                        if (levelLayer[x, y + 1] != 'R') RevealMap(x, y + 1);
                    }
                }
                else
                {
                    if (y == 0)
                    {
                        if (levelLayer[x - 1, y] != 'R') RevealMap(x - 1, y);
                        if (levelLayer[x + 1, y] != 'R') RevealMap(x + 1, y);
                        if (levelLayer[x, y + 1] != 'R') RevealMap(x, y + 1);
                    }
                    else if (y == ySize - 1)
                    {
                        if (levelLayer[x - 1, y] != 'R') RevealMap(x - 1, y);
                        if (levelLayer[x + 1, y] != 'R') RevealMap(x + 1, y);
                        if (levelLayer[x, y - 1] != 'R') RevealMap(x, y - 1);
                    }
                    else
                    {
                        if (levelLayer[x - 1, y] != 'R') RevealMap(x - 1, y);
                        if (levelLayer[x + 1, y] != 'R') RevealMap(x + 1, y);
                        if (levelLayer[x, y - 1] != 'R') RevealMap(x, y - 1);
                        if (levelLayer[x, y + 1] != 'R') RevealMap(x, y + 1);
                    }
                }
            }
        }

        public Minesweeper(int dimX, int dimY, int bombs)
        {
            int tmpX, tmpY;
            Random rnd = new Random();

            xSize = dimX;
            ySize = dimY;
            bombAmount = bombs;

            level = new int[xSize, ySize];

            for (int i = 0; i < bombAmount; i++)
            {
                do
                {
                    tmpX = rnd.Next(xSize);
                    tmpY = rnd.Next(ySize);
                } while (level[tmpX, tmpY] == -1);

                level[tmpX, tmpY] = -1;
            }

            for (int i = 0; i < xSize; i++)
            {
                for (int j = 0; j < ySize; j++)
                {
                    if (level[i, j] == -1)
                    {
                        if (i == 0)
                        {
                            if (j == 0)
                            {
                                level[i + 1, j] = level[i + 1, j] == -1 ? level[i + 1, j] : level[i + 1, j] + 1;
                                level[i, j + 1] = level[i, j + 1] == -1 ? level[i, j + 1] : level[i, j + 1] + 1;
                                level[i + 1, j + 1] = level[i + 1, j + 1] == -1 ? level[i + 1, j + 1] : level[i + 1, j + 1] + 1;
                            }
                            else if (j == ySize - 1)
                            {
                                level[i, j - 1] = level[i, j - 1] == -1 ? level[i, j - 1] : level[i, j - 1] + 1;
                                level[i + 1, j - 1] = level[i + 1, j - 1] == -1 ? level[i + 1, j - 1] : level[i + 1, j - 1] + 1;
                                level[i + 1, j] = level[i + 1, j] == -1 ? level[i + 1, j] : level[i + 1, j] + 1;
                            }
                            else
                            {
                                level[i + 1, j] = level[i + 1, j] == -1 ? level[i + 1, j] : level[i + 1, j] + 1;
                                level[i, j - 1] = level[i, j - 1] == -1 ? level[i, j - 1] : level[i, j - 1] + 1;
                                level[i + 1, j - 1] = level[i + 1, j - 1] == -1 ? level[i + 1, j - 1] : level[i + 1, j - 1] + 1;
                                level[i, j + 1] = level[i, j + 1] == -1 ? level[i, j + 1] : level[i, j + 1] + 1;
                                level[i + 1, j + 1] = level[i + 1, j + 1] == -1 ? level[i + 1, j + 1] : level[i + 1, j + 1] + 1;
                            }
                        }
                        else if (i == xSize - 1)
                        {
                            if (j == 0)
                            {
                                level[i - 1, j] = level[i - 1, j] == -1 ? level[i - 1, j] : level[i - 1, j] + 1;
                                level[i - 1, j + 1] = level[i - 1, j + 1] == -1 ? level[i - 1, j + 1] : level[i - 1, j + 1] + 1;
                                level[i, j + 1] = level[i, j + 1] == -1 ? level[i, j + 1] : level[i, j + 1] + 1;
                            }
                            else if (j == ySize - 1)
                            {
                                level[i - 1, j] = level[i - 1, j] == -1 ? level[i - 1, j] : level[i - 1, j] + 1;
                                level[i, j - 1] = level[i, j - 1] == -1 ? level[i, j - 1] : level[i, j - 1] + 1;
                                level[i - 1, j - 1] = level[i - 1, j - 1] == -1 ? level[i - 1, j - 1] : level[i - 1, j - 1] + 1;
                            }
                            else
                            {
                                level[i - 1, j] = level[i - 1, j] == -1 ? level[i - 1, j] : level[i - 1, j] + 1;
                                level[i - 1, j - 1] = level[i - 1, j - 1] == -1 ? level[i - 1, j - 1] : level[i - 1, j - 1] + 1;
                                level[i, j - 1] = level[i, j - 1] == -1 ? level[i, j - 1] : level[i, j - 1] + 1;
                                level[i, j + 1] = level[i, j + 1] == -1 ? level[i, j + 1] : level[i, j + 1] + 1;
                                level[i - 1, j + 1] = level[i - 1, j + 1] == -1 ? level[i - 1, j + 1] : level[i - 1, j + 1] + 1;
                            }

                        }
                        else if (j == 0)
                        {
                            level[i - 1, j] = level[i - 1, j] == -1 ? level[i - 1, j] : level[i - 1, j] + 1;
                            level[i + 1, j] = level[i + 1, j] == -1 ? level[i + 1, j] : level[i + 1, j] + 1;
                            level[i - 1, j + 1] = level[i - 1, j + 1] == -1 ? level[i - 1, j + 1] : level[i - 1, j + 1] + 1;
                            level[i, j + 1] = level[i, j + 1] == -1 ? level[i, j + 1] : level[i, j + 1] + 1;
                            level[i + 1, j + 1] = level[i + 1, j + 1] == -1 ? level[i + 1, j + 1] : level[i + 1, j + 1] + 1;
                        }
                        else if (j == ySize - 1)
                        {
                            level[i - 1, j] = level[i - 1, j] == -1 ? level[i - 1, j] : level[i - 1, j] + 1;
                            level[i + 1, j] = level[i + 1, j] == -1 ? level[i + 1, j] : level[i + 1, j] + 1;
                            level[i - 1, j - 1] = level[i - 1, j - 1] == -1 ? level[i - 1, j - 1] : level[i - 1, j - 1] + 1;
                            level[i, j - 1] = level[i, j - 1] == -1 ? level[i, j - 1] : level[i, j - 1] + 1;
                            level[i + 1, j - 1] = level[i + 1, j - 1] == -1 ? level[i + 1, j - 1] : level[i + 1, j - 1] + 1;
                        }
                        else
                        {
                            level[i - 1, j - 1] = level[i - 1, j - 1] == -1 ? level[i - 1, j - 1] : level[i - 1, j - 1] + 1;
                            level[i, j - 1] = level[i, j - 1] == -1 ? level[i, j - 1] : level[i, j - 1] + 1;
                            level[i + 1, j - 1] = level[i + 1, j - 1] == -1 ? level[i + 1, j - 1] : level[i + 1, j - 1] + 1;

                            level[i - 1, j] = level[i - 1, j] == -1 ? level[i - 1, j] : level[i - 1, j] + 1;
                            level[i + 1, j] = level[i + 1, j] == -1 ? level[i + 1, j] : level[i + 1, j] + 1;

                            level[i - 1, j + 1] = level[i - 1, j + 1] == -1 ? level[i - 1, j + 1] : level[i - 1, j + 1] + 1;
                            level[i, j + 1] = level[i, j + 1] == -1 ? level[i, j + 1] : level[i, j + 1] + 1;
                            level[i + 1, j + 1] = level[i + 1, j + 1] == -1 ? level[i + 1, j + 1] : level[i + 1, j + 1] + 1;
                        }
                    }
                }
            }
            levelLayer = new char[xSize, ySize];
            for (int i = 0; i < xSize; i++) for (int j = 0; j < ySize; j++) levelLayer[i, j] = 'U'; 
            //orgLevel = level.Clone() as int[,];
        }
    }
}

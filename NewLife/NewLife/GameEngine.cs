using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLife
{
    public class GameEngine
    {
        public uint CurrentGeneration { get; private set; };//only++ value
        private bool[,] field;
        private readonly int rows;
        private readonly int columns;
        private Random random = new Random();

        public GameEngine(int rows, int columns, int density)
        {
            this.rows = rows;
            this.columns = columns;
            field = new bool[columns, rows];
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < columns; y++)
                {
                    field[x, y] = random.Next(density) == 0;
                }
            }
        }

        public void NextGeneration()
        {
            var newField = new bool[rows, columns];

            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < columns; y++)
                {
                    var neighborsCount = CountNeighbors(x, y);
                    var hasLife = field[x, y];

                    if (!hasLife & neighborsCount == 3)
                    {
                        newField[x, y] = true;
                    }
                    else if (hasLife && (neighborsCount < 2 || neighborsCount > 3))
                    {
                        newField[x, y] = false;
                    }
                    else
                    {
                        newField[x, y] = field[x, y];
                    }
                }
            }
            field = newField;
            CurrentGeneration++;
        }

        public bool[,] GetCurrentGeneration()
        {
            var result = new bool[rows, columns];

            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < columns; y++)
                    result[x, y] = field[x, y];
            }
            return result;
        }

        private int CountNeighbors(int x, int y)
        {
            int count = 0;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    var col = (x + i + columns) % columns;
                    var row = (y + 1 + rows) % rows;
                    var isSelfCheking = col == x && row == y;
                    var hasLife = field[col, row];

                    if (hasLife && !isSelfCheking)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}

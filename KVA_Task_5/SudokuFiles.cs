using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVA_Task_5
{
    public class SudokuFiles
    {
        public int[,] Board = new int[9, 9];

        public void LoadFromFile(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            for (int i = 0; i < 9; i++)
            {
                var numbers = lines[i].Split(' ');
                for (int j = 0; j < 9; j++)
                {
                    Board[i, j] = int.Parse(numbers[j]);
                }
            }
        }
    }
}

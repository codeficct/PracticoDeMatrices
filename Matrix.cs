using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PracticoDeMatrices
{
    internal class Matrix
    {
        // Properties
        private int rows, columns;
        private int[,] matrix;
        // Constructor
        public Matrix()
        {
            InitializeMatrix(0, 0);
        }
        // Methods
        public void InitializeMatrix(int r, int c)
        {
            rows = r; columns = c;
            matrix = new int[r, c];
        }

        public void SetData(int numRows, int numColumns, int min, int max)
        {
            InitializeMatrix(numRows, numColumns);
            Random numRandom = new Random();
            for (int r = 0; r < numRows; r++)
                for (int c = 0; c < numColumns; c++)
                    matrix[r, c] = numRandom.Next(min, max);
        }

        public string GetData()
        {
            string matrixStr = "";
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                    matrixStr = matrixStr + matrix[r, c] + "\x09";
                matrixStr = matrixStr + "\x0d" + "\x0a";
                //matrixStr = matrixStr + "\n";
            }
            return matrixStr;
        }

        public string AccumulatePrimes()
        {
            IntegerNumber objInteger = new IntegerNumber();
            string resultAccumulate = "", formule;
            bool toggle = true;
            for (int r = rows - 1; r >= 0; r--)
            {
                for (int c = columns - 1; c >= 0; c--)
                {
                    objInteger.SetNumber(matrix[r, c]);
                    if (objInteger.IsPrime())
                    {
                        Console.WriteLine(matrix[r, c].ToString());
                        formule = (toggle ? "-" : "+") + $"[{matrix[r, c]}^(1/2)]     ";
                        resultAccumulate += formule;
                        toggle = !toggle;
                    }
                }
            }
            return resultAccumulate;
        }

        public int GetFrecuenceOfElement(int element)
        {
            int frecuence = 0;
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < columns; c++)
                    if (matrix[r, c] == element)
                        frecuence++;
            return frecuence;
        }

        public void CountUniqueElements(ref int countElements)
        {
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < columns; c++)
                    if (GetFrecuenceOfElement(matrix[r, c]) == 1)
                        countElements++;
        }

        public void GetTransposedOfMatrix(ref Matrix transposed)
        {
            transposed.InitializeMatrix(columns, rows);
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < columns; c++)
                {
                    transposed.matrix[c, r] = matrix[r, c];
                }
        }
    }
}

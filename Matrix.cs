using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                        formule = (toggle ? "-" : "+") + $"[{matrix[r, c]}^(1/2)]    ";
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

        public bool IsOrderRowsAsc()
        {
            bool isOrder = false;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns - 1; c++)
                    if (matrix[r, c] < matrix[r, c + 1])
                        isOrder = true;
                    else
                    {
                        isOrder = false;
                        break;
                    }
            }
            return isOrder;
        }

        public int getFrecuencyInRows(int row, int ele)
        {
            int frecuence = 0;
            for (int c = 0; c < columns; c++)
                if (matrix[row, c] == ele)
                    frecuence++;
            return frecuence;
        }

        public int getFrecOfVector(int[] vector, int element)
        {
            int frecuence = 0;
            for (int i = 0; i < columns; i++)
                if (element == vector[i])
                    frecuence++;
            return frecuence;
        }

        public void setFrecuencyInLateral(ref Matrix matrix2)
        {
            matrix2.InitializeMatrix(rows, columns + 1);
            int[] vTele = new int[columns];
            int[] vTfrec = new int[columns];

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    matrix2.matrix[r, c] = matrix[r, c];
                    vTele[c] = matrix[r, c];
                    vTfrec[c] = getFrecuencyInRows(r, matrix[r, c]);
                }
                int maxFrec = vTfrec.Max();
                if (maxFrec != 1)
                    for (int i = 0; i < columns; i++)
                    {
                        if (maxFrec == getFrecOfVector(vTele, vTele[i]))
                        {
                            matrix2.matrix[r, columns] = matrix[r, i];
                        }
                    }
                else
                    matrix2.matrix[r, columns] = 0;
            }
        }

        public bool IsOrderMatrixWithRigor(int rigor = 1)
        {
            bool isOrder = false;
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < columns - 1; c++)
                    if (matrix[r, c] + rigor == matrix[r, c + 1])
                        isOrder = true;
                    else
                    {
                        isOrder = false;
                        break;
                    }
            return isOrder;
        }

        public bool CheckIfIsIncluded(ref Matrix matrix2)
        {
            bool isIncluded = false, close = false;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (matrix2.GetFrecuenceOfElement(matrix[r, c]) >= 1)
                        isIncluded = true;
                    else
                    {
                        isIncluded = false;
                        close = true;
                        break;
                    }
                }
                if (close) break;
            }
            return isIncluded;
        }

        public void SwapItems(int r1, int c1, int r2, int c2)
        {
            int aux = matrix[r1, c1];
            matrix[r1, c1] = matrix[r2, c2];
            matrix[r2, c2] = aux;
        }

        public void SegmentRowsEvenAndOdd(ref Matrix matrix2)
        {
            matrix2.InitializeMatrix(rows, columns);
            int parPos = 0, imparPos = columns - 1;
            for (int r = 0; r < rows; r++)
            {
                for (int c1 = 0; c1 < columns; c1++)
                {
                    if (matrix[r, c1] % 2 == 0) // Is even or odd
                    {
                        matrix2.matrix[r, parPos] = matrix[r, c1];
                        parPos++;
                    }
                    else
                    {
                        matrix2.matrix[r, imparPos] = matrix[r, c1];
                        imparPos--;
                    }
                }
                for (int c1 = 0; c1 < parPos; c1++)
                    for (int c2 = c1 + 1; c2 < parPos; c2++)
                    {
                        if (matrix2.matrix[r, c1] > matrix2.matrix[r, c2])
                            matrix2.SwapItems(r, c1, r, c2);
                    }
                for (int c1 = parPos; c1 < columns; c1++)
                    for (int c3 = c1 + 1; c3 < columns; c3++)
                    {
                        if (matrix2.matrix[r, c1] > matrix2.matrix[r, c3])
                            matrix2.SwapItems(r, c1, r, c3);
                    }
                parPos = 0; imparPos = columns - 1;
            }
        }

        public void OrderRowsOfPrimes(ref Matrix m2)
        {
            IntegerNumber objInt = new IntegerNumber();
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    objInt.SetNumber(matrix[r, c]);
                    if (objInt.IsPrime())
                    {
                        // 
                    }
                }
            }
        }

        public void Ejercicio2(int fi, int ff, int ci, int cf)
        {
            for (int c = ci - 1; c <= cf - 1; c++)
            {
                for (int r = ff-1; r >= fi -1; r--)
                {
                    matrix[c, r] = 0;
                }
            }
        }
    }
}

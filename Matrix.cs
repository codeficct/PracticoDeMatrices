using System.Numerics;

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

        public void Ejercicio2(int ri, int rf, int ci, int cf)
        {
            int i = 0;
            IntegerNumber
                num1 = new IntegerNumber(),
                num2 = new IntegerNumber();
            for (int c1 = ci - 1; c1 <= cf - 1; c1++)
            {
                for (int r1 = rf - 1; r1 >= ri - 1; r1--)
                {
                    for (int c2 = c1; c2 <= cf - 1; c2++)
                    {
                        if (c2 == c1)
                            i = r1;
                        else
                            i = 1;
                        for (int r2 = i; r2 >= ri - 1; r2--)
                        {
                            num1.SetNumber(matrix[r1, c1]); num2.SetNumber(matrix[r2, c2]);
                            if ((num2.IsEven() && !num1.IsEven())
                                || (num2.IsEven() && num1.IsEven() && (matrix[r1, c1] > matrix[r2, c2]))
                                || (!num2.IsEven() && !num1.IsEven() && (matrix[r1, c1] > matrix[r2, c2])))
                                SwapItems(r1, c1, r2, c2);
                        }
                    }
                }
            }
        }

        public void ResizeVector(ref int[] vector)
        {
            Array.Resize(ref vector, vector.Length + 1);
        }
        public void SortElements(ref int[] par, ref int[] impar)
        {
            Array.Sort(par); Array.Sort(impar);
        }

        public void SortMatrix(int ri, int rf, int ci, int cf)
        {
            int i = 0, j = 0, k = 0;
            bool IsEven = true;
            int[] par = new int[0], impar = new int[0];
            for (int c1 = ci - 1; c1 <= cf - 1; c1++)
                for (int r1 = rf - 1; r1 >= ri - 1; r1--)
                    if (matrix[r1, c1] % 2 == 0)
                    {
                        this.ResizeVector(ref par);
                        par[i] = matrix[r1, c1];
                        i++;
                    }
                    else
                    {
                        this.ResizeVector(ref impar);
                        impar[j] = matrix[r1, c1];
                        j++;
                    }
            this.SortElements(ref par, ref impar);
            j = 0;
            for (int c1 = ci - 1; c1 <= cf - 1; c1++)
                for (int r1 = rf - 1; r1 >= ri - 1; r1--)
                {
                    if (IsEven && (k < i))
                    {
                        matrix[r1, c1] = par[k]; k++;
                    }
                    else
                    {
                        matrix[r1, c1] = impar[j]; j++;
                    }
                }
        }
    }
}

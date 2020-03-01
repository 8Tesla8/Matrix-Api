using System;

namespace MatrixApi.Model
{
    public class Matrix : IMatrix
    {
        private int[,] _array = null;

        public virtual void SetArray(int[,] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array is null");
            }

            if (array.GetLength(0) != array.GetLength(1))
            {
                throw new ArgumentException("Array demension is not equal");
            }

            if (array.GetLength(0) <= 1 || array.GetLength(1) <= 1)
            {
                throw new ArgumentException("Array demension must be more than one");
            }

            _array = array;
        }


        public virtual string GetStringValue()
        {
            var str = string.Empty;

            for (int row = 0; row < _array.GetLength(0); row++)
            {
                for (int column = 0; column < _array.GetLength(1); column++)
                {
                    str += _array[row, column];

                    if (column != _array.GetLength(1) -1)
                    {
                        str += " ";
                    }
                }
                str += "\n";
            }

            return str;
        }

        public virtual void Rotate()
        {
            for (int i = 0; i < _array.GetLength(0) -1; i++)
            {
                for (int j = i; j < _array.GetLength(0)-1 -i; j++)
                {
                    int bound = _array.GetLength(0) - 1;

                    int point1 = _array[i, j];           
                    int point2 = _array[j, bound-i];       
                    int point3 = _array[bound-i, bound-j];   
                    int point4 = _array[bound-j, i];       


                    _array[i, j] = point4;
                    _array[bound - j, i] = point3; 
                    _array[bound - i, bound - j] = point2;
                    _array[j, bound - i] = point1; 
                }
            }
        }

        private void CheckArrayDemension()
        {
        }
    }
}


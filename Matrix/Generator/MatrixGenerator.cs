using System;
using MatrixApi.Autofac;
using MatrixApi.Model;

namespace MatrixApi.Generator
{
    public class MatrixGenerator : IMatrixGenerator
    {
        private readonly Random _rand = new Random();
        private int _value = 0;


        public IMatrix GenerateRandomMatrix(int demension)
        {
            CheckDemension(demension);
            return CreateMatrix(demension, GenerateRandomValue);
        }

        public IMatrix GenerateMatrix(int demension)
        {
            CheckDemension(demension);
            var matrix = CreateMatrix(demension, GetIncreasedValue);
            _value = 0;

            return matrix;
        }


        private int GenerateRandomValue() {
           return _rand.Next(0, 300);
        }

        private int GetIncreasedValue()
        {
            _value++;
            return _value;
        }

        private IMatrix CreateMatrix(int demension, Func<int> func)
        {
            var array = new int[demension, demension];
            for (int row = 0; row < demension; row++)
            {
                for (int column = 0; column < demension; column++)
                {
                    array[row, column] = func();
                }
            }

            var matrix = Injection.Resolve<IMatrix>();
            matrix.SetArray(array);

            return matrix;
        }

        private void CheckDemension(int demension)
        {
            if (demension <= 1)
            {
                throw new InvalidOperationException("Matrix demension can not be less then one");
            }
        }
    }
}
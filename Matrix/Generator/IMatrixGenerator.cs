using System;
using MatrixApi.Model;

namespace MatrixApi.Generator
{
    public interface IMatrixGenerator
    {
        public IMatrix GenerateRandomMatrix(int demension);
        public IMatrix GenerateMatrix(int demesion);
    }
}

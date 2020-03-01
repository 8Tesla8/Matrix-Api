using System;
using MatrixApi.Model;

namespace MatrixApi.Store
{
    public interface IMatrixStore
    {
        public void Save(string path, IMatrix matrix);
        public IMatrix Restore(string path);
    }
}

using System.IO;
using System.Linq;
using MatrixApi.Autofac;
using MatrixApi.Model;

namespace MatrixApi.Store
{
    public class MatrixStore : IMatrixStore
    {
        public IMatrix Restore(string path)
        {
            int[,] array =  null;

            using (var reader = new StreamReader(path))
            {
                int lineCount = 0;
                while (!reader.EndOfStream)
                {
                    var values = reader.ReadLine().Split(' ');

                    if (lineCount == 0)
                    {
                        array = new int[values.Count(), values.Count()];
                    }

                    for (int i = 0; i < values.Length; i++)
                    {
                        array[lineCount, i] = int.Parse(values[i]);
                    }
                    lineCount++;
                }
            }

            if (array == null)
            {
                throw new IOException("File is empty");
            }

            var matrix = Injection.Resolve<IMatrix>();
            matrix.SetArray(array);

            return matrix;
        }

        public void Save(string path, IMatrix matrix)
        {
            using (var writer = new StreamWriter(path))
            {
                writer.Write(matrix.GetStringValue());
            }
        }
    }
}

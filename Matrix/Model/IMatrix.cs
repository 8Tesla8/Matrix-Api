namespace MatrixApi.Model
{
    public interface IMatrix
    {
        public string GetStringValue();
        public void Rotate();
        public void SetArray(int[,] array);
    }
}

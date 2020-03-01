using System;
using System.IO;
using MatrixApi.Autofac;
using MatrixApi.Generator;
using MatrixApi.Store;
using Microsoft.AspNetCore.Mvc;

namespace MatrixApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatrixController : ControllerBase
    {
        public readonly IMatrixStore _matrixStore;
        public readonly IMatrixGenerator _matrixGenerator;

        private readonly string _path = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "matrix.csv";

        public MatrixController()
        {
            _matrixStore = Injection.Resolve<IMatrixStore>();
            _matrixGenerator = Injection.Resolve<IMatrixGenerator>();
        }


        [HttpGet]
        public string GenerateMatrix([FromQuery(Name = "demension")] int demension = 4)
        {
            try
            {
                var matrix = _matrixGenerator.GenerateRandomMatrix(demension);

                _matrixStore.Save(_path, matrix);

                return matrix.GetStringValue();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpGet]
        [Route("rotate")]
        public string RotateMatrix()
        {
            try
            {
                var matrix = _matrixStore.Restore(_path);

                matrix.Rotate();

                _matrixStore.Save(_path, matrix);

                return matrix.GetStringValue();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

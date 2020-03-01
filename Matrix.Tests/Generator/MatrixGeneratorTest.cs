using System;
using MatrixApi.Generator;
using NUnit.Framework;
using Tests.Autofac;

namespace Tests
{
    public class MatrixGeneratorTest
    {
        private IMatrixGenerator _matrixGenerator;

        [SetUp]
        public void Setup()
        {
            _matrixGenerator = Injection.Resolve<IMatrixGenerator>();
        }

        [Test]
        public void GenerateMatrix_DemensionZero_ThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _matrixGenerator.GenerateMatrix(0));
        }

        [Test]
        public void GenerateMatrix_DemensionMinusOne_ThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _matrixGenerator.GenerateMatrix(-1));
        }

        [Test]
        public void GenerateMatrix_DemensionTwo_MatrixStringValueEqual()
        {
            Assert.That(_matrixGenerator.GenerateMatrix(2).GetStringValue(), Is.EqualTo("1 2\n3 4\n"));
        }


        [Test]
        public void GenerateRandomMatrix_DemensionZero_ThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _matrixGenerator.GenerateRandomMatrix(0));
        }

        [Test]
        public void GenerateRandomMatrix_DemensionMinusOne_ThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _matrixGenerator.GenerateRandomMatrix(-1));
        }

        [Test]
        public void GenerateRandom_DemensionTwo_MatrixStringValueMatchToRegex()
        {
            var regex = @"^[\d\s]+$"; //for number with space and new line

            StringAssert.IsMatch(regex, _matrixGenerator.GenerateRandomMatrix(2).GetStringValue());
        }
    }
}

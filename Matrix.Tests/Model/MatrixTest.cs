using System;
using MatrixApi.Model;
using Tests.Autofac;
using NUnit.Framework;

namespace Tests
{
    public class MatrixTest
    {
        [Test]
        public void SetArray_ArrayIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () => Injection.Resolve<IMatrix>().SetArray(null));
        }

        [Test]
        public void SetArray_ArrayDemensionsNotEquals_ThrowArgumentException()
        {
            var array = new int[3, 2];

            Assert.Throws<ArgumentException>(() => Injection.Resolve<IMatrix>().SetArray(array));
        }

        [Test]
        public void SetArray_ArrayDemensionsIsOneToOne_ThrowArgumentException()
        {
            var array = new int[1, 1];

            Assert.Throws<ArgumentException>(() => Injection.Resolve<IMatrix>().SetArray(array));
        }


        [Test]
        public void GetStringValue_ArrayExist_StringValueEqual()
        {
            var array = new int[,]
            {
                { 1,2 },
                { 3,4 },
            };

            var matrix = Injection.Resolve<IMatrix>();
            matrix.SetArray(array);    

            Assert.That(matrix.GetStringValue(), Is.EqualTo("1 2\n3 4\n"));
        }

        [Test]
        public void Rotate_ArrayExist_StringValueEqual()
        {
            var array = new int[,]
            {
                { 1,2 },
                { 3,4 },
            };

            var matrix = Injection.Resolve<IMatrix>();
            matrix.SetArray(array);
            matrix.Rotate();

            Assert.That(matrix.GetStringValue(), Is.EqualTo("3 1\n4 2\n"));
        }
    }
}

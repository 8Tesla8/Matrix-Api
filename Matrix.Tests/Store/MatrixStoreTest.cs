using System;
using NUnit.Framework;
using Tests.Autofac;
using MatrixApi.Model;
using Moq;
using MatrixApi.Store;
using System.IO;

namespace Tests
{
    public class MatrixStoreTest
    {
        private string _fileRestore;
        private string _fileSave;

        private IMatrix _mockFilledMatrix;

        private IMatrixStore _matrixStore;

        [SetUp]
        public void Setup()
        {
            var path =
                 Directory.GetCurrentDirectory()
                 .Split("bin")[0]
                 + Path.DirectorySeparatorChar
                 + "TestFiles"
                 + Path.DirectorySeparatorChar;

            _fileRestore = string.Concat(path, "FileRestore", Path.DirectorySeparatorChar);
            _fileSave = string.Concat(path, "FileSave", Path.DirectorySeparatorChar);


            var matrix = new Mock<IMatrix>();
            matrix.Setup(p => p.GetStringValue()).Returns("1 2\n3 4\n");
            _mockFilledMatrix = matrix.Object;

            _matrixStore = Injection.Resolve<IMatrixStore>();
        }


        [Test]
        public void Restore_FileExist_GetMatrix()
        {
            var matrix = _matrixStore.Restore(_fileRestore + "matrix-restore.csv");

            Assert.That(matrix.GetStringValue(), Is.EqualTo("1 2\n3 4\n"));
        }

        [Test]
        public void Restore_FileNotExist_ThrowFileNotFoundException()
        {
            Assert.Throws<FileNotFoundException>(() => _matrixStore.Restore(_fileRestore + "matrix-not-exist.csv"));
        }

        [Test]
        public void Restore_FileContainsLetters_ThrowFormatException()
        {
            Assert.Throws<FormatException>(() => _matrixStore.Restore(_fileRestore + "matrix-letters.csv"));
        }

        [Test]
        public void Restore_PathToFileNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _matrixStore.Restore(null));
        }

        [Test]
        public void Restore_PathToFileEmpty_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _matrixStore.Restore(""));
        }

        [Test]
        public void Restore_FileEmpty_ThrowIOException()
        {
            Assert.Throws<IOException>(() => _matrixStore.Restore(_fileRestore + "matrix-empty.csv"));
        }


        [Test]
        public void Save_PathToFileNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _matrixStore.Save(null, _mockFilledMatrix));
        }

        [Test]
        public void Save_PathToFileEmpty_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _matrixStore.Save("", _mockFilledMatrix));
        }

        [Test]
        public void Save_MatrixArrayIsNull_ThrowNullReferenceException()
        {
            var emptyMockMatrix = new Mock<IMatrix>();
            emptyMockMatrix.Setup(p => p.GetStringValue()).Throws<NullReferenceException>();

            Assert.Throws<NullReferenceException>(() => _matrixStore.Save(_fileSave + "matrix-empty.csv", emptyMockMatrix.Object));
        }

        [Test]
        public void Save_FileCreated_True()
        {
            var pathToFile = _fileSave + "matrix-save.csv";

            _matrixStore.Save(pathToFile, _mockFilledMatrix);

            Assert.IsTrue(File.Exists(pathToFile));
        }

        [Test]
        public void Save_FileContainsMatrixStringValue_StringValueEqual()
        {
            var pathToFile = _fileSave + "matrix-save.csv";

            _matrixStore.Save(pathToFile, _mockFilledMatrix);

            Assert.That(_matrixStore.Restore(pathToFile).GetStringValue(), Is.EqualTo("1 2\n3 4\n"));
        }
    }
}

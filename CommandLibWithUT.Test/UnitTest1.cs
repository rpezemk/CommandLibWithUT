using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommandLibWithUT.Test
{
    [TestClass]
    public class VectorTest
    {
        [TestMethod]
        public void TestAdd()
        {
            //arrange
            double x1 = 499.01;
            double y1 = 301;
            double z1 = -0.5;

            double x2 = -100.97;
            double y2 = 11;
            double z2 = -0.99;

            double expectedX = x1 + x2;
            double expectedY = y1 + y2;
            double expectedZ = z1 + z2;

            Vector vector1 = new Vector(x1, y1, z1);
            Vector vector2 = new Vector(x2, y2, z2);

            //Act
            vector1.Add(vector2);

            //Assert
            Assert.AreEqual(vector1.X, expectedX);
            Assert.AreEqual(vector1.Y, expectedY);
            Assert.AreEqual(vector1.Z, expectedZ);
        }

        [TestMethod]
        public void TestSubstract()
        {
            //arrange
            double x1 = 499.01;
            double y1 = 301;
            double z1 = -0.5;

            double x2 = -100.97;
            double y2 = 11;
            double z2 = -0.99;

            double expectedX = x1 - x2;
            double expectedY = y1 - y2;
            double expectedZ = z1 - z2;

            Vector vector1 = new Vector(x1, y1, z1);
            Vector vector2 = new Vector(x2, y2, z2);

            //Act
            vector1.Substract(vector2);

            //Assert
            Assert.AreEqual(vector1.X, expectedX);
            Assert.AreEqual(vector1.Y, expectedY);
            Assert.AreEqual(vector1.Z, expectedZ);
        }

        [TestMethod]
        public void TestMultiply()
        {
            //arrange
            double x1 = 499.01;
            double y1 = 301;
            double z1 = -0.5;

            double x2 = -100.97;
            double y2 = 11;
            double z2 = -0.99;

            double expectedX = x1 * x2;
            double expectedY = y1 * y2;
            double expectedZ = z1 * z2;

            Vector vector1 = new Vector(x1, y1, z1);
            Vector vector2 = new Vector(x2, y2, z2);

            //Act
            vector1.Mulitply(vector2);

            //Assert
            Assert.AreEqual(vector1.X, expectedX);
            Assert.AreEqual(vector1.Y, expectedY);
            Assert.AreEqual(vector1.Z, expectedZ);
        }

        [TestMethod]
        public void TestDivide()
        {
            //arrange
            double x1 = 499.01;
            double y1 = 301;
            double z1 = -0.5;

            double x2 = -100.97;
            double y2 = 11;
            double z2 = -0.99;

            double expectedX = x1 / x2;
            double expectedY = y1 / y2;
            double expectedZ = z1 / z2;

            Vector vector1 = new Vector(x1, y1, z1);
            Vector vector2 = new Vector(x2, y2, z2);

            //Act
            vector1.Divide(vector2);

            //Assert
            Assert.AreEqual(vector1.X, expectedX);
            Assert.AreEqual(vector1.Y, expectedY);
            Assert.AreEqual(vector1.Z, expectedZ);
        }

        [TestMethod]
        public void TestGetVector()
        {
            //arrange
            double x1 = 499.01;
            double y1 = 301;
            double z1 = -0.5;
            string name = "Vector Name";

            //Act
            Vector vector1 = new Vector(x1, y1, z1, name);
            Vector vector2 = vector1.GetVector();

            //Assert
            Assert.AreEqual(vector1, vector2);
        }

        [TestMethod]
        public void TestSetName()
        {
            //arrange
            double x1 = 499.01;
            double y1 = 301;
            double z1 = -0.5;
            string name = "Vector Name";

            //Act
            Vector vector = new Vector() { Name = name };

            //Assert
            Assert.AreEqual(vector.Name, name);
        }

        [TestMethod]
        public void TestPrint()
        {
            //Arrange
            double x1 = 499.01;
            double y1 = 301;
            double z1 = -0.5;
            string name = "Vector Name";

            //Act
            Vector vector = new Vector(x1, y1, z1, name);
            vector.Print();
        }
    }
}

using MindBox;

namespace MBUnitTests
{
    [TestClass]
    public class UnitTestArea
    {
        [TestMethod]
        public void CircleTest()
        {
            Assert.AreEqual(Math.PI*100, Area.Circle(10));
            Assert.ThrowsException<System.Exception>(()=>Area.Circle(-1));
        }

        [TestMethod]
        public void TriangleTest()
        {
            Assert.IsInstanceOfType(Area.Triangle(10, 7, 8), typeof(double));
            Assert.ThrowsException<System.Exception>(() => Area.Triangle(10,5,4));
            Assert.ThrowsException<System.Exception>(() => Area.Triangle(-1, 5, 4));
        }

        [TestMethod]
        public void GaussTest()
        {
            double[,] points = new double[5, 2];
            for(int i = 0; i < 5; i++)
                for(int j = 0; j < 2; j++)
                    points[i,j] = new Random().NextDouble()*100-50;

            Assert.IsInstanceOfType(Area.Gauss(points), typeof(double));

            double[,] points2 = new double[5, 3];
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 3; j++)
                    points2[i, j] = new Random().NextDouble() * 100 - 50;

            Assert.ThrowsException<System.Exception>(() => Area.Gauss(points2));

            double[,] points3 = new double[2, 2];
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    points3[i, j] = new Random().NextDouble() * 100 - 50;

            Assert.ThrowsException<System.Exception>(() => Area.Gauss(points3));
        }
    }
}
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Test
{
    [TestClass]
    public class ManagerTest
    {
        [TestMethod]
        public void ObjectMock()
        {
            Mock<IController> mockController1 = new Mock<IController>();
            mockController1.Setup(
                c => c.Sub(It.IsAny<int>(), It.IsAny<int>())).Returns(10);

            Mock<IController> mockController2 = new Mock<IController>();
            mockController2.Setup(
                c => c.Sub(It.IsAny<int>(), It.IsAny<int>())).Returns(100);

            Manager m = new Manager { Controller = mockController2.Object};

            Assert.AreEqual(100, m.Add(100, 200));
            Assert.AreEqual(100, m.Add(110, 220));
            Assert.AreNotEqual(10, m.Add(110, 220));

            Manager m2 = new Manager { Controller = mockController1.Object };
            Assert.AreEqual(10, m2.Add(1, 2));
        }

        [TestMethod]
        public void DelayedLoading()
        {
            Mock<IController> mockController = new Mock<IController>();
            mockController.Setup(
                c => c.Sub(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => { return a*b; });
            //mockController.Setup(
            //    c => c.Add(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a * b);

            Manager m = new Manager { Controller = mockController.Object };

            Assert.AreEqual(9, m.Add(3, 3));
            Assert.AreEqual(20, m.Add(4, 5));
        }

        [TestMethod]
        public void SpecifiedInput()
        {
            const string tenString = "Ten";
            const string oneString = "One";

            Mock<IController> mockController = new Mock<IController>();
            mockController.Setup(
                c => c.IntToString(It.Is<int>(value => value == 10))).Returns(tenString);
            mockController.Setup(
                c => c.IntToString(It.Is<int>(value => value == 1))).Returns(oneString);

            Manager m = new Manager { Controller = mockController.Object };

            Assert.AreEqual(tenString, m.IntToString(10));
            Assert.AreEqual(oneString, m.IntToString(1));
            Assert.IsNull(m.IntToString(2));
        }

        [TestMethod]
        public void ReturnTheDefaultValue()
        {
            Mock<IController> mockController = new Mock<IController>();
            //mockController.Setup(c => c.Add(It.IsAny<int>(), It.IsAny<int>()));
            //mockController.Setup(c => c.IntToString(It.IsAny<int>()));

            Manager m = new Manager { Controller = mockController.Object };

            Assert.IsNull(m.IntToString(2));
            Assert.AreEqual(0, m.Add(10, 20));
        }

        [TestMethod]
        public void VerifyMock()
        {
            Mock<IController> mockController = new Mock<IController>();

            Manager m = new Manager { Controller = mockController.Object };

            m.IntToString(1);
            m.IntToString(2);
            m.IntToString(3);
            m.IntToString(5);

            mockController.Verify(
                c => c.IntToString(It.IsAny<int>()), Times.Exactly(4));

            mockController.Verify(
                c => c.IntToString(It.Is<int>(v => v < 3)), Times.Exactly(2));

            mockController.Verify(
                c => c.IntToString(1), Times.Once);

            mockController.Verify(
                c => c.IntToString(5), Times.Once);

            mockController.Verify(
                c => c.IntToString(10), Times.Never);
        }

    }
}

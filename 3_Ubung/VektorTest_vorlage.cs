using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test {
    [TestClass]
    public class VektorTest {
        Vektor a = new Vektor(1, 2, 3);
        Vektor b = new Vektor(4, 5, 6);
        Vektor c = new Vektor(-3,6,-3);
        const double k0 = 1.1, k1 = 2.2, k2 = 3.3;
        Vektor d = new Vektor(k0, k1, k2);
        const double EPS = 1E-10;
        [TestMethod]
        public void TestEqual() {
            Assert.AreEqual(new Vektor(1, 2, 3), a);
            Assert.IsTrue(a.Equals(new Vektor(1, 2, 3)));
            Assert.AreNotEqual(new Vektor(1, 2, 3.01), a);
            
        }

        [TestMethod]
        public void TestIndexer() {
            Assert.AreEqual(d[0], k0, EPS);
            Assert.AreEqual(d[1], k1, EPS);
            Assert.AreEqual(d[2], k2, EPS);
            Vektor v = new Vektor();
            v[0] = k0; v[1] = k1; v[2] = k2;
            Assert.AreEqual(new Vektor(k0, k1, k2), v);

        }

        [TestMethod]
        public void TestAdd() {
            Vektor v3 = a + b;
            Assert.AreEqual(new Vektor(5,7,9), v3);
        }

        [TestMethod]
        public void TestSub() {
            Vektor v3 = a - b;
            Assert.AreEqual(new Vektor(-3,-3,-3), v3);
        }

        [TestMethod]
        public void TestMul() {
            Vektor v3 = a * b;
            Assert.AreEqual(c, v3);
        }

        [TestMethod]
        public void TestSkalar() {
            Vektor v = 1.1 * a;
            Assert.AreEqual(d, v);
            v = a*1.1;
            Assert.AreEqual(d, v);
            v = d/1.1;
            Assert.AreEqual(a, v);

        }


        [TestMethod]
        public void TestAssign() {
            Vektor v = k0;
            Assert.AreEqual(v, new Vektor(k0,0,0));
            double val = (double)a;
            Assert.AreEqual(val, Math.Sqrt(a[0] * a[0] + a[1] * a[1] + a[2] * a[2]), EPS);
        }
    }
}

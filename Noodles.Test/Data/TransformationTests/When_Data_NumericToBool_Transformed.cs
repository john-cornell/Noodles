using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Noodles.Data.Projections;
using Noodles.Data.Transformations;

namespace Noodles.Test.Data.TransformationTests
{
    [TestClass]
    public class When_Data_NumericToBool_Transformed
    {
        [TestMethod]
        public void Should_fail_object_transform_if_cant_convert_to_int()
        {
            NumericToBooleanTransformer transformer = new NumericToBooleanTransformer();
            object[] untransformable =
                {
                    "Hello Jim",
                    "Seventeen and a half",
                    new InvalidOperationException(),
                    new DataTable(),
                    17.5,
                    "No",
                    "False"
                };
            int fails = 0;

            foreach (object o in untransformable)
            {
                try
                {
                    transformer.ObjectTransform(o);
                }
                catch { fails += 1; }
            }

            Assert.AreEqual(untransformable.Length, fails);
        }

        [TestMethod]
        public void Should_not_fail_object_transform_if_can_to_int()
        {
            NumericToBooleanTransformer transformer = new NumericToBooleanTransformer();
            object[] transformable =
                {
                    1,
                    1.2,
                    0,
                    0b0,
                    (3-2),
                    (1),
                    0m,
                    0d,
                    0L,
                    (char)1,
                    (byte)0
                };
            int fails = 0;

            foreach (object o in transformable)
            {
                try
                {
                    transformer.ObjectTransform(o);
                }
                catch { fails += 1; }
            }

            Assert.AreEqual(0, fails);
        }

        [TestMethod]
        public void Should_not_fail_object_transform_if_passed_01_int()
        {
            NumericToBooleanTransformer transformer = new NumericToBooleanTransformer();
            int[] transformable =
                {
                    1,
                    (int) 1.2,
                    0,
                    0b0,
                    (3-2),
                    (1),
                    (char)1,
                    (byte)0
                };
            int fails = 0;

            foreach (int o in transformable)
            {
                try
                {
                    transformer.Transform(o);
                }
                catch { fails += 1; }
            }

            Assert.AreEqual(0, fails);
        }

        [TestMethod]
        public void Should_transform_correctly_from_object()
        {
            NumericToBooleanTransformer transformer = new NumericToBooleanTransformer();
            object[] transformable =
                {
                    1,
                    1.2,
                    0,
                    0b0,
                    (3-2),
                    (1),
                    0m,
                    0d,
                    0L,
                    (char)1,
                    (byte)0
                };

            bool[] equivalent = { true, true, false, false, true, true, false, false, false, true, false };

            for (int i = 0; i < transformable.Length; i++)
            {
                Assert.AreEqual(equivalent[i], transformer.ObjectTransform(transformable[i]));
            }
        }

        [TestMethod]
        public void Should_transform_correctly_from_int()
        {
            NumericToBooleanTransformer transformer = new NumericToBooleanTransformer();
            int[] transformable =
                {
                    1,
                    (int) 1.2,
                    0,
                    0b0,
                    (3-2),
                    (1),
                    (char)1,
                    (byte)0
                };

            bool[] equivalent = { true, true, false, false, true, true, true, false };

            for (int i = 0; i < transformable.Length; i++)
            {
                Assert.AreEqual(equivalent[i], transformer.Transform(transformable[i]));
            }
        }
    }
}

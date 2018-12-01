using System.Collections.Generic;

using NUnit.Framework;
using Unity.Collections;

namespace Zeta.Tests
{
    class Vector3iTests
    {
        [Test]
        public void Add_Vector_Test()
        {
            for(int x = 0; x < 16; x++)
            {
                for(int y = 0; y < 16; y++)
                {
                    for(int z = 0; z < 16; z++)
                    {
                        var a = new Zeta.Vector3i(x, y, z);
                        var b = new Zeta.Vector3i(x, y, z);
                        var test = a + b;

                        Assert.AreEqual(test.x, x + x);
                        Assert.AreEqual(test.y, y + y);
                        Assert.AreEqual(test.z, z + z);
                    }
                }
            }
        }

        [Test]
        public void Sub_Vector_Test()
        {
            for(int x = 0; x < 16; x++)
            {
                for(int y = 0; y < 16; y++)
                {
                    for(int z = 0; z < 16; z++)
                    {
                        var a = new Zeta.Vector3i(x, y, z);
                        var b = new Zeta.Vector3i(x, y, z);
                        var test = a - b;

                        Assert.AreEqual(test.x, x - x);
                        Assert.AreEqual(test.y, y - y);
                        Assert.AreEqual(test.z, z - z);
                    }
                }
            }
        }

        [Test]
        public void Iterate_Vector_Test()
        {
            const int size = 16;
            var expected = 0;
            for(int x = 0; x < size; x++)
            {
                for(int y = 0; y < size; y++)
                {
                    for(int z = 0; z < size; z++)
                    {
                        expected++;
                    }
                }
            }

            var subject = new Zeta.Vector3i(size, size, size);
            var result = 0;
            foreach(var v in subject)
            {
                result++;
            }

            Assert.AreEqual(expected, result);
        }

        private struct Test
        {
            public Vector3i Input;
            public int Result;
        }

        [Test]
        public void Array_Position_Test()
        {            
            var tests = new List<Test>();
            var layout = new Vector3i(16, 16, 16);
            tests.Add(new Test { Input = new Vector3i(0, 0, 0), Result =   0 });
            tests.Add(new Test { Input = new Vector3i(0, 1, 0), Result =  16 });
            tests.Add(new Test { Input = new Vector3i(1, 1, 0), Result =  17 });
            tests.Add(new Test { Input = new Vector3i(0, 0, 1), Result = 256 });
            tests.Add(new Test { Input = new Vector3i(1, 0, 1), Result = 257 });
            tests.Add(new Test { Input = new Vector3i(4, 1, 1), Result = 276 });

            for(int i = 0; i < tests.Count; i++)
            {
                var test = tests[i].Input;
                var pos = layout.GetIndex(test.x, test.y, test.z);

                Assert.AreEqual(tests[i].Result, pos, $"{tests[i].Result} -> {pos}");

                var message = $"{tests[i].Input} -> {layout.GetVector(pos)} ({tests[i].Input.Equals(layout.GetVector(pos))})";
                Assert.AreEqual(tests[i].Input, layout.GetVector(pos), message);

                Assert.True(tests[i].Result == layout.GetIndex(tests[i].Input));
            }
        }

        [Test]
        public void Operator_Equals_Test()
        {
            var a = new Zeta.Vector3i(25, 0, 25);
            var b = new Zeta.Vector3i(25, 0, 25);

            Assert.IsTrue(a == b);
            Assert.IsTrue(a.Equals(b));
            Assert.AreEqual(a, b);
        }

        // Simply a test to find out if the hash function works with
        // native hashmaps as well. It does.
        /*[Test]
        public void Hashmap_Test()
        {
            var subject = new NativeHashMap<Vector3i, int>(0, Allocator.Persistent);
            var a = new Zeta.Vector3i(25, 0, 25);
            var b = new Zeta.Vector3i(25, 0, 25);
            var c = new Zeta.Vector3i(10, 0, 10);

            Assert.True(subject.TryAdd(a, 10));

            int out_i = 0;
            Assert.True(subject.TryGetValue(a, out out_i));
            Assert.AreEqual(out_i, 10);
            Assert.True(subject.TryGetValue(b, out out_i));
            Assert.AreEqual(out_i, 10);

            Assert.False(subject.TryGetValue(c, out out_i));

            Assert.AreEqual(subject.Length, 1);

            subject.Dispose();
        }*/
    }
}

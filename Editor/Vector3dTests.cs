using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Collections;
using NUnit.Framework;

namespace Vectors.Tests.Terrain
{
    public class Vector3dTest
    {
        struct Test
        {
            public int value;
            public Vector3d key;

            public Test(int v, Vector3d k)
            {
                value = v;
                key = k;
            }
        }

        /*[Test]
        public void Hashfunction_Test()
        {
            var hashmap = new NativeHashMap<Vector3d, int>(0, Allocator.Persistent);

            var tests = new List<Test>();
            tests.Add(new Test(0, new Vector3d(1, 1, 1)));
            tests.Add(new Test(1, new Vector3d(-1, -1, -1)));
            tests.Add(new Test(2, new Vector3d(-1, 0, 1)));
            tests.Add(new Test(3, new Vector3d(0, 1, -1)));
            tests.Add(new Test(4, new Vector3d(-1, 1, 1)));
            tests.Add(new Test(5, new Vector3d(-10000000, 1000000, 0)));
            tests.Add(new Test(5, new Vector3d(-10000000, 1000000, 52154120)));

            for(int i = 0; i < tests.Count; i++)
            {
                if(!hashmap.TryAdd(tests[i].key, tests[i].value))
                {
                    Assert.IsTrue(false, "Could not add {0}", tests[i].key);
                }
            }

            Assert.AreEqual(tests.Count, hashmap.Length);

            for(int i = 0; i < tests.Count; i++)
            {
                int val = 0;
                if(!hashmap.TryGetValue(tests[i].key, out val))
                {
                    Assert.IsTrue(false, "Could not get {0}", tests[i].key);
                }

                Assert.AreEqual(tests[i].value, val);
            }

            hashmap.Dispose();
        }*/
    }
}

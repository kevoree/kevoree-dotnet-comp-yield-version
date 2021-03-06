﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Org.Kevoree.YieldVersion
{
    [TestFixture]
    class TestYieldSerialization
    {

        [Test]
        public void testSerialization()
        {
            var obj = new YieldVersion();

            var a = Path.GetTempFileName();
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(a,
                                     FileMode.Create,
                                     FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, obj);
            stream.Close();
        }
    }
}

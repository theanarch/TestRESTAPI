 using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace DataLib
{
    public class DataLayerClass
    {
        public static TestModel GetTestModel(int s)
        {
            return new TestModel(s, $"Hej {s}");
        }
    }
}

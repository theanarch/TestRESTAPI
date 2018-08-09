using System;
using Models;

namespace Data
{
    public class GetTestModel
    {
        public TestModel Shit(int s)
        {
            return new TestModel(s,"Hej");
        }
    }
}

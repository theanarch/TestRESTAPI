using System;

namespace Models
{
    public class TestModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public TestModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

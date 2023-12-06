using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight_DataAccess.Entities
{
    public class Category
    {
        public int Id { get; }
        public string Name { get; private set; }

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Category()
        {
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedC_S01
{
    public class Container<T>
    {
        private T _item;
        public void Add(T item)
        {
            _item = item;
            Console.WriteLine($"Added: {item}");
        }

        public T Get()
        {   
            return _item;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedC_S01
{
    internal class safeList<T>
    {
        private List<T> numbers = new();
        public void Add(T number) => numbers.Add(number);

        public T GetAt(int index)
        {
            if (index >= 0 && index < numbers.Count)
                return numbers[index];
            return default(T);
        }
    }
}

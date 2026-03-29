using System.ComponentModel;
using System.Numerics;

namespace AdvancedC_S01
{
    internal class Program
    {
     
        static void Main(string[] args)
        {

            /*Q1: What is a generic class? Why use generics?
        Generic classes allow you to define a class with a placeholder for the type it operates on. 
        //This imroves code reusability, type safety, and performance by allowing you to create classes that
        can work with any data type without sacrificing type safety or needing to write multiple versions of 
        the same class for different types.
        */
           
            #region Q2
            /*Q2: Write a generic class Container<T> with Add and Get methods.


             var container = new Container<int>();

             container.Add(100);
             container.Add(200);

             Console.WriteLine(container.Get());
 */
            #endregion

            /*Q3:What are multiple type parameters? Write Pair<TKey, TValue>.
            multiple type parameters allow you to define a generic class or method that can work with more than one type.
                var pair = new Pair<string, int>("Age", 30);
             */
            /*Q4: What is a generic method? Write Swap<T> method.
            A generic method declares its own type parameter(s). It can exist in both generic and non-generic classes.
            The compiler often infers the type argument.


             
            int a=5, b=10;
             Console.WriteLine($"Before Swap: a={a}, b={b}");
            
            void swap<T>(ref T a, ref T b)
            {
                T temp = a;
                a = b;
                b = temp;
            } swap(ref a, ref b);
             Console.WriteLine($"After Swap: a={a}, b={b}");
*/

            /*Q5: Write a generic method FindMax<T> that finds maximum value
             
            
            static void findMax<T>(T[] arr) where T : IComparable<T>
            {
                if (arr == null || arr.Length == 0)
                {
                    Console.WriteLine("Array is empty.");
                    return;
                }
                T max = arr[0];
                foreach (T item in arr)
                {
                    if (item.CompareTo(max) > 0)
                    {
                        max = item;
                    }
                }
                Console.WriteLine($"Maximum value: {max}");
            }

                int[] numbers = { 3, 1, 14, 1, 5, 9 };
                findMax(numbers);
     */

            /*Q6: What is a generic interface? Write IRepository<T>.
            A generic interface defines a contract with type parameters.
            It allows you to create flexible and reusable interfaces that can work with any data type.
            public interface IRepository<T>
            {
            void Add(T item);
            T Get(int id);
            }
             */

            /*Q7: What is the 'struct' constraint? Write an example.
            T must be a value type (struct). This includes all primitive types, enums, and user-defined structs.

                public struct ValueContainer<T> where T : struct
                {
                    private T _value;
                    public void SetValue(T value)
                    {
                        _value = value;
                        Console.WriteLine($"Value set: {_value}");
                    }
    
                    public T GetValue()
                    {
                        return _value;
                    }
             */

            /*Q8: What is the 'class' constraint? Write an example.
            T must be a reference type (class). This includes all classes, interfaces, delegates, and arrays.
                public class ReferenceContainer<T> where T : class
                {
                    private T _item;
                    public void SetItem(T item)
                    {
                        _item = item;
                        Console.WriteLine($"Item set: {_item}");
                    }
        
                    public T GetItem()
                    {
                        return _item;
                    }
             */

            /*Q9: What is the 'new()' constraint? Write an example.	
            T must have parameterless constructor
                public class Factory<T> where T : new()
             {
                 public T CreateInstance()
                 {
                     return new T();
                 }
             }
             */

            /*Q10:  What is the interface constraint? Write an example.
            T must implement interface
            public class Sorter<T> where T : IComparable<T>
                {
                    public void Sort(T[] array)
                    {
                        Array.Sort(array);
                        Console.WriteLine("Array sorted.");
                    }
                }
             */

            /*Q11: What is the base class constraint? Write an example.
             Base class constraint specifies that the type argument must be or derive from a specific base class.
            public class Repository<T> where T : BaseEntity
            {
                public void Save(T entity)
                {
                    Console.WriteLine($"Saving {entity}");
                }
             }
            
             */

            /*Q12: How do you apply multiple constraints? Write an example.
            To apply multiple constraints, you separate them with commas in the where clause.
            public class Service<T> where T : class, IComparable<T>, new()
            {
                public void Process(T item)
                {
                    Console.WriteLine($"Processing {item}");
                }
             }
             */

            /*Q13: What does the 'default' keyword do in generics?
            default(T) or default returns the default value for type T: null for reference types, 0/false for value types.
             */

            /*Q14: Write a SafeList<T> that returns default when the index is invalid.
           safeList<int> list = new ();
            list.Add(10);
                list.Add(20);
                Console.WriteLine(list.GetAt(0)); // Output: 10
                Console.WriteLine(list.GetAt(1)); // Output: 20
                Console.WriteLine(list.GetAt(2)); // Output: 0 (default for int)
 */

            /*Q15: What is covariance? Explain the 'out' keyword.
            Covariance allows you to use a more derived type than originally specified. 
            Marked with out keyword. T can only appear in output positions.
             */

            /*Q16: What is contravariance? Explain the 'in' keyword.
            Contravariance allows you to use a less derived type than originally specified. 
            Marked with in keyword. T can only appear in input positions.
             */

            /*Q17: What is the difference between covariance and contravariance?
            The main difference is in the direction of type compatibility:
            Covariance (out): Allows a more derived type. Used in return types.
            Contravariance (in): Allows a less derived type. Used in parameter types.

             */

            /*Q18: How do static members work in generic types?
           In generic types, static members are NOT shared across all types.Instead, they are separate for each closed generic type.  */

            /*Q19: How can you inherit from a generic class?
            Generic classes can inherit from other generic or non-generic classes. Several patterns are possible.
                Pattern 1: Inherit and Pass Type Parameter
                Pattern 2: Inherit with Concrete Type
                Pattern 3: Add New Type Parameter
             */

            /*Q20: Complete Exercise - Create a generic Cache<TKey, TValue>with Add, Get, Remove, Contains, and expiration support.
            var cache = new Cache<string, string>();

            cache.Add("name", "Yara", 5); // expires in 5 seconds

            Console.WriteLine(cache.Get("name")); // Yara

            Thread.Sleep(6000);

            Console.WriteLine(cache.Contains("name")); // false (expired)
            */
        }
    }

       
}

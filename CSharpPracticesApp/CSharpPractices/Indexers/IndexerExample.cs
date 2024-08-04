using System;

namespace CSharpPractices.Indexers
{
    public class SampleCollection<T>
    {
        private readonly T[] arr = new T[100];

        public T this[int index]
        {
            get { return arr[index]; }
            set { arr[index] = value; }
        }
    }

    public static class IndexerExample
    {
        public static void Run()
        {
            var collection = new SampleCollection<string>();
            collection[0] = "Hello";
            collection[1] = "World";
            Console.WriteLine(collection[0]); // Output: Hello
            Console.WriteLine(collection[1]); // Output: World
        }
    }
}

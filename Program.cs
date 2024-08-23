using System.Diagnostics.Contracts;

namespace dotNetPlayground
{
    public class Program
    {
        protected Program() { }

        public static void Main(string[] args)
        {
            Console.Write("Write");
            Console.Write("Write2");
            Console.WriteLine("WriteLine");
            Console.Write("Write");
            Console.Write("Write2");
            Console.WriteLine("");

            // Arrays
            string[] myGrocceryArray = new string[2];

            myGrocceryArray[0] = "First Array Value";
            Console.WriteLine(myGrocceryArray[0]);
            Console.WriteLine(myGrocceryArray[1]);

            string[] mySecondArray = { "Apples", "Eggs" };
            Console.WriteLine(mySecondArray[0]);
            Console.WriteLine(mySecondArray[1]);

            // List
            List<string> myGroceryList = new List<string>() { "Milk", "Cheese" };
            myGroceryList.Add("Paneer");
            foreach (var item in myGroceryList)
            {
                Console.WriteLine(item);
            }

            //IEnumerable
            IEnumerable<string> myGroceryEnumerable = myGroceryList;
            Console.WriteLine(myGroceryEnumerable.First());

            //2d Arrays
            string[,] myTwoDimensionalArray = new string[,]
            {
                { "2d-Apples", "2d-Eggs" },
                { "2d-Milk", "2d-Cheese" }
            };
            Console.WriteLine(myTwoDimensionalArray[0, 0]);

            // Dictionary
            Dictionary<string, string> myGroceryDictionary = new Dictionary<string, string>()
            {
                { "dict-String", "dict-Dairy" }
            };
            Console.WriteLine(myGroceryDictionary["dict-String"]);
        }
    }
}

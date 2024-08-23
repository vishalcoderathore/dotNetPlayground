using System.Diagnostics.Contracts;

namespace dotNetPlayground
{
    public class Program
    {
        protected Program() { }

        private static int GetSum()
        {
            int[] intsToCompress = { 10, 15, 20, 25, 30, 12, 34 };
            int totalValue = 0;
            foreach (int intForCompression in intsToCompress)
            {
                totalValue += intForCompression;
            }
            return totalValue;
        }

        public static void Main(string[] args)
        {
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

            // Methods
            Console.WriteLine(GetSum());
        }
    }
}

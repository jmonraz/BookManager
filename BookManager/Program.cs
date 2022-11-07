using BookManager;

namespace BookManager
{
    public class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book();

            bool isOn = true;

            while(isOn)
            {
                Console.Clear();
                Console.WriteLine("\t\t\t==============================================");
                Console.WriteLine("\t\t\t========== Book Manager      =================");
                Console.WriteLine("\t\t\t==========      Menu         =================");
                Console.WriteLine("\t\t\t==============================================");

                Console.WriteLine("\n");
                Console.WriteLine("\t\t\t\t----------------------------------");
                Console.WriteLine("\t\t\t\t| 1) Create book                 |");
                Console.WriteLine("\t\t\t\t| 2) Edit book                   |");
                Console.WriteLine("\t\t\t\t| 3) Erase book                  |");
                Console.WriteLine("\t\t\t\t| 4) See Progress by book        |");
                Console.WriteLine("\t\t\t\t| 5) Display library             |");
                Console.WriteLine("\t\t\t\t| 6) Search book                 |");
                Console.WriteLine("\t\t\t\t| 7) Create Collection           |");
                Console.WriteLine("\t\t\t\t| 8) Write a review              |");
                Console.WriteLine("\t\t\t\t| 9) About                       |");
                Console.WriteLine("\t\t\t\t| 10) Exit                       |");
                Console.WriteLine("\t\t\t\t----------------------------------");

                Console.WriteLine();
                Console.Write("\t\t\t\tInput option: ");

                string value = Console.ReadLine();
                int input = 0;

                if(!int.TryParse(value, out input) && input <= 0 || input > 10)
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid input");
                    Console.ReadKey();
                }

                else if (input == 1)
                {
                    book.CreateBook();
                }
                else if (input == 2)
                {
                    book.EditBook();
                }
                else if(input == 3)
                {
                    book.EraseBook();
                }
                else if (input == 5)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\n\n\n\n\n\t\t\t\t| 1) Display by Title            |");
                    Console.WriteLine("\t\t\t\t| 2) Display by Author           |");
                    Console.WriteLine("\t\t\t\t| 3) Display by Numbers of Pages |");
                    Console.WriteLine("\t\t\t\t| 4) Display by Genre            |");
                    Console.ReadKey();
                    Console.Clear();
                    book.DisplayBooks();
                }
                else if(input ==8)
                {
                    book.WriteReview();
                }
                else if (input == 9)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\n\n");
                    Console.WriteLine("\t\t\t\t Program under development");
                    Console.WriteLine("\t\t\t\t Property of Jorge Monraz");
                    Console.WriteLine("\t\t\t\t Last date modified: 11/07/2022");
                    Console.ResetColor();
                    Console.ReadKey();
                }
                else if (input == 10)
                {
                    isOn = false;
                }
            }
        }
    }
}
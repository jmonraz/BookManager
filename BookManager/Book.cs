using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BookManager
{
    public class Book
    {
        protected string _title = "Title: ";
        protected string _author = "Author: ";
        protected string _pages = "Pages: ";
        protected string _genre = "Genre: ";

        protected string _file = @".\books.txt";

        protected List<Book> _textLines = new List<Book>();

        void AddBooks()
        {
            Book book = new Book();
            if (File.Exists(_file))
            {
                StreamReader textFile = new StreamReader(_file);

                string currLine;

                if (_textLines.Count == 0)
                {
                    while ((currLine = textFile.ReadLine()) != null)
                    {
                        if (currLine.StartsWith(_title))
                        {
                            book._title = currLine;
                        }
                        if (currLine.StartsWith(_author))
                        {
                            book._author = currLine;
                        }
                        if (currLine.StartsWith(_pages))
                        {
                            book._pages = currLine;
                        }
                        if (currLine.StartsWith(_genre))
                        {
                            book._genre = currLine;
                            _textLines.Add(new Book { _title = book._title, _author = book._author, _pages = book._pages, _genre = book._genre });
                        }
                    }
                }
                textFile.Close();
            }
        }
        public void CreateBook()
        {
            Book book = new Book();
            Book tempBook = new Book();

            Console.Write("Enter book title: ");
            tempBook._title = "Title: " + Console.ReadLine();

            Console.Write("Enter author name: ");
            tempBook._author = "Author: " + Console.ReadLine();

            Console.Write("Enter number of pages: ");
            tempBook._pages = "Pages: " + Console.ReadLine();

            Console.Write("Enter book genre: ");
            tempBook._genre = "Genre: " + Console.ReadLine();

            bool bookExists = false;

            if (File.Exists(_file))
            {
                StreamReader textFile = new StreamReader(_file);

                string currLine;

                if (_textLines.Count == 0)
                {
                    while ((currLine = textFile.ReadLine()) != null)
                    {
                        if (currLine.StartsWith(_title))
                        {
                            book._title = currLine;
                        }
                        if (currLine.StartsWith(_author))
                        {
                            book._author = currLine;
                        }
                        if (currLine.StartsWith(_pages))
                        {
                            book._pages = currLine;
                        }
                        if (currLine.StartsWith(_genre))
                        {
                            book._genre = currLine;
                            _textLines.Add(new Book { _title = book._title, _author = book._author, _pages = book._pages, _genre = book._genre });
                        }

                    }
                }

                for (int i = 0; i < _textLines.Count; i++)
                {
                    if (_textLines[i]._title == tempBook._title)
                    {
                        bookExists = true;
                        Console.WriteLine();
                        Console.WriteLine($"Book with {_textLines[i]._title} already exists");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    }
                }
                textFile.Close();
            }
            if (!bookExists)
            {

                using (StreamWriter w = File.AppendText(_file))
                {
                    _textLines.Add(tempBook);
                    for (int i = 0; i < 1; i++)
                    {
                        w.WriteLine(tempBook._title);
                        w.WriteLine(tempBook._author);
                        w.WriteLine(tempBook._pages);
                        w.WriteLine(tempBook._genre);
                    }

                }

                Console.WriteLine();
                Console.WriteLine("Book saved successfully");
                Console.WriteLine("Enter any key to continue");
                Console.ReadKey();
            }


        }

        public void DisplayBooks()
        {
            AddBooks();

            if(_textLines.Count == 0)
            {
                Console.WriteLine("There are no books in your library");
            }
            else
            {
                for(int i = 0; i < _textLines.Count; i++)
                {
                    Console.WriteLine("--------------------------------------------------------------");
                    Console.WriteLine(_textLines[i]._title);
                    Console.WriteLine(_textLines[i]._author);
                    Console.WriteLine(_textLines[i]._pages);
                    Console.WriteLine(_textLines[i]._genre);
                }
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPress any key to continue");
            Console.ResetColor();
            Console.ReadKey();
        }

        public void EraseBook()
        {

            AddBooks();

            bool isTrue = false;
            while(!isTrue)
            {
                Console.Clear();
                int bookCount = 0;

                for (int i = 0; i < _textLines.Count; i++)
                {
                    Console.WriteLine((i + 1) + ") " + _textLines[i]._title);
                    bookCount++;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Press {bookCount + 1} to go BACK");
                Console.ResetColor();
                Console.WriteLine();
                Console.Write("Which book do you want to delete?: ");
                string value = Console.ReadLine();
                int option = 0;

                if (!int.TryParse(value, out option))
                {
                    Console.WriteLine("Invalid input");
                    Console.ReadKey();
                }
                else if (int.TryParse(value, out option) && option <= 0 || option > bookCount && option != bookCount + 1)
                {
                    Console.WriteLine("Invalid input");
                    Console.ReadKey();
                }
                else if (int.TryParse(value, out option) && option == bookCount + 1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"{_textLines[option - 1]._title} was removed.");
                    Console.WriteLine("Press any KEY to continue");
                    Console.ReadKey();
                    _textLines.Remove(_textLines[option - 1]);
                    StreamWriter w = new StreamWriter(_file);
                    w.Flush();
                    w.Close();

                    
                    using (w = File.AppendText(_file))
                    {
                        for (int i = 0; i < _textLines.Count; i++)
                        {
                            w.WriteLine(_textLines[i]._title);
                            w.WriteLine(_textLines[i]._author);
                            w.WriteLine(_textLines[i]._pages);
                            w.WriteLine(_textLines[i]._genre);
                        }
                    }
                }
            }
        }

        public void WriteReview()
        {

            AddBooks();

            bool valid = false;

            while(!valid)
            {
                Console.Clear();
                int bookCount = 0;

                for (int i = 0; i < _textLines.Count; i++)
                {
                    Console.WriteLine((i+1) + ")" + _textLines[i]._title);
                    bookCount++;
                    
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Press " + (bookCount+1) +" to go BACK");
                Console.ResetColor();
                Console.WriteLine();
                Console.Write("For which book do you want to write a review?: ");

                string value = Console.ReadLine();
                int option = 0;

                if (!int.TryParse(value, out option))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not a valid option");
                    Console.ResetColor();
                    Console.ReadKey();
                }
                    
                else if (int.TryParse(value, out option) && option <= 0 || option > bookCount && option != bookCount+1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not a valid option");
                    Console.ResetColor();
                    Console.ReadKey();

                }
                else if(int.TryParse(value, out option) && option == bookCount+1)
                {
                    break;
                }
                else
                {
                    string str = _textLines[option - 1]._title;
                    string newstr = str.Remove(0, 7);
                    string currFile = @".\" + newstr + ".txt";
                    Console.Clear();
                    Console.Write("Write your review for " + newstr + ", press any ENTER when you are done: ");
                    string review = Console.ReadLine();
                    using (StreamWriter w = File.AppendText(currFile))
                    {
                        w.Write(review);
                    }

                    Console.WriteLine("Review saved. Press any key to continue.");
                    Console.ReadKey();
                }
            }
            
        }

        public void EditBook()
        {
            AddBooks();

            bool valid = false;

            while (!valid)
            {
                Console.Clear();
                int bookCount = 0;

                for (int i = 0; i < _textLines.Count; i++)
                {
                    Console.WriteLine((i + 1) + ")" + _textLines[i]._title);
                    bookCount++;

                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Press " + (bookCount + 1) + " to go BACK");
                Console.ResetColor();
                Console.WriteLine();
                Console.Write("Which book do you want to edit? ");

                string value = Console.ReadLine();
                int option = 0;

                if (!int.TryParse(value, out option))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not a valid option");
                    Console.ResetColor();
                    Console.ReadKey();
                }

                else if (int.TryParse(value, out option) && option <= 0 || option > bookCount && option != bookCount + 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not a valid option");
                    Console.ResetColor();
                    Console.ReadKey();

                }
                else if (int.TryParse(value, out option) && option == bookCount + 1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Update book");
                    _textLines.Remove(_textLines[option - 1]);
                    StreamWriter w = new StreamWriter(_file);
                    w.Flush();
                    w.Close();

                    using (w = File.AppendText(_file))
                    {
                        for (int i = 0; i < _textLines.Count; i++)
                        {
                            w.WriteLine(_textLines[i]._title);
                            w.WriteLine(_textLines[i]._author);
                            w.WriteLine(_textLines[i]._pages);
                            w.WriteLine(_textLines[i]._genre);
                        }
                    }

                    CreateBook();
                }
            }
        }
    }
}

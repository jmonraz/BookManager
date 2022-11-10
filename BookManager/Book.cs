using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BookManager;

namespace BookManager
{
    public class Book
    {
        public string _title = "Title: ";
        public string _author = "Author: ";
        public string _pages = "Pages: ";
        public string _genre = "Genre: ";
        protected string _currPage = "Current Page: ";

        protected string _file = @".\books.txt";

        protected List<Book> _textLines = new List<Book>();

        public List<Book> AddBooks()
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
                            
                        }
                        if (currLine.StartsWith(_currPage))
                        {
                            book._currPage = currLine;
                            _textLines.Add(new Book { _title = book._title, _author = book._author, _pages = book._pages, _genre = book._genre, _currPage = book._currPage });
                        }
                    }
                }
                textFile.Close();
            }

            return _textLines;
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

            tempBook._currPage = "Current Page: 1";

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
                        if (currLine.StartsWith(_currPage))
                        {
                            book._currPage = currLine;
                        }
                        if (currLine.StartsWith(_genre))
                        {
                            book._genre = currLine;
                            _textLines.Add(new Book { _title = book._title, _author = book._author, _pages = book._pages, _genre = book._genre, _currPage = book._currPage });
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
                        w.WriteLine(tempBook._currPage);
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
            Sorting sort = new Sorting();

            AddBooks();

            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\t\t\t\t| 1) Display by Title            |");
            Console.WriteLine("\t\t\t\t| 2) Display by Author           |");
            Console.WriteLine("\t\t\t\t| 3) Display by Numbers of Pages |");
            Console.WriteLine("\t\t\t\t| 4) Display by Genre            |");
            Console.WriteLine();
            Console.Write("Press option: ");
            int input = int.Parse(Console.ReadLine());

            Console.Clear();
            if (_textLines.Count == 0)
            {
                Console.WriteLine("There are no books in your library");
            }
            else if(input == 1)
            {
                List<Book> newBooks = sort.BubbleSortByTitle(_textLines);

                for(int i = 0; i < newBooks.Count; i++)
                {
                    Console.WriteLine("--------------------------------------------------------------");
                    Console.WriteLine(newBooks[i]._title);
                    Console.WriteLine(newBooks[i]._author);
                    Console.WriteLine(newBooks[i]._pages);
                    Console.WriteLine(newBooks[i]._genre);
                }
            }
            else if (input == 2)
            {
                List<Book> newBooks = sort.BubbleSortByAuthor(_textLines);

                for (int i = 0; i < newBooks.Count; i++)
                {
                    Console.WriteLine("--------------------------------------------------------------");

                    Console.WriteLine(newBooks[i]._author);
                    Console.WriteLine(newBooks[i]._title);
                    Console.WriteLine(newBooks[i]._pages);
                    Console.WriteLine(newBooks[i]._genre);
                }
            }
            else if (input == 3)
            {
                List<Book> newBooks = sort.BubbleSortByNumberOfPages(_textLines);

                for (int i = 0; i < newBooks.Count; i++)
                {
                    Console.WriteLine("--------------------------------------------------------------");
                    Console.WriteLine(newBooks[i]._pages);
                    Console.WriteLine(newBooks[i]._title);
                    Console.WriteLine(newBooks[i]._author);
                    Console.WriteLine(newBooks[i]._genre);
                }
            }
            else if (input == 4)
            {
                List<Book> newBooks = sort.BubbleSortByGenre(_textLines);

                for (int i = 0; i < newBooks.Count; i++)
                {
                    Console.WriteLine("--------------------------------------------------------------");
                    Console.WriteLine(newBooks[i]._genre);
                    Console.WriteLine(newBooks[i]._title);
                    Console.WriteLine(newBooks[i]._author);
                    Console.WriteLine(newBooks[i]._pages);
                    
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
                    Console.WriteLine("--------------------------------------------------------------");
                    Console.WriteLine((i + 1) + ".\n" + _textLines[i]._title);
                    Console.WriteLine(_textLines[i]._author);
                    Console.WriteLine(_textLines[i]._pages);
                    Console.WriteLine(_textLines[i]._genre);
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
                    Console.WriteLine("--------------------------------------------------------------");
                    Console.WriteLine((i + 1) + ".\n" + _textLines[i]._title);
                    Console.WriteLine(_textLines[i]._author);
                    Console.WriteLine(_textLines[i]._pages);
                    Console.WriteLine(_textLines[i]._genre);
                    bookCount++;
                    
                }
                Console.WriteLine();
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
                    Console.WriteLine("--------------------------------------------------------------");
                    Console.WriteLine((i + 1) + ".\n" + _textLines[i]._title);
                    Console.WriteLine(_textLines[i]._author);
                    Console.WriteLine(_textLines[i]._pages);
                    Console.WriteLine(_textLines[i]._genre);
                    bookCount++;

                }
                Console.WriteLine();
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
                    

                    CreateBook();

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
                            w.WriteLine(_textLines[i]._currPage);
                        }
                    }

                    
                }
            }
        }

        public void ProgressByBook()
        {
            AddBooks();

            bool valid = false;

            while (!valid)
            {
                Console.Clear();
                int bookCount = 0;

                for (int i = 0; i < _textLines.Count; i++)
                {
                    string str = _textLines[i]._currPage;
                    float currPg = float.Parse(str.Remove(0, 13));
                    str = _textLines[i]._pages;
                    float numPg = float.Parse(str.Remove(0, 7));
                    float total = (currPg / numPg) * 100;
                    Console.WriteLine("--------------------------------------------------------------");
                    Console.WriteLine((i + 1) + ".\n" + _textLines[i]._title);
                    Console.WriteLine(_textLines[i]._author);
                    Console.WriteLine(_textLines[i]._pages);
                    Console.WriteLine(_textLines[i]._genre);
                    Console.WriteLine($"Pages Read: {currPg} of {numPg}");
                    Console.WriteLine($"Percentage: {total}%");
                    bookCount++;
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Press " + (bookCount + 1) + " to go BACK");
                Console.ResetColor();
                Console.WriteLine();
                Console.Write("Which book do you want to update? ");

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
                    Console.Write("Current page: ");
                    string currentPage = "Current Page: " + Console.ReadLine();
                    _textLines[option - 1]._currPage = currentPage;

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
                            w.WriteLine(_textLines[i]._currPage);
                        }
                    }
                    
                }
            }
        }
    }
}

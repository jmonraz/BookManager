using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManager;

namespace BookManager
{
    public class Sorting
    {
        public List<Book> BubbleSortByGenre(List<Book> unsorted)
        {
            List<Book> sorted = new List<Book>(unsorted);
            int n = sorted.Count;
            bool swapped;

            do
            {
                swapped = false;

                for (int i = 1; i <= n - 1; i++)
                {
                    if (sorted[i - 1]._genre.CompareTo(sorted[i]._genre) > 0)
                    {
                        Swap(sorted, i - 1, i);
                        swapped = true;
                    }
                }
                n--;
            } while (swapped);
            return sorted;
        }
        public List<Book> BubbleSortByNumberOfPages(List<Book> unsorted)
        {
            List<Book> sorted = new List<Book>(unsorted);
            int n = sorted.Count;
            bool swapped;

            do
            {
                swapped = false;

                for (int i = 1; i <= n - 1; i++)
                {
                    if (sorted[i - 1]._pages.CompareTo(sorted[i]._pages) > 0)
                    {
                        Swap(sorted, i - 1, i);
                        swapped = true;
                    }
                }
                n--;
            } while (swapped);
            return sorted;
        }
        public List<Book> BubbleSortByAuthor(List<Book> unsorted)
        {
            List<Book> sorted = new List<Book>(unsorted);
            int n = sorted.Count;
            bool swapped;

            do
            {
                swapped = false;

                for (int i = 1; i <= n - 1; i++)
                {
                    if (sorted[i - 1]._author.CompareTo(sorted[i]._author) > 0)
                    {
                        Swap(sorted, i - 1, i);
                        swapped = true;
                    }
                }
                n--;
            } while (swapped);
            return sorted;
        }
        public List<Book> BubbleSortByTitle(List<Book> unsorted)
        {
            List<Book> sorted = new List<Book>(unsorted);
            int n = sorted.Count;
            bool swapped;

            do
            {
                swapped = false;

                for (int i = 1; i <= n - 1; i++)
                {
                    if (sorted[i - 1]._title.CompareTo(sorted[i]._title) > 0)
                    {
                        Swap(sorted, i - 1, i);
                        swapped = true;
                    }
                }
                n--;
            }while(swapped);
            return sorted;
        }

        public void Swap(List<Book> num, int index1, int index2)
        {
            Book tempBook = num[index1];
            num[index1] = num[index2];
            num[index2] = tempBook;
        }
    }
}

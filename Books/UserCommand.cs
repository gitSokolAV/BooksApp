using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    public static class UserCommand
    {
       
        public static string SelectQuery()
        {
            
            while (true)
            {
                Console.WriteLine("(Enter the command: select / insert / update / delete) or exit  ");
                string command = Console.ReadLine().ToLower();
                if (command.Equals("exit")) return "exit";
                else if (command.Equals("select")) return "select * from [books]";
                else if (command.Equals("insert"))
                {
                    Console.WriteLine("Enter title book: ");
                    string titleBook = Console.ReadLine();

                    Console.WriteLine("Enter author book: ");
                    string authorBook = Console.ReadLine();

                    Console.WriteLine("Enter date of publication: ");
                    string dateOfPublication = Console.ReadLine();

                    bool isValidValueInt = false;
                    int bookQuantity = 0;
                    while (isValidValueInt == false)
                    {
                        Console.WriteLine("Enter book quantity: ");
                        if (int.TryParse(Console.ReadLine(), out bookQuantity)) isValidValueInt = true;
                        else isValidValueInt = false;
                    }

                    decimal valueFloat = 0;
                    bool isValidValueFloat = false;

                    while (isValidValueFloat == false)
                    {
                        Console.WriteLine("Enter book price: ");
                        if (decimal.TryParse(Console.ReadLine().Replace(',', '.'), out valueFloat)) isValidValueFloat = true;
                        else isValidValueFloat = false;
                    }
                    return $"insert into books (TitleBook, AuthorBook,DateOfPublication, BookQuantity,Price) values ('{titleBook}', '{authorBook}', '{dateOfPublication}', '{bookQuantity}', '{valueFloat}')";

                }
                
            }
            
        }
    }
}

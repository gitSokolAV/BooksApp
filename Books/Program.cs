using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



namespace Books
{
    internal class Program
    {
        //Подлючение без отображения прямой строки подключения
        private static string connectionSting = ConfigurationManager.ConnectionStrings["BooksDB"].ConnectionString;
        
        private static SqlConnection sqlConnection = null;


        static void Main(string[] args)
        {
            sqlConnection = new SqlConnection(connectionSting);
            //открытие поключения
            sqlConnection.Open();

            Console.WriteLine("BooksApp");

            SqlDataReader sqlDataReader = null;

            string command = "";
            bool flag = true;
            while (flag)
            {
                Console.Write(">> ");
                command = UserCommand.SelectQuery();

                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                
                switch(command.Split(' ')[0].ToLower())
                {
                    case "select":

                        sqlDataReader = sqlCommand.ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine($"{sqlDataReader["Id"]} {sqlDataReader["TitleBook"]}" +
                                $" {sqlDataReader["AuthorBook"]} {sqlDataReader["DateOfPublication"]}" +
                                $" {sqlDataReader["BookQuantity"]} {sqlDataReader["Price"]}");
                            Console.WriteLine(new String('-', 50));
                        }

                        break;
                    case "insert":
                        

                        Console.WriteLine($"A line {sqlCommand.ExecuteNonQuery()} has been added.");

                        break;
                    case "update":


                        break;
                    case "delete":


                        break;
                    case "exit":
                        if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close();
                        if (sqlDataReader != null) sqlDataReader.Close();
                        flag = false;
                        break;

                    default:

                        Console.WriteLine($"The entered command {command} is not correct");

                        break;

                }
                


            }
            Console.WriteLine("Press any key..");
            Console.ReadKey();


        }
    }
}

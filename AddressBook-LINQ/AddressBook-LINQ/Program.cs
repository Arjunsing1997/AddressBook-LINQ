using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AddressBook_LINQ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to AddressBook LINQ");
            Program book = new Program();
            //Creating Data Base
            DataTable table = new DataTable();
            book.Columns(table); //Passing Data base As parameter
            book.InsertRows(table); //Calling Insertion Method
            book.Display(table);    //To Display the Data Base

            AddressBookManagement management = new AddressBookManagement();
            management.UpdateInfo(table);

            management.DeletePerson(table);

            Console.ReadLine();
        }

        //UC2 Adding columns to DB
        public  bool Columns(DataTable table)
        {
            DataColumn column;
            

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "firstName";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "lastName";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "address";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "city";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "state";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "zip";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "phoneNumber";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "eMail";
            table.Columns.Add(column);

            return true;
        }

        //Adding rows to the DB
        public void InsertRows(DataTable table)
        {
            table.Rows.Add("Kim", "Kardashian", "Street 1", "Lakers", "Los Angeles", 444556, 6785674567, "lb@gmail.com");
            table.Rows.Add("Kylie", "Jenner", "Street 3", "Celtics", "Boston", 345267, 2345678987, "kylie@gmail.com");
            table.Rows.Add("Kris", "Jenner", "Block 4", "Warriors", "Golden State", 987654, 3456787654, "kris@gmail.com");
            table.Rows.Add("Khloe", "Lamar", "Street 5", "Rockets", "Houston", 234566, 6543456789, "khloe@gmail.com");
            table.Rows.Add("Kourtney", "Scott", "Block 2", "Hornets ", "Charlotte ", 444556, 3456787654, "ks@gmail.com");
        }

        public void Display(DataTable table)
        {
            var dataRow = table.AsEnumerable().Select(x => new { 
                firstName = x.Field<string>("firstName"),
                lastname = x.Field<string>("lastname"),
                address = x.Field<string>("address"),
                city = x.Field<string>("city"),
                state = x.Field<string>("state"),
                zip = x.Field<int>("zip"),
                phoneNumber = x.Field<double>("phoneNumber"),
                eMail = x.Field<string>("eMail")
            });

            Console.WriteLine("======================================");

            Console.WriteLine("FirstName\t lastName \t Address \t City \t State \t Zip \t PhNumber \t Email");

            foreach (var data in dataRow)
            {
                Console.Write(data.firstName+"\t\t"+data.lastname+"\t\t"+data.address+"\t"+data.city+"\t"
                    +data.state+"\t"+data.zip+"\t"+data.phoneNumber+"\t"+data.eMail);
                Console.WriteLine();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AddressBook_LINQ
{
    public class AddressBookManagement
    {
        Program book = new Program();
        public void UpdateInfo(DataTable table)
        {
            var records = table.AsEnumerable().Where(a => a.Field<string>("firstName").Equals("Kim")).FirstOrDefault();
            records["state"] = "Bango";
            book.Display(table);
        }

        public void DeletePerson(DataTable table)
        {
            DataTable dataTableupdated = table.AsEnumerable().Except(table.AsEnumerable().Where(r => r.Field<string>("firstName") == "Khloe" && r.Field<string>("lastName") == "Lamar")).CopyToDataTable();
            book.Display(dataTableupdated);
        }

        public void CityOrState(DataTable table)
        {
            //lambda syntax for getting data for particular city
            var recordData = table.AsEnumerable().Where(r => r.Field<string>("city") == "Celtics"  || r.Field<string>("state") == "Charlotte");

            foreach (var data in recordData)
            {
                Console.WriteLine("FirstName:- " + data.Field<string>("firstName"));
                Console.WriteLine("lastName:- " + data.Field<string>("lastName"));
                Console.WriteLine("Address:- " + data.Field<string>("address"));
                Console.WriteLine("City:- " + data.Field<string>("city"));
                Console.WriteLine("State:- " + data.Field<string>("state"));
                Console.WriteLine("zip:- " + Convert.ToInt32(data.Field<int>("zip")));
                Console.WriteLine("phoneNumber:- " + Convert.ToDouble(data.Field<Double>("phoneNumber")));
                Console.WriteLine("eMail:- " + data.Field<string>("eMail"));
                Console.WriteLine("***************");
            }
        }

        public void Count_By_City_Or_State(DataTable table)
        {
            //getting count for particular state or city
            var countOfCityState = table.AsEnumerable().Where(r => r.Field<string>("city") == "Lakers" && r.Field<string>("state") == "Los Angeles").Count();

            //grouping data by city and state
            var recordedData = from data in table.AsEnumerable()
                               group data by new { city = data.Field<string>("city"), state = data.Field<string>("state") } into g
                               select new { city = g.Key.city, state =g.Key.state , count = g.Count() };
            //displaying data for particular city or state
            Console.WriteLine("Count of City or State: "+countOfCityState);
            //displaying total grouped data
            foreach (var data in recordedData)
            {
                Console.WriteLine("city:- " + data.city);
                Console.WriteLine("state:- " + data.state);
                Console.WriteLine("Count:- " + data.count);
                Console.WriteLine("*******************");
            }
        }
    }
}

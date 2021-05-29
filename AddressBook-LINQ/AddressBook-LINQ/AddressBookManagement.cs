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
    }
}

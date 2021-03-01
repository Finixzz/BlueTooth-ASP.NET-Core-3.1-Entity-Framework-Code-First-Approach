using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models.Interfaces
{
    public interface IBillRepository
    {
        Bill AddBill(Bill bill);

        Bill GetBill(int id);
        IEnumerable<Bill> GetBills();
    }
}

using BlueTooth.DbContext;
using BlueTooth.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models.Repositories
{
    public class BillSQLRepository : IBillRepository
    {
        private ApplicationDbContext _context;

        public BillSQLRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Bill AddBill(Bill bill)
        {
            _context.Bills.Add(bill);
            _context.SaveChanges();
            return bill;
        }

        public Bill GetBill(int id)
        {
            return _context.Bills.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Bill> GetBills()
        {
            return _context.Bills;
        }
    }
}

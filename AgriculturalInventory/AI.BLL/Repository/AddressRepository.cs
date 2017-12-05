using AI.BLL.Interfaces;
using AI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AI.BLL.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AIContext _context;

        public AddressRepository(AIContext context)
        {
            _context = context;
        }

        public IEnumerable<Address> GetAllAddres()
        {
            return _context.Address;
        }
    }
}

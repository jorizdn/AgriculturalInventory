using AI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AI.BLL.Interfaces
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAllAddres(); 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AI.DAL.Entities;
using AI.BLL.Interfaces;

namespace AI.Interface.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressRepository _address;

        public AddressController(IAddressRepository address)
        {
            _address = address;
        }

        public IActionResult Index()
        {
            return View(_address.GetAllAddres());
        }
    }
}
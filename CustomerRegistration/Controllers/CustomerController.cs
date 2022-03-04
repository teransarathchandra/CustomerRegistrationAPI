using CustomerRegistration.Modules;
using CustomerRegistration.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private DatabaseSettings _databaseSettings;

        public CustomerController(DatabaseSettings databaseSettings)
        {
            _databaseSettings = databaseSettings;
        }

        [Route("GetCustomer")]
        [HttpGet, HttpOptions]
        [EnableCors("MyPolicy")]
        public List<Customer> GetCustomer()
         {

                CustomerRepository CustomerRepository = new CustomerRepository(_databaseSettings);
                List<Customer> customerRepository = CustomerRepository.GetCustomer();
                return (customerRepository);

        }

        [Route("InsertCustomer")]
        [HttpPost, HttpOptions]
        [EnableCors("MyPolicy")]
        public IActionResult InsertCustomer(Customer CM)
        {
            try
            {
                CustomerRepository CustomerRepository = new CustomerRepository(_databaseSettings);
                string Customer = CustomerRepository.InsertCustomer(CM);
                return Ok(Customer);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("UpdateCustomer")]
        [HttpPut, HttpOptions]
        [EnableCors("MyPolicy")]
        public IActionResult UpdateCustomer(Customer CM)
        {
            try
            {
                CustomerRepository CustomerRepository = new CustomerRepository(_databaseSettings);
                string Customer = CustomerRepository.UpdateCustomer(CM);
                return Ok(Customer);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("DeleteCustomer")]
        [HttpDelete, HttpOptions]
        [EnableCors("MyPolicy")]
        public IActionResult DeleteCustomer(int customerID)
        {
            try
            {
                CustomerRepository CustomerRepository = new CustomerRepository(_databaseSettings);
                string Customer = CustomerRepository.DeleteCustomer(customerID);
                return Ok(Customer);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}

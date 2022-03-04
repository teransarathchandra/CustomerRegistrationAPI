using CustomerRegistration.Modules;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRegistration.Repository
{
    public class CustomerRepository
    {
        private string _connectionString;

        public CustomerRepository(DatabaseSettings databaseSettings)
        {
            this._connectionString = databaseSettings._DatabaseConnectionString;
        }

        public List<Customer> GetCustomer()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters para = new DynamicParameters();

                    return connection.Query<Customer>("GetCustomer", para, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public string InsertCustomer(Customer CM)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters Parameters = new DynamicParameters();
                    Parameters.Add("@CustomerName", CM.CustomerName);
                    Parameters.Add("@PhoneNumber", CM.PhoneNumber);
                    Parameters.Add("@Address", CM.Address);
                    Parameters.Add("@Email", CM.Email);

                    connection.Query<Customer>("InsertCustomer", Parameters, commandType: CommandType.StoredProcedure);

                    return "Customer Added Successfully!";
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public string UpdateCustomer(Customer CM)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters Parameters = new DynamicParameters();
                    Parameters.Add("@CustomerID", CM.CustomerID);
                    Parameters.Add("@CustomerName", CM.CustomerName);
                    Parameters.Add("@PhoneNumber", CM.PhoneNumber);
                    Parameters.Add("@Address", CM.Address);
                    Parameters.Add("@Email", CM.Email);


                    connection.Query<Customer>("UpdateCustomer", Parameters, commandType: CommandType.StoredProcedure);

                    return "Customer Updated Successfully!";
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public string DeleteCustomer(int customerID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters Parameters = new DynamicParameters();
                    Parameters.Add("@CustomerID", customerID);

                    connection.Query<Customer>("DeleteCustomer", Parameters, commandType: CommandType.StoredProcedure);

                    return "Customer Deleted Successfully!";
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}

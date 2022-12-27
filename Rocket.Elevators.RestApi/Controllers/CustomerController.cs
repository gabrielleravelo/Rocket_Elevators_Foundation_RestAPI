using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket.Elevators.RestApi.Infra.Context;
using Rocket.Elevators.RestApi.Model;

namespace Rocket.Elevators.RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    
    public class CustomerController : ControllerBase
    {
        private readonly FluentMySqlContext _mySqlContext;
        Customer? customer = null;
        public CustomerController(FluentMySqlContext context)
        {
            _mySqlContext = context;
        }

		
		[HttpGet]
		public long GetIdByCustomerEmail(string email)
		{
			var customerId = _mySqlContext.Customers.Where(i => i.Email.Equals(email)).Select(x => x.Id)?.FirstOrDefault();

            return (long)customerId;
	
		}

		[HttpGet]
        public bool ValidateCustomerEmail(string inputemail)
        {
                          

            bool inputEmailBool = false;

            try {  Customer customer = _mySqlContext.Customers.Single(customer => customer.Email == inputemail);
                if (customer != null)
                    inputEmailBool = true;
            }
            catch (Exception error) { 
                
            }
            
            return inputEmailBool;
        }

        

		[HttpGet]
		public List<Building> GetAllBuildingByCustomerEmail(string email)
		{
			List<Building> buildings = new List<Building>();
			
			try
			{
				customer = _mySqlContext.Customers.Single(i => i.Email == email);
				buildings = _mySqlContext.Buildings.Where(building => building.CustomerId == customer.Id).ToList();
			}
			catch (Exception error)
			{

			}
            
			return buildings;
		}

		[HttpGet]
        public List<Battery> GetAllBatteriesByCustomerEmail(string email)
        {
            List<Building> buildings = new List<Building>();
            List<Battery> batteries = new List<Battery>();

            try
            {
                customer = _mySqlContext.Customers.Single(i => i.Email == email);
                buildings = _mySqlContext.Buildings.Where(building => building.CustomerId == customer.Id).ToList();
            }
            catch (Exception error)
            {

            }

            foreach (Building building in buildings)
            {
                batteries.AddRange(_mySqlContext.Batteries.Where(battery => battery.BuildingId == building.Id).ToList());
            }

            return batteries;
        }

        [HttpGet]
        public List<Column> GetAllColumnsByCustomerEmail(string email)
        {
            List<Building> buildings = new List<Building>();
            List<Column> columns = new List<Column>();

            try
            {
                customer = _mySqlContext.Customers.Single(i => i.Email == email);

                buildings = _mySqlContext.Buildings.Where(building => building.CustomerId == customer.Id).ToList();

            }
            catch (Exception error) { 
            }





            foreach (Building building in buildings)
            {
                List<Battery> batteries = _mySqlContext.Batteries.Where(battery => battery.BuildingId == building.Id).ToList();

                foreach (Battery battery in batteries)
                {
                    columns.AddRange(_mySqlContext.Columns.Where(column => column.BatteryId == battery.Id).ToList());
                }
            }

            return columns;
        }

        [HttpGet]
        public List<Elevator> GetAllElevatorsByCustomerEmail(string email)
        {
            List<Building> buildings = new List<Building>();
            List<Elevator> elevators = new List<Elevator>();

            try
            {
                Customer customer = _mySqlContext.Customers.Single(i => i.Email == email);

                buildings = _mySqlContext.Buildings.Where(building => building.CustomerId == customer.Id).ToList();

            }
            catch (Exception error)
            {

            }

            foreach (Building building in buildings)
            {
                List<Battery> batteries = _mySqlContext.Batteries.Where(battery => battery.BuildingId == building.Id).ToList();
                Console.WriteLine("batteries id " + batteries);

                foreach (Battery battery in batteries)
                {
                    List<Column> columns = _mySqlContext.Columns.Where(column => column.BatteryId == battery.Id).ToList();
                    
                    foreach(Column column in columns)
                    {
                        elevators.AddRange(_mySqlContext.Elevators.Where(elevator => elevator.ColumnId == column.Id).ToList());
                    }
                }
            }

            return elevators;
        }

    
    }
}

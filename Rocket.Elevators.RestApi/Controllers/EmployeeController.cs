using Microsoft.AspNetCore.Mvc;
using Rocket.Elevators.RestApi.Infra.Context;
using Rocket.Elevators.RestApi.Model;

namespace Rocket.Elevators.RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EmployeeController : ControllerBase
    {
        private readonly FluentMySqlContext _mySqlContext;

        public EmployeeController(FluentMySqlContext context)
        {
            _mySqlContext = context;
        }


		[HttpGet]
		public IEnumerable<Employee> GetAllEmployees()
		{
			return _mySqlContext.Employees;
		}

		[HttpGet]
		public bool ValidateEmail(string inputemail)
		{
			bool inputEmailBool = false;

			try
			{
				Employee employee = _mySqlContext.Employees.Single(employee=> employee.Email == inputemail);
				
				if (employee != null)
					inputEmailBool = true;
			}
			catch (Exception error)
			{

			}

			return inputEmailBool;
		}
	}
}

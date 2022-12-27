using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;
using Rocket.Elevators.RestApi.Infra.Context;
using Rocket.Elevators.RestApi.Model;

namespace Rocket.Elevators.RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BatteryController : ControllerBase
    {
        private readonly FluentMySqlContext _mySqlContext;

        public BatteryController(FluentMySqlContext context)
        {
            _mySqlContext = context;
        }

        [HttpGet]
        public IEnumerable<Battery> GetAllBatteries()
        {
            return _mySqlContext.Batteries;
        }

        

        [HttpGet]
        public string GetBatteryStatusById(long id)
        {
            var status = _mySqlContext.Batteries.Where(i => i.Id.Equals(id)).Select(x => x.Status).FirstOrDefault();

            return String.IsNullOrEmpty(status) ? "" : status;
        }


		//I commented this part in order to be able to make the api work for the customer portal
		//Code to review
		
        /*[HttpGet]
		public long GetBatteryBuildingIdById(long id)
		{
			var buildingid = _mySqlContext.Batteries.Where(i => i.Id.Equals(id)).Select(x => x.BuildingId).FirstOrDefault();

			return buildingid;
		}*/

		
        [HttpPost]
        public void UpdateStatusBatteryById(long id, string status)
        {
            var battery = _mySqlContext.Batteries.Single(i => i.Id.Equals(id));

            if (battery is not null && !string.IsNullOrEmpty(status))
            {
                battery.Status = status;
                _mySqlContext.SaveChanges();
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Rocket.Elevators.RestApi.Infra.Context;
using Rocket.Elevators.RestApi.Model;

namespace Rocket.Elevators.RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class InterventionController : ControllerBase
    {
        private readonly FluentMySqlContext _mySqlContext;

        public InterventionController(FluentMySqlContext context)
        {
            _mySqlContext = context;
        }

        [HttpGet]
        public IEnumerable<Intervention> GetAllInterventionsStatusPending()
        {
            return _mySqlContext.Interventions.Where(d => d.InterventionStartAt.Equals(null) && d.Status.Equals("Pending")).ToList();
        }

        [HttpPut]
        public void ChangeStatusAndStartDateById(long id)
        {
           var intervention =  _mySqlContext.Interventions.Single(i => i.Id.Equals(id));
            if (intervention is not null)
            {
                intervention.Status = "InProgress";
                intervention.InterventionStartAt = DateTime.Now;
                _mySqlContext.SaveChanges();
            }

        }

        [HttpPut]
        public void ChangeStatusAndEndDateById(long id)
        {
            var intervention = _mySqlContext.Interventions.Single(i => i.Id.Equals(id));
            if (intervention is not null)
            {
                intervention.Status = "Completed";
                intervention.InterventionEndAt = DateTime.Now;
                _mySqlContext.SaveChanges();
            }

        }


    }
}

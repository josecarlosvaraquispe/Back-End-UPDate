using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Infraestructure;
using Infrastructure.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace update
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        //Inyeccion
        private IActivityInfraestructure _activityInfraestructure;
        private IActivityDomain _activityDomain;

        public ActivityController(IActivityInfraestructure activityInfraestructure, IActivityDomain activityDomain)
        {
            _activityInfraestructure = activityInfraestructure;
            _activityDomain = activityDomain;
        }
        
        // GET: api/Activity
        [HttpGet]
        public List<Activity> Get()
        {
            return _activityDomain.GetAll();
        }

        // GET: api/Activity/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Activity
        [HttpPost]
        public void Post([FromBody] Activity activity)
        {
            _activityDomain.Create(activity.Title, activity.Description, activity.Address, activity.Date);
        }

        // PUT: api/Activity/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Activity activity)
        {
            _activityDomain.Update(id,activity.Title, activity.Description, activity.Address, activity.Date);
        }

        // DELETE: api/Activity/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _activityDomain.Delete(id);
        }
    }
}

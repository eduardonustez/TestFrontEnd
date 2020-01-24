using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test1.API.Models;
using System.Web;
using Newtonsoft.Json;

namespace Test1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            // return new string[] { "value1", "value2" };
            string resul = string.Empty;
            List<Project> lstProject = new List<Project>();
            DataSet ds = new DataSet();
            
            ds.ReadXml("XML/XMLFile.xml");
            DataView dvPrograms;
            dvPrograms = ds.Tables[0].DefaultView;
            dvPrograms.Sort = "Id";
            foreach (DataRowView dr in dvPrograms)
            {
                Project model = new Project();
                model.Id = Convert.ToInt32(dr[0]);
                model.ProjectName = Convert.ToString(dr[1]);
                model.Location = Convert.ToString(dr[2]);
                lstProject.Add(model);
            }
            if (lstProject.Count > 0)
            {
                resul = JsonConvert.SerializeObject(lstProject);
            }
            return resul;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

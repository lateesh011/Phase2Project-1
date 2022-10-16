using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using RouteAttribute = System.Web.Http.RouteAttribute;
using DalLib;
using BalLibrary;
using Project2.Models;


namespace Project2.Controllers
{
    public class EmpController : ApiController
    {
        empmethods mode = null;
        public EmpController()
        {
            mode = new empmethods();

        }
        List<EmpModel> ms = new List<EmpModel>();
        [Route("Getallemps")]
        public IEnumerable<EmpModel> Get()
        {
            List<EmpProfile> rs = mode.getEmployee();
            foreach (var item in rs)
            {
                EmpModel m = new EmpModel();
                m.EmpCode = item.EmpCode;
                m.EmpName = item.EmpName;
                m.Email = item.Email;
                m.DateOfBirth = item.DateOfBirth;
                m.DeptCode = item.DeptCode;

                ms.Add(m);
            }
            return ms;
        }

        // GET: api/dept/5
        [Route("Findempbyid{id}")]
        public EmpModel Get(int id)
        {
            EmpProfile r = mode.findemp(id);
            EmpModel m = new EmpModel();
            m.EmpCode = r.EmpCode;
            m.EmpName = r.EmpName;
            m.Email = r.Email;
            m.DateOfBirth = r.DateOfBirth;
            m.DeptCode = r.DeptCode;
            return m;
        }

        // POST: api/dept
        [Route("Addemp")]
        public HttpResponseMessage Post([FromBody] EmpModel value)
        {
            EmpProfile m = new EmpProfile();
            m.EmpCode = Convert.ToInt32(value.EmpCode);
            m.EmpName = value.EmpName;
            m.Email = value.Email;
            m.DateOfBirth = value.DateOfBirth;
            m.DeptCode = value.DeptCode;
            bool k = mode.AddEmployee(m);
            if (k)
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }


        }

        // PUT: api/dept/5
        [Route("UpdateEmp/{id}")]
        public HttpResponseMessage Put(int id, [FromBody] EmpModel value)
        {
            EmpProfile m = new EmpProfile();
            m.EmpCode = Convert.ToInt32(value.EmpCode);
            m.EmpName = value.EmpName;
            m.Email = value.Email;
            m.DateOfBirth = value.DateOfBirth;
            m.DeptCode = value.DeptCode;
            bool k = mode.UpdateEmployee(id, m);
            if (k)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }

        // DELETE: api/dept/5
        [Route("RemoveEmp/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            bool k = mode.Removemployee(id);
            if (k)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }
    }
}
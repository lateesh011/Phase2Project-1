using DalLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Project2.Models;
using BalLibrary;
using RouteAttribute = System.Web.Mvc.RouteAttribute;

namespace Project2.Controllers
{
        public class DepartmentController : ApiController
        {
            deptmethods mode = null;
            public DepartmentController()
            {
                mode = new deptmethods();

            }
            List<DeptModel> ms = new List<DeptModel>();
            [Route("Getalldeps")]
            public IEnumerable<DeptModel> Get()
            {
                List<DeptMaster> rs = mode.getdeptMasters();
                foreach (var item in rs)
                {
                    DeptModel m = new DeptModel();
                    m.DeptCode = item.DeptCode;
                    m.DeptName = item.DeptName;
                    ms.Add(m);
                }
                return ms;
            }

            // GET: api/dept/5
            [Route("Finddeptbyid{id}")]
            public DeptModel Get(int id)
            {
                DeptMaster r = mode.finddept(id);
                DeptModel m = new DeptModel();
                m.DeptCode = r.DeptCode;
                m.DeptName = r.DeptName;
                return m;
            }

            // POST: api/dept
            [Route("Adddept")]
            public HttpResponseMessage Post([FromBody] DeptModel value)
            {
                DeptMaster m = new DeptMaster();
                m.DeptCode = Convert.ToInt32(value.DeptCode);
                m.DeptName = value.DeptName;
                bool k = mode.adddeptmaster(m);
                if (k)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable);
                }


            }

            // PUT: api/dept/5
            [Route("Updatedept/{id}")]
            public HttpResponseMessage Put(int id, [FromBody] DeptModel value)
            {
                DeptMaster m = new DeptMaster();
                m.DeptCode = Convert.ToInt32(value.DeptCode);
                m.DeptName = value.DeptName;
                bool k = mode.updatemaster(id, m);
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
            [Route("Removedept/{id}")]
            public HttpResponseMessage Delete(int id)
            {
                bool k = mode.removemaster(id);
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
using MeruWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MeruWebApi.Controllers
{
    public class CustomerController : ApiController

       
    {
        MeruDbContext db;

        public CustomerController()
        {
            db = new MeruDbContext();
        }

        [Route("GetCustomerByMobNo")]
        [HttpGet]
        public IHttpActionResult GetCustomerByMobNo(string MobNo)
        {
            try
            {
                var CustomerDetails = (from cust in db.Customers
                                       join sbarea in db.SubAreas
                                       on cust.SubAreaId equals sbarea.SubAreaId
                                       join area in db.Areas
                                       on sbarea.AreaId equals area.AreaId
                                       join cty in db.Cities
                                       on area.CityId equals cty.CityId
                                       where cust.CustMobNo == MobNo
                                       select new CustomerVM
                                       {
                                           CustName = cust.CustName,
                                           Address = cust.Address,
                                           CustMobNo = cust.CustMobNo,
                                           SubAreaName = sbarea.SubAreaName,
                                           AreaName = area.AreaName,
                                           CityName = cty.CityName,
                                       }).Single();

                return Ok(CustomerDetails);
            }
            catch (Exception ex)
            {

                var errMsg = ex.Message;
                return InternalServerError();
            }
        }
    }
}

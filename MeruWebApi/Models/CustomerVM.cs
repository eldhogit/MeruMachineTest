using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeruWebApi.Models
{
    public class CustomerVM
    {

        public long CustId { get; set; }
        public string CustName { get; set; }
        public string CustMobNo { get; set; }
        public string Address { get; set; }
        public Nullable<long> SubAreaId { get; set; }
        public string SubAreaName { get; set; }
        public string AreaName { get; set; }
        public string CityName { get; set; }


    }
}
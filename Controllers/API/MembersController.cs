using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Library.Controllers.API
{
    public class MembersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public string GetMembersJson()
        {
            var s = db.member.ToList();
            string yourJson = Newtonsoft.Json.JsonConvert.SerializeObject(s);
            return yourJson;
        }
        //public IEnumerable<Member> GetMembersXml()
        //{
        //    return db.member.ToList();
        //}
    }
}

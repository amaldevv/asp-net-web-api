using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Routing.Models
{
    public class PersonDetail
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int Country { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class Client
    {
        [Key]
        public int id { get; set; }

        public string FirstName { get; set; }

        public String LastName { get; set; }

        public DateTime DOB { get; set; }

        public ICollection<ClientAddress> clientobj { get; set; }
    }
}
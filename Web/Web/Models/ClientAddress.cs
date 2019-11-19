using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class ClientAddress
    {
        [Key]
        public int AId { get; set; }

        public int Clientid { get; set; }

        public String Address { get; set; }

      

        //public  Client client { get; set; }


    }
}
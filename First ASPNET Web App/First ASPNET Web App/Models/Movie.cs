using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace First_ASPNET_Web_App.Models
{
    public class Movie //CLR or POCO, which represents state and behavior of app. in terms of its prob. domain
    {
        // creating properties
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
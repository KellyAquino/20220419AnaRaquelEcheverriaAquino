using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaAFP.Models
{
    public class Param
    {
        public string name { get; set; }
        public object value { get; set; }
        public Param(string n, object v)
        {
            this.name = n;
            this.value = v;
        }
    }
}
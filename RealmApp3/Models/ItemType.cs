using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealmApp3.Models
{
   public class ItemType:RealmObject
    {
        public int id = 3;
       // public string id { get; } = Guid.NewGuid().ToString();
        public string name { get; set; }
        //public IList<Param> parameters { get; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using Realms;
namespace RealmApp3.Models
{
   public class ItemObject:RealmObject
    {
       
        public string gid { get; } =Guid.NewGuid().ToString();
        public int id = 2;
        public string name { get; set; }
        public ItemType type { get; set; }
        public Manufactorer manufactorer { get; set; }
        public string model { get; set; }
        public int serial { get; set; }
        public IList<Param> values { get;  } 
        public Param param { get; set; }
    }
}

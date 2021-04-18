using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealmApp3.Models
{
   public  class Param: RealmObject
    {
        
        //public string id { get; } = Guid.NewGuid().ToString();
        
        public int id; 
           
        
        public string name { get; set; }
        public string value { get; set; }

        public void dfsdfsdf()
        {
            Random rnd2 = new Random();
            id = rnd2.Next(0, 100);
        }
    }
   
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Models
{
    public class ChartModel
    {

      
        public string Label { get; set; }

     
        //public List<DataModel> Data { get; set; }
        public List<DataModel> Data { get; set; }


        public ChartModel()
        {
            Data = new List<DataModel>();
        }



    }


    public class DataModel
    {
        public float y { get; set; }

        public DateTime x { get; set; }
    }
}

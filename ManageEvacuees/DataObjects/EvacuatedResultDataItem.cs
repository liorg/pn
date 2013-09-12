using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManageEvacuateds.DataObjects
{
    public class EvacuatedResultDataItem
    {
    //    public EvacuatedDetails evacuatedDetails { get; set; }
    //    public EquipmentResult equipmentResult { get; set; }
    //}
    
    //public class EvacuatedDetails
    //{ 
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string LocalArea { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string CurrentInSite { get; set; }
    //}

    //public class EquipmentResult
    //{
        public string EqLocalArea { get; set; }
        public string EquipName { get; set; }
        public string EqAddress { get; set; }
        public string EqTelephone { get; set; } 
    }
}
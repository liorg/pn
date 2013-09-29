using ManageEvacuees.NSMefonimGovService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManageEvacuees.Moduls
{
    public class ManageEquipment
    {
        public static Mitkanim[] GetEquipment()
        {
            MefonimGovServiceClient client = new MefonimGovServiceClient("MefonimGovServiceEndpoint");
            var response = client.GetMitkanim();

            if (!response.IsError)
            {
                return response.Mitkanim;
            }
            else
            {
                return null;
            }
        }
    }
}
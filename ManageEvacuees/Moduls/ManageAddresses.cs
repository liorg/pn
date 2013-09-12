﻿//using ManageEvacuees.MefunimGovService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ManageEvacuees.NSMefonimGovService;

namespace ManageEvacuees.Moduls
{
    public static class ManageAddresses
    {
        //public static Rashuyot[] GetAreas()
        //{
        //    MefonimGovServiceClient client = new MefonimGovServiceClient("MefonimGovServiceEndpoint");
        //    var response = client.GetRashuyot();
        //    Rashuyot r = new Rashuyot();

        //    if (!response.IsError)
        //    {
        //        return response.Rashuyot;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        public static object GetAreas()
        {
            MefonimGovServiceClient client = new MefonimGovServiceClient("MefonimGovServiceEndpoint");
            return client.Ping("sara!!!");
          
            
        }

        public static Yeshuvim[] GetCities()
        {
            MefonimGovServiceClient client = new MefonimGovServiceClient("MefonimGovServiceEndpoint");
            var response = client.GetYeshuvim();
            if (!response.IsError)
            {
                return response.Yeshuvim;
            }
            else
            {
                return null;
            }
        }

        public static Address[] GetAddresses()
        {
            MefonimGovServiceClient client = new MefonimGovServiceClient("MefonimGovServiceEndpoint");
            var response = client.GetAddress();
            if (!response.IsError)
            {
                return response.Address;
            }
            else
            {
                return null;
            }
        }

    }
}
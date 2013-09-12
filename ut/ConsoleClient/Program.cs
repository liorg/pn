using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleClient.t;
//using ConsoleClient.Test2;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // MefonimGovServiceClient client=new MefonimGovServiceClient("test");

            MefonimGovServiceClient client = new MefonimGovServiceClient("test");

            Console.WriteLine(client.Ping("test"));
            ConsoleClient.t.LoginRequest loginRequest = new LoginRequest { UserName = "lior", Password = "123" };


            //
            var isvalid = client.Login(loginRequest);
             var okLogIn=isvalid.IsValid == true;


            client.GetRashuyot();

            client.GetMitkanim();

            client.GetYeshuvim();

            client.GetAgesType();

            SearchRequest req = new SearchRequest();
            req.SortingName = SortingField.MfFirstName;
            req.SortingOrder = SortingOrder.ASC;
            req.CurrentPage = 1;
            req.MaxRowsPerPage = 3;

            req.MfFather = " אילן";
            var res = client.Search(req);

            client.SearchMitkanim(new SearchMitkanimRequest ());

           
                var adr = client.GetAddress();
            if (adr.IsError)
            {
                return;
            }

            foreach (var item in adr.Address)
            {

                Console.WriteLine(item.StName);
            }
            Console.ReadKey();




        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;
using System.Text;

namespace Guardian.Moin.EvacueeModule.DataContract
{
    public enum SortingField
    {
        MfLastName = 0, MfFirstName, ReshutAddress,
        ShiltonMekomiAddress, MfFather, MfGender, MfAge, IsMfDateOutcome, RashutName, MitkanName, MitkanAddress, MitkanPhone
    };
   
}

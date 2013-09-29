using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManageEvacuees
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (/*Not logged in user*/ 1 != 1)
            {
                LeftNavigationAreaCell.Visible = false;
            }
        }
    }
}

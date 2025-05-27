using PSDLab_Project.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDLab_Project.Views
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadJewels();
            }
        }

        private void LoadJewels()
        {
            // Get the list of jewels from the handler
            var jewels = JewelHandler.GetAllJewels();

            // Bind the list to our Repeater control
            RepeaterJewels.DataSource = jewels;
            RepeaterJewels.DataBind();
        }
    }
}
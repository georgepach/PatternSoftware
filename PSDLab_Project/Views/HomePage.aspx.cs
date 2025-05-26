using PSDLab_Project.Models;
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
        protected bool IsCustomer => Session["user"] is User u && u.Role == "Customer";
        protected bool IsAdmin => Session["user"] is User u && u.Role == "Admin";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadJewels();
            }
        }

        private void LoadJewels()
        {
            using (JawelsDBEntities1 db = new JawelsDBEntities1())
            {
                var jewelList = db.Jewels
                    .Select(j => new
                    {
                        j.JewelID,
                        j.JewelName,
                        j.Price,
                        Brand = j.Brand,
                        Category = j.Category
                    })
                    .ToList();

                rptJewels.DataSource = jewelList;
                rptJewels.DataBind();
            }
        }

        protected void rptJewels_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();

            switch (e.CommandName)
            {
                case "view":
                    Response.Redirect("JewelDetail.aspx?id=" + id);
                    break;

                case "add":
                    // TODO: Add to cart logic goes here
                    break;

                case "edit":
                    Response.Redirect("UpdateJewel.aspx?id=" + id);
                    break;

                case "delete":
                    DeleteJewel(Convert.ToInt32(id));
                    break;
            }
        }

        private void DeleteJewel(int id)
        {
            using (JawelsDBEntities1 db = new JawelsDBEntities1())
            {
                var jewel = db.Jewels.Find(id);
                if (jewel != null)
                {
                    db.Jewels.Remove(jewel);
                    db.SaveChanges();
                    LoadJewels();
                }
            }
        }
    }
}
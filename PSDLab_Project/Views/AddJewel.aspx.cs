using PSDLab_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDLab_Project.Views
{
    public partial class AddJewel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var db = new JawelsDBEntities1())
                {
                    ddlBrand.DataSource = db.Brands.ToList();
                    ddlBrand.DataTextField = "BrandName";
                    ddlBrand.DataValueField = "BrandID";
                    ddlBrand.DataBind();

                    ddlCategory.DataSource = db.Categories.ToList();
                    ddlCategory.DataTextField = "CategoryName";
                    ddlCategory.DataValueField = "CategoryID";
                    ddlCategory.DataBind();
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                string.IsNullOrWhiteSpace(txtYear.Text))
            {
                lblError.Text = "All fields are required.";
                return;
            }

            decimal price;
            int year;
            if (!decimal.TryParse(txtPrice.Text, out price) || price <= 25)
            {
                lblError.Text = "Price must be a number above 25.";
                return;
            }
            if (!int.TryParse(txtYear.Text, out year) || year >= DateTime.Now.Year)
            {
                lblError.Text = "Year must be less than current year.";
                return;
            }

            using (var db = new JawelsDBEntities1())
            {
                Jewel j = new Jewel
                {
                    JewelName = txtName.Text,
                    BrandID = int.Parse(ddlBrand.SelectedValue),
                    CategoryID = int.Parse(ddlCategory.SelectedValue),
                    Price = price,
                    ReleaseYear = year
                };

                db.Jewels.Add(j);
                db.SaveChanges();
                Response.Redirect("HomePage.aspx");
            }
        }
    }
}
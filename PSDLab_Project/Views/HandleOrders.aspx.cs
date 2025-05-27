using PSDLab_Project.Models;
using PSDLab_Project.Handlers;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDLab_Project.Views
{
    public partial class HandleOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Ensure user is an Admin
            User user = Session["user"] as User;
            if (user == null || user.Role != "Admin")
            {
                Response.Redirect("~/Views/HomePage.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadOrders();
            }
        }

        private void LoadOrders()
        {
            gvOrders.DataSource = TransactionHandler.GetUnfinishedOrders();
            gvOrders.DataBind();
        }

        protected void gvOrders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Dapatkan data TransactionHeader untuk baris ini
                var order = e.Row.DataItem as TransactionHeader;
                if (order == null) return;

                // Temukan kontrol di dalam TemplateField
                Button btnConfirm = e.Row.FindControl("btnConfirmPayment") as Button;
                Button btnShip = e.Row.FindControl("btnShipPackage") as Button;
                Label lblWait = e.Row.FindControl("lblWaiting") as Label;

                // Tampilkan/sembunyikan tombol berdasarkan status [cite: 92]
                if (order.Status == "Payment Pending")
                {
                    if (btnConfirm != null) btnConfirm.Visible = true;
                }
                else if (order.Status == "Shipment Pending")
                {
                    if (btnShip != null) btnShip.Visible = true;
                }
                else if (order.Status == "Arrived")
                {
                    if (lblWait != null) lblWait.Visible = true;
                }
            }
        }

        protected void gvOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int transactionId = Convert.ToInt32(e.CommandArgument);
            bool success = false;
            string newStatus = "";

            if (e.CommandName == "ConfirmPayment")
            {
                newStatus = "Shipment Pending";
                success = TransactionHandler.UpdateStatus(transactionId, newStatus);
            }
            else if (e.CommandName == "ShipPackage")
            {
                newStatus = "Arrived";
                success = TransactionHandler.UpdateStatus(transactionId, newStatus);
            }

            if (success)
            {
                lblMessage.Text = $"Transaction {transactionId} status updated to {newStatus}.";
                lblError.Text = "";
                LoadOrders(); // Muat ulang data untuk menampilkan perubahan
            }
            else
            {
                lblError.Text = "Failed to update transaction status.";
                lblMessage.Text = "";
            }
        }
    }
}
using PSDLab_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDLab_Project.Repositories
{
    public class TransactionRepository
    {
        // Mendapatkan pesanan yang belum selesai (bukan 'Done' atau 'Rejected')
        public static List<TransactionHeader> GetUnfinishedOrders()
        {
            using (var db = new JawelsDBEntities1())
            {
                // Status yang dianggap belum selesai
                var unfinishedStatuses = new List<string> { "Payment Pending", "Shipment Pending", "Arrived" };

                // Ambil data yang statusnya ada di dalam list 'unfinishedStatuses'
                return db.TransactionHeaders
                         .Where(th => unfinishedStatuses.Contains(th.Status))
                         .OrderBy(th => th.TransactionDate) // Urutkan berdasarkan tanggal
                         .ToList();
            }
        }

        // Memperbarui status transaksi
        public static bool UpdateTransactionStatus(int transactionId, string newStatus)
        {
            using (var db = new JawelsDBEntities1())
            {
                var transaction = db.TransactionHeaders.Find(transactionId);
                if (transaction != null)
                {
                    transaction.Status = newStatus;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        // Nanti kita bisa tambahkan metode lain seperti GetTransactionsByUser, etc.
    }
}
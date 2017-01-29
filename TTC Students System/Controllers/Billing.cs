namespace GN.TTC.Students.Controllers
{
    class Billing
    {
        internal Main cMain;

        internal Views.Billing.Pay vPay;
        internal Views.Billing.TransactionHistory vPaymentAndHistory;

        internal Billing(Main cMain)
        {
            this.cMain = cMain;
        }

        internal void ShowPay()
        {
            vPay = new Views.Billing.Pay(this);
            vPay.MdiParent = this.cMain.vMain;
            vPay.Show();
        }

        internal void ShowTransactionHistory()
        {
            vPaymentAndHistory = new Views.Billing.TransactionHistory(this);
            vPaymentAndHistory.MdiParent = this.cMain.vMain;
            vPaymentAndHistory.Show();
        }

        internal void Close()
        {
            cMain.vHome.Show();
        }
    }
}

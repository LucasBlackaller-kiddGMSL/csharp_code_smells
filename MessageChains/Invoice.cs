namespace MessageChains
{
    public class Invoice
    {
        public const double ShippingCostOutsideEu = 10;
        private readonly IList<InvoiceItem> _invoiceItems = new List<InvoiceItem>();
        private readonly Customer _customer;
        private readonly Country country;

        public Invoice(Customer customer)
        {
            this._customer = customer;
            this.country = customer.Address.Country;
        }

        public void AddItem(InvoiceItem invoiceItem)
        {
            _invoiceItems.Add(invoiceItem);
        }

        public double TotalPrice
        {
            get
            {
                double invoiceTotal = 0;

                foreach (InvoiceItem invoiceItem in _invoiceItems)
                {
                    invoiceTotal += invoiceItem.Subtotal;
                }

                if (!_customer.Address.Country.IsInEurope)
                {
                    invoiceTotal += ShippingCostOutsideEu;
                }

                return invoiceTotal;
            }
        }
    }
}
namespace MessageChains
{
    public class InvoiceItem
    {
        private string _itemName;
        private readonly int _quantity;
        private readonly double _unitPrice;

        public InvoiceItem(String itemName, int quantity, double unitPrice)
        {
            this._itemName = itemName;
            this._quantity = quantity;
            this._unitPrice = unitPrice;
        }

        public double Subtotal => _unitPrice * _quantity;
    }
}
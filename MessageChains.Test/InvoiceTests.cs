namespace MessageChains.Test
{
    [TestFixture]
    public class InvoiceTests {
	
	    [Test]
	    public void ShippingShouldBeAddedIfAddressIsNotInEurope() {
            var country = new Country(false);
    		
		    Invoice invoice = new Invoice(country);
		    invoice.AddItem(new InvoiceItem("Product X", 1, 100));
    		
		    Assert.That(invoice .TotalPrice, Is.EqualTo(100 + Invoice.ShippingCostOutsideEu));
	    }

    }
}

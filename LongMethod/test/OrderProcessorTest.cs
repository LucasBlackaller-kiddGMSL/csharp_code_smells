namespace LongMethod
{
    [TestFixture]
    public class OrderProcessorTests
    {
        private OrderProcessor _processor;
        private StringWriter _consoleOutput;

        [SetUp]
        public void Setup()
        {
            _processor = new OrderProcessor();
            _consoleOutput = new StringWriter();
            Console.SetOut(_consoleOutput);
        }

        [TearDown]
        public void Teardown()
        {
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
        }

        [Test]
        public void NullOrder_ShouldPrintError()
        {
            _processor.ProcessOrder(null);

            string output = _consoleOutput.ToString();
            StringAssert.Contains("Order is null", output);
        }

        [Test]
        public void MissingCustomerName_ShouldPrintError()
        {
            var order = new Order { CustomerName = null, Items = new List<OrderItem>() };

            _processor.ProcessOrder(order);

            string output = _consoleOutput.ToString();
            StringAssert.Contains("Customer name is missing", output);
        }

        [Test]
        public void EmptyItems_ShouldPrintError()
        {
            var order = new Order { CustomerName = "Alice", Items = new List<OrderItem>() };

            _processor.ProcessOrder(order);

            string output = _consoleOutput.ToString();
            StringAssert.Contains("No items in order", output);
        }

        [Test]
        public void ValidOrder_ShouldPrintSummaryAndSendEmail()
        {
            var order = new Order
            {
                CustomerName = "Bob",
                Items = new List<OrderItem>
                {
                    new OrderItem { Name = "Widget", Quantity = 2, Price = 100m },
                    new OrderItem { Name = "Thing", Quantity = 1, Price = 50m }
                }
            };

            _processor.ProcessOrder(order);

            string output = _consoleOutput.ToString();

            StringAssert.Contains("----- ORDER SUMMARY -----", output);
            StringAssert.Contains("Customer: Bob", output);
            StringAssert.Contains("Sending confirmation email...", output);
            StringAssert.Contains("Email sent.", output);
        }

        [Test]
        public void AppliesDiscount_WhenTotalIsOver500()
        {
            var order = new Order
            {
                CustomerName = "Eve",
                Items = new List<OrderItem>
                {
                    new OrderItem { Name = "Gold Bar", Quantity = 1, Price = 600m }
                }
            };

            _processor.ProcessOrder(order);

            string output = _consoleOutput.ToString();

            // after discount: 600 - 10% = 540
            StringAssert.Contains("Total: £540.00", output); // assuming UK formatting
        }

        [Test]
        public void Shipping_Is10_WhenTotalIsUnder50()
        {
            var order = new Order
            {
                CustomerName = "Small",
                Items = new List<OrderItem>
                {
                    new OrderItem { Name = "Cheap", Quantity = 1, Price = 20m } // total = 20
                }
            };

            _processor.ProcessOrder(order);

            string output = _consoleOutput.ToString();

            // Shipping added = 10 → total = 30
            StringAssert.Contains("Shipping: £10.00", output);
            StringAssert.Contains("Total: £30.00", output);
        }

        [Test]
        public void Shipping_Is5_WhenTotalIsBetween50And200()
        {
            var order = new Order
            {
                CustomerName = "Medium",
                Items = new List<OrderItem>
                {
                    new OrderItem { Name = "Something", Quantity = 1, Price = 150m } // total = 150
                }
            };

            _processor.ProcessOrder(order);

            string output = _consoleOutput.ToString();

            // Shipping added = 5 → total = 155
            StringAssert.Contains("Shipping: £5.00", output);
            StringAssert.Contains("Total: £155.00", output);
        }

        [Test]
        public void Shipping_Is0_WhenTotalIsOver200()
        {
            var order = new Order
            {
                CustomerName = "Big",
                Items = new List<OrderItem>
                {
                    new OrderItem { Name = "Expensive", Quantity = 1, Price = 300m } // total = 300
                }
            };

            _processor.ProcessOrder(order);

            string output = _consoleOutput.ToString();

            // Discount applies: 5% off 300 = 285
            StringAssert.Contains("Shipping: £0.00", output);
            StringAssert.Contains("Total: £285.00", output);
        }
        
        [Test]
        public void Item_WithZeroOrNegativeQuantity_ShouldBeSkipped()
        {
            var order = new Order
            {
                CustomerName = "TestUser",
                Items = new List<OrderItem>
                {
                    new OrderItem { Name = "Widget", Quantity = 0, Price = 100m },   // invalid
                    new OrderItem { Name = "Gadget", Quantity = 2, Price = 50m }     // valid
                }
            };

            _processor.ProcessOrder(order);

            string output = _consoleOutput.ToString();

            // Check that the invalid item produced a warning
            StringAssert.Contains("Invalid quantity", output);

            // Check that the valid item is included in the summary
            StringAssert.Contains("Gadget x2 @ £50.00", output);

            // Check total includes only the valid item
            // total = 2*50 = 100; shipping = 5 (since 100 < 200); final total = 105
            StringAssert.Contains("Shipping: £5.00", output);
            StringAssert.Contains("Total: £105.00", output);
        }

        [Test]
        public void Item_WithNegativePrice_ShouldBeSkipped()
        {
            var order = new Order
            {
                CustomerName = "TestUser",
                Items = new List<OrderItem>
                {
                    new OrderItem { Name = "Widget", Quantity = 1, Price = -50m },  // invalid
                    new OrderItem { Name = "Gadget", Quantity = 2, Price = 50m }    // valid
                }
            };

            _processor.ProcessOrder(order);

            string output = _consoleOutput.ToString();

            // Check that the invalid item produced a warning
            StringAssert.Contains("Invalid price", output);

            // Check that the valid item is included in the summary
            StringAssert.Contains("Gadget x2 @ £50.00", output);

            // total = 100, shipping = 5; final total = 105
            StringAssert.Contains("Shipping: £5.00", output);
            StringAssert.Contains("Total: £105.00", output);
        }


    }
}
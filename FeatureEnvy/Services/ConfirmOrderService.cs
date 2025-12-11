using FeatureEnvy.Model;

namespace FeatureEnvy.Services;

public class OrderConfirmationService
{
    private readonly StockService _stockService;

    public OrderConfirmationService(StockService stockService)
    {
        _stockService = stockService;
    }

    public bool ConfirmOrder(Order order)
    {
        return order.ConfirmOrder(_stockService, _stockService._warehouse);
    }
}

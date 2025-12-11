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
        return OrderConfirm(order, _stockService);
    }

    private bool OrderConfirm(Order order, StockService stockService)
    {
        foreach (var item in order.Items)
        {
            if (!stockService.CheckStock(item.Product, item.Quantity))
            {
                order.Confirmed = false;
                return false;
            }
        }

        order.Confirmed = true;
        return true;
    }
}

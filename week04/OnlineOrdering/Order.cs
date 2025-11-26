
public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    private decimal GetShippingCost()
    {
        return _customer.IsInUSA() ? 5.00m : 35.00m;
    }

    public decimal CalculateTotalPrice()
    {
        decimal productsTotal = _products.Sum(p => p.GetTotalCost());
        return productsTotal + GetShippingCost();
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in _products)
        {
            label += product.GetPackingLabelInfo() + "\n";
        }
        return label.Trim();
    }

    public string GetShippingLabel()
    {
        return $"Shipping To:\n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}
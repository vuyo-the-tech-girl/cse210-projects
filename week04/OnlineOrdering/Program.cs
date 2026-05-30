using System;
using System.Collections.Generic;
using System.Text;

// Address class - now includes ZipCode
public class Address
{
    private string _street;
    private string _city;
    private string _stateProvince;
    private string _country;
    private string _zipCode;

    public Address(string street, string city, string stateProvince, string country, string zipCode)
    {
        _street = street;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
        _zipCode = zipCode;
    }

// Getters/Setters
    public string GetStreet() { return _street; }
    public void SetStreet(string street) { _street = street; }

    public string GetCity() { return _city; }
    public void SetCity(string city) { _city = city; }

    public string GetStateProvince() { return _stateProvince; }
    public void SetStateProvince(string state) { _stateProvince = state; }

    public string GetCountry() { return _country; }
    public void SetCountry(string country) { _country = country; }

    public string GetZipCode() { return _zipCode; }
    public void SetZipCode(string zipCode) { _zipCode = zipCode; }

// Method: check if USA
    public bool IsInUSA()
    {
        return _country.Trim().ToUpper() == "USA" || _country.Trim().ToUpper() == "UNITED STATES";
    }

// Method: return full address string with zip code
    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_stateProvince} {_zipCode}\n{_country}";
    }
}

// Customer class
public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string GetName() { return _name; }
    public void SetName(string name) { _name = name; }

    public Address GetAddress() { return _address; }
    public void SetAddress(Address address) { _address = address; }

// Method: delegates to Address
    public bool LivesInUSA()
    {
        return _address.IsInUSA();
    }
}

// Product class
public class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public string GetName() { return _name; }
    public void SetName(string name) { _name = name; }

    public string GetProductId() { return _productId; }
    public void SetProductId(string id) { _productId = id; }

    public double GetPrice() { return _price; }
    public void SetPrice(double price) { _price = price; }

    public int GetQuantity() { return _quantity; }
    public void SetQuantity(int qty) { _quantity = qty; }

// Method: total cost for this product
    public double GetTotalCost()
    {
        return _price * _quantity;
    }
}

// Order class
public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

// Method: calculate total cost + shipping
    public double GetTotalCost()
    {
        double productTotal = 0;
        foreach (Product p in _products)
        {
            productTotal += p.GetTotalCost();
        }

        double shipping = _customer.LivesInUSA() ? 5.0 : 35.0;
        return productTotal + shipping;
    }

// Method: packing label
    public string GetPackingLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Packing Label:");
        foreach (Product p in _products)
        {
            sb.AppendLine($"{p.GetName()} - ID: {p.GetProductId()}");
        }
        return sb.ToString();
    }

// Method: shipping label
    public string GetShippingLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Shipping Label:");
        sb.AppendLine(_customer.GetName());
        sb.AppendLine(_customer.GetAddress().GetFullAddress());
        return sb.ToString();
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        Address addr1 = new Address("123 Main St", "Provo", "UT", "USA", "84601");
        Customer cust1 = new Customer("Alice Johnson", addr1);
        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Laptop", "A101", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "B205", 25.50, 2));
        order1.AddProduct(new Product("Keyboard", "C310", 75.00, 1));

        Address addr2 = new Address("45 Queen St", "Toronto", "ON", "Canada", "M5H 2N2");
        Customer cust2 = new Customer("Bob Smith", addr2);
        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Book", "D001", 15.99, 3));
        order2.AddProduct(new Product("Notebook", "E402", 4.50, 5));

        List<Order> orders = new List<Order> { order1, order2 };

// Display results
        foreach (Order order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order.GetTotalCost():F2}");
            Console.WriteLine("----------------------------------------\n");
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
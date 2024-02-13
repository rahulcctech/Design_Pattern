using System;
using System.Collections.Generic;

// Element interface
interface IProduct
{
    void Accept(IVisitor visitor);
    double GetPrice(); // Added method to retrieve price
}

// Concrete element
class Electronics : IProduct
{
    public double Price { get; set; }

    public Electronics(double price)
    {
        Price = price;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    public double GetPrice() // Implementation of GetPrice for Electronics
    {
        return Price;
    }
}

// Concrete element
class Groceries : IProduct
{
    public double Price { get; set; }

    public Groceries(double price)
    {
        Price = price;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    public double GetPrice() // Implementation of GetPrice for Groceries
    {
        return Price;
    }
}

// Concrete element
class Clothes : IProduct
{
    public double Price { get; set; }

    public Clothes(double price)
    {
        Price = price;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    public double GetPrice() // Implementation of GetPrice for Clothes
    {
        return Price;
    }
}

// Visitor interface
interface IVisitor
{
    void Visit(Electronics electronics);
    void Visit(Groceries groceries);
    void Visit(Clothes clothes);
}

// Concrete visitor
class Vendor : IVisitor
{
    public void Visit(Electronics electronics)
    {
        electronics.Price *= 0.9; // Apply a 10% discount to electronics
        Console.WriteLine("Applied 10% discount to electronics.");
    }

    public void Visit(Groceries groceries)
    {
        groceries.Price *= 0.95; // Apply a 5% discount to groceries
        Console.WriteLine("Applied 5% discount to groceries.");
    }

    public void Visit(Clothes clothes)
    {
        clothes.Price *= 0.8; // Apply a 20% discount to clothes
        Console.WriteLine("Applied 20% discount to clothes.");
    }
}

class Shop
{
    private List<IProduct> products = new List<IProduct>();

    public void Attach(IProduct product)
    {
        products.Add(product);
    }

    public void Detach(IProduct product)
    {
        products.Remove(product);
    }

    public void Accept(IVisitor visitor)
    {
        foreach (var product in products)
        {
            product.Accept(visitor);
        }
    }

    public IReadOnlyList<IProduct> GetProducts()
    {
        return products.AsReadOnly();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var shop = new Shop();
        shop.Attach(new Electronics(100));
        shop.Attach(new Groceries(50));
        shop.Attach(new Clothes(80));

        var vendor = new Vendor();
        shop.Accept(vendor);

        // Output the final prices after discounts
        Console.WriteLine("Final prices after discounts:");
        foreach (var product in shop.GetProducts())
        {
            Console.WriteLine($"Price: {product.GetPrice():C}");
        }
    }
}

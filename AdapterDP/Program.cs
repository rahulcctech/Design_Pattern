using System;

public class Shop
{
    public double MakePayment(string paymentMethod)
    {
        double payment = 0.0;

        switch (paymentMethod.ToLower())
        {
            case "gpay":
                Console.WriteLine("Payment done with Gpay");
                payment = 30.0;
                break;

            case "phonepay":
                Console.WriteLine("Payment done with Phonepay");
                payment = 30.0;
                break;

            case "paytm":
                Console.WriteLine("Payment done with Paytm");
                payment = 30.0;
                break;

            default:
                Console.WriteLine("Invalid UPI method");
                break;
        }

        return payment;
    }
}

public interface Bank
{
    void Payment(string paymentMethod);
}

public class ShopAdapter : Bank
{
    private readonly Shop _shop;

    public ShopAdapter(Shop shop)
    {
        _shop = shop;
    }

    public void Payment(string paymentMethod)
    {
        double payment = _shop.MakePayment(paymentMethod);
        Console.WriteLine($"Total payment is: {payment}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Shop shop = new Shop();
        Bank paymentAdapter = new ShopAdapter(shop);

        Console.Write("Enter payment method (gpay, phonepay, paytm): ");
        string paymentMethod = Console.ReadLine();

        MakePaymentWith(paymentAdapter, paymentMethod);

        Console.ReadLine();
    }

    static void MakePaymentWith(Bank paymentAdapter, string paymentMethod)
    {
        Console.WriteLine($"Making payment with {paymentMethod}:");
        paymentAdapter.Payment(paymentMethod);
        Console.WriteLine();
    }
}

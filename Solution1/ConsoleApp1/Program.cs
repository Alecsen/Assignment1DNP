// See https://aka.ms/new-console-template for more information

using ConsoleApp1;

public class Program
{
    public static void Main(string[] args)
    {
        ShowPricesWithVat();
    }

    private static void ShowPricesWithVat()
    {
        Console.WriteLine("Product prices incl. VAT:");

        foreach (var product in Products)
        {
            var vat = Utils.CalculateVat(product.Price, product.Category);
            var priceWithVat = Math.Round(product.Price + vat, 2);
            Console.WriteLine($"{product.Name}: {priceWithVat} EUR");
        }
    }

    private static readonly IEnumerable<Product> Products = new List<Product>
    {
        new Product("Batteries", Category.Electronics, 2.50),
        new Product("SD Card", Category.Electronics, 10),
        new Product("T-shirt", Category.Electronics, 15),
        new Product("Parmesan Cheese", Category.Grocery, 7.50),
        new Product("Tomatoes", Category.Grocery, 2),
    };
}
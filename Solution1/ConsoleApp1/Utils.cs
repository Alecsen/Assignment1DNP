namespace ConsoleApp1;

public class Utils
{
    private const double VatGrocery = 0.07;
    private const double VatNormal = 0.19;

    public static double CalculateVat(double price, Category category)
    {
        double result;

        if (category == Category.Grocery)
            result = price * VatGrocery;
        else
            result = price * VatNormal;

        return result;
    }

    public static double CalculatePriceWithVat(double price, Category category)
    {
        var priceVat = price + CalculateVat(price, category);
        return priceVat;
    }
}
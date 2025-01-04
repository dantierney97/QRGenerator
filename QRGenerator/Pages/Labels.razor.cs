using Microsoft.AspNetCore.Components;

namespace QRGenerator.Pages;

public partial class Labels : ComponentBase
{
}

public class Product
{
    public Product(string productName, string labelBarcode, string productPrice)
    {
        this.productName = productName;
        this.productPrice = productPrice;
        this.labelBarcode = labelBarcode;
    }

    public string productName { get; }
    public string productTPN { get; }
    public string productEAN { get; }
    public string productPrice { get; }

    public string labelBarcode { get; }
}
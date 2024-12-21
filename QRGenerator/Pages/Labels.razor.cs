using Microsoft.AspNetCore.Components;

namespace QRGenerator.Pages;

public partial class Labels : ComponentBase
{
}

public class Product
{
    public Product(string productName, string productTpn, string productEan, string productPrice)
    {
        this.productName = productName;
        productTPN = productTpn;
        productEAN = productEan;
        this.productPrice = productPrice;
        this.labelBarcode = productTpn + "/" + productEan;
    }

    public string productName { get; }
    public string productTPN { get; }
    public string productEAN { get; }
    public string productPrice { get; }

    public string labelBarcode { get; }
}
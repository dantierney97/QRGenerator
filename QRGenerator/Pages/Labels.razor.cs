using Microsoft.AspNetCore.Components;

namespace QRGenerator.Pages;

public partial class Labels : ComponentBase
{
}

public class Product
{
    public string productName { get; set; }
    public string productTPN { get; set; }
    public string productEAN { get; set; }
    public string productPrice { get; set; }
}
namespace LAB08_JosueChoquepuma.DTOs;

public class OrderProductDetailDto
{
    public int OrderId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
}
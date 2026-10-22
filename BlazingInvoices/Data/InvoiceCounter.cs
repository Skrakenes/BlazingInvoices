namespace BlazingInvoices.Data;

public class InvoiceCounter
{
    public string UserId { get; set; }
    public int Year { get; set; }
    public int LastSequence { get; set; }
}
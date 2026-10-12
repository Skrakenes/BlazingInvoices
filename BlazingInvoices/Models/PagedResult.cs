namespace BlazingInvoices.Models;

public record PagedResult<TRecord>(IEnumerable<TRecord> Items, int Total)
{
    public static PagedResult<TRecord> Create(IEnumerable<TRecord> items, int total) => new(items, total);
}
namespace TravelInn.Data.Interface
{
    public interface ICariEk
    {
        string VoucherNo { get; set; }

        string Pax { get; set; }

        int? MusteriId { get; set; }

        int? TurId { get; set; }

        int? OtelId { get; set; }

        int? SatisSorumlusu_Id { get; set; }

        bool Confirmed { get; set; }

    }
}
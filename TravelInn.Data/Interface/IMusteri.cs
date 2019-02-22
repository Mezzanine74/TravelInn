namespace TravelInn.Data.Interface
{
    public interface IMusteri
    {
        string Musteri_AdiSoyadi { get; set; }
        int? Uyruk_Id { get; set; }
        string Telefon { get; set; }
        string Email { get; set; }
        string Adres { get; set; }
    }
}
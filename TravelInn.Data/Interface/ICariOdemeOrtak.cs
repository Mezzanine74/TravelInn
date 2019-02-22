using System;

namespace TravelInn.Data.Interface
{
    public interface ICariOdemeOrtak
    {
        DateTime? Tarih { get; set; }

        string Aciklama { get; set; }

        decimal? TL { get; set; }

        decimal? Euro { get; set; }

        decimal? Dollar { get; set; }

        int FirmaId { get; set; }

    }
}
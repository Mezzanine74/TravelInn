using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharedKernel.Data;
using System;
using System.Linq;
using TravelInn.Common;

namespace TravelInn.Data.Test
{
    [TestClass]
    public class PopulateDataTest
    {
        private TravelInnEntities db = new TravelInnEntities();

        [TestMethod]
        public void Populate()
        {
            // DELETE EXISTING DATA

            // Arrange
            var repoFirmaTemsilcisi = new GenericRepository<FirmaTemsilcisi, Log>(db);
            var repoFirma = new GenericRepository<Firma, Log>(db);
            var repoOdenen = new GenericRepository<Odeme, Log>(db);
            var repoOdenecek = new GenericRepository<Cari, Log>(db);
            var rnd = new System.Random();

            // Act
            var i = 0;
            var allFrmTmslc = repoFirmaTemsilcisi.All();
            foreach (var item in allFrmTmslc)
            {
                if (repoFirmaTemsilcisi.Remove(item.Id).Success)
                {
                    i++;
                };
            }

            // Assert
            Assert.AreEqual(allFrmTmslc.Count(), i);

            // Arrange
            i = 0;
            var allOdnck = repoOdenecek.All();

            // Act
            foreach (var item in allOdnck)
            {
                if (repoOdenecek.Remove(item.Id).Success)
                {
                    i++;
                };
            }

            // Assert
            Assert.AreEqual(allOdnck.Count(), i);

            // Arrange
            i = 0;
            var allOdnn = repoOdenen.All();

            // Act
            foreach (var item in allOdnn)
            {
                if (repoOdenen.Remove(item.Id).Success)
                {
                    i++;
                };
            }

            // Assert
            Assert.AreEqual(allOdnn.Count(), i);

            // Arrange
            i = 0;
            var allFirma = repoFirma.All();

            // Act
            foreach (var item in allFirma)
            {
                if (repoFirma.Remove(item.Id).Success)
                {
                    i++;
                };
            }

            // Assert
            Assert.AreEqual(allFirma.Count(), i);

            // POPULATE DATA

            // Arrange
            var frmSayi = 0;
            var frmTmsSayi = 0;
            var odenecekSayi = 0;
            var odenenSayi = 0;

            // Act
            for (int j = 0; j < 50; j++)
            {
                var frm = new Firma()
                {
                    Id = repoFirma.NextId(),
                    Ismi = RandomText.String(20),
                    Adresi = RandomText.String(50),
                };

                if (repoFirma.Add(frm).Success)
                {
                    frmSayi++;

                    // Firma Temsilcisi Ekle
                    for (int k = 0; k < rnd.Next(0, 4); k++)
                    {
                        if (repoFirmaTemsilcisi.Add(new FirmaTemsilcisi()
                        {
                            Id = repoFirmaTemsilcisi.NextId(),
                            AdiSoyadi = RandomText.String(20),
                            Telefon = RandomText.Telephone(),
                            Email = RandomText.Email(),
                            FirmaId = frm.Id
                        }).Success)
                        {
                            frmTmsSayi++;
                        };
                    }

                    // Odenecek Ekle
                    for (int k = 0; k < rnd.Next(0, 4); k++)
                    {
                        if (repoOdenecek.Add(new Cari()
                        {
                            Id = repoOdenecek.NextId(),
                            Aciklama = RandomText.String(30),
                            Dollar = rnd.Next(0, 4) > 2 ? RandomText.Fiyat() : 0,
                            Euro = rnd.Next(0, 4) > 2 ? RandomText.Fiyat() : 0,
                            TL = rnd.Next(0, 4) > 2 ? RandomText.Fiyat() : 0,
                            FirmaId = frm.Id,
                            Tarih = DateTime.Now
                        }).Success)
                        {
                            odenecekSayi++;
                        };
                    }

                    // Odenen Ekle
                    for (int k = 0; k < rnd.Next(0, 4); k++)
                    {
                        if (repoOdenen.Add(new Odeme()
                        {
                            Id = repoOdenen.NextId(),
                            Aciklama = RandomText.String(30),
                            Dollar = rnd.Next(0, 4) > 2 ? RandomText.Fiyat() : 0,
                            Euro = rnd.Next(0, 4) > 2 ? RandomText.Fiyat() : 0,
                            TL = rnd.Next(0, 4) > 2 ? RandomText.Fiyat() : 0,
                            FirmaId = frm.Id,
                            Tarih = DateTime.Now
                        }).Success)
                        {
                            odenenSayi++;
                        };

                    }
                };
            }

            // Assert
            Assert.AreEqual(50, frmSayi);
            Assert.IsTrue(frmTmsSayi > 0);
            Assert.IsTrue(odenenSayi > 0);
            Assert.IsTrue(odenecekSayi > 0);
        }
    }
}

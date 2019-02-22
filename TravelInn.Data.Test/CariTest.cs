using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharedKernel.Data;
using System;

namespace TravelInn.Data.Test
{
    [TestClass]
    public class CariTest
    {
        private TravelInnEntities db = new TravelInnEntities();

        /// <summary>
        /// NEXT
        /// </summary>
        [TestMethod]
        public void CariNextId()
        {
            // Arrange
            var repo = new GenericRepository<Cari, Log>(db);

            // Act
            var maxId = repo.MaxId();

            var nextId = repo.NextId();

            // Assert
            Assert.AreEqual(maxId + 1, nextId);

        }

        /// <summary>
        /// EKLEME
        /// </summary>
        [TestMethod]
        public void CariAddAndRemoveSucess()
        {
            // Arrange
            var repoCari = new GenericRepository<Cari, Log>(db);
            var repoFirma = new GenericRepository<Firma, Log>(db);
            var repoMusteri = new GenericRepository<Musteri, Log>(db);
            var repoTur = new GenericRepository<Tur, Log>(db);
            var repoOtel = new GenericRepository<Otel, Log>(db);

            var randomText = TravelInn.Common.RandomText.String(10);

            var firma = new Firma()
            {
                Id = repoFirma.NextId(),
                Ismi = randomText,
                Adresi = "Test"
            };

            var musteri = new Musteri()
            {
                Id = repoMusteri.NextId(),
                Musteri_AdiSoyadi = randomText
            };

            var tur = new Tur()
            {
                Id = repoTur.NextId(),
                Tur_Adi = randomText
            };

            var otel = new Otel()
            {
                Id = repoOtel.NextId(),
                Otel_Adi = randomText
            };

            var cari = new Cari()
            {
                Id = repoCari.NextId(),
                Aciklama = randomText,
                Dollar = 0,
                Euro = 0,
                TL = 1,
                Tarih = DateTime.Now,
                FirmaId = firma.Id,
                MusteriId = musteri.Id,
                TurId = tur.Id,
                OtelId = otel.Id
            };

            // Act
            repoFirma.Add(firma);
            repoMusteri.Add(musteri);
            repoTur.Add(tur);
            repoOtel.Add(otel);

            var act = repoCari.Add(cari);

            // Assert
            Assert.AreEqual(act.Success, true);

            act = repoCari.Remove(cari.Id);
            Assert.AreEqual(act.Success, true);

            act = repoFirma.Remove(firma.Id);
            Assert.AreEqual(act.Success, true);

            act = repoMusteri.Remove(musteri.Id);
            Assert.AreEqual(act.Success, true);

            act = repoTur.Remove(tur.Id);
            Assert.AreEqual(act.Success, true);

            act = repoOtel.Remove(otel.Id);
            Assert.AreEqual(act.Success, true);

        }

        [TestMethod]
        public void CariAddSayisalModelFail()
        {
            // Arrange
            var repoOdenecek = new GenericRepository<Cari, Log>(db);
            var repoFirma = new GenericRepository<Firma, Log>(db);
            var randomText = TravelInn.Common.RandomText.String(10);
            var firma = new Firma()
            {
                Id = repoFirma.NextId(),
                Ismi = randomText,
                Adresi = "Test"
            };

            var odenecek = new Cari()
            {
                Id = repoOdenecek.NextId(),
                Aciklama = randomText,
                Dollar = 0,
                Euro = 0,
                TL = 0,
                Tarih = DateTime.Now,
                FirmaId = firma.Id
            };


            // Act
            repoFirma.Add(firma);

            var act = repoOdenecek.Add(odenecek);

            // Assert
            Assert.AreEqual(act.Success, false);
            Assert.AreEqual(act.MessageList[0], "En az bir Euro, Dollar, TL degeri girilmeli");

            act = repoFirma.Remove(firma.Id);
            Assert.AreEqual(act.Success, true);

        }

        /// <summary>
        /// CIKARMA
        /// </summary>
        // add and remove aynisini yapiyor

        /// <summary>
        /// UPDATE
        /// </summary>
        [TestMethod]
        public void CariAddAndUpdateAndRemoveSucess()
        {
            // Arrange
            var repoOdenecek = new GenericRepository<Cari, Log>(db);
            var repoFirma = new GenericRepository<Firma, Log>(db);
            var randomText = TravelInn.Common.RandomText.String(10);
            var firma = new Firma()
            {
                Id = repoFirma.NextId(),
                Ismi = randomText,
                Adresi = "Test"
            };

            var odenecek = new Cari()
            {
                Id = repoOdenecek.NextId(),
                Aciklama = randomText,
                Dollar = 0,
                Euro = 0,
                TL = 1,
                Tarih = DateTime.Now,
                FirmaId = firma.Id
            };

            // Act
            repoFirma.Add(firma);

            var act = repoOdenecek.Add(odenecek);

            // Assert
            Assert.AreEqual(act.Success, true);

            // Arrange
            odenecek.Aciklama = "whatever";

            // Act
            act = repoOdenecek.Update(odenecek);

            // Assert
            Assert.AreEqual(true, act.Success);

            // Clean
            act = repoOdenecek.Remove(odenecek.Id);
            Assert.AreEqual(act.Success, true);

            act = repoFirma.Remove(firma.Id);
            Assert.AreEqual(act.Success, true);

        }

        /// <summary>
        /// VALIDATION
        /// </summary>
        [TestMethod]
        public void CariSayisalModelFail()
        {
            // Arrange
            var repo = new GenericRepository<Cari, Log>(db);
            var randomText = TravelInn.Common.RandomText.String(10);

            // Act
            var odenecek = new Cari()
            {
                Id = repo.NextId(),
                Aciklama = randomText,
                Dollar = 0,
                Euro = 0,
                TL = 0,
                Tarih = DateTime.Now,
                FirmaId = 0
            };

            // Assert
            Assert.AreEqual(false, odenecek.Validate().Success);
        }

        [TestMethod]
        public void CariSayisalMetadataFail()
        {
            // Arrange
            var repoOdenecek = new GenericRepository<Cari, Log>(db);
            var repoFirma = new GenericRepository<Firma, Log>(db);
            var randomText = TravelInn.Common.RandomText.String(10);
            var firma = new Firma()
            {
                Id = repoFirma.NextId(),
                Ismi = randomText,
                Adresi = "Test"
            };

            var Odenecek = new Cari()
            {
                Id = repoOdenecek.NextId(),
                Aciklama = randomText,
                Dollar = 0,
                Euro = 0,
                TL = 1,
                Tarih = DateTime.Now,
                FirmaId = firma.Id
            };

            // Act
            repoFirma.Add(firma);

            var act = repoOdenecek.Add(Odenecek);

            // Assert
            Assert.AreEqual(act.Success, true);

            // Arrange
            Odenecek.Aciklama = "whatever";

            // Act
            act = repoOdenecek.Update(Odenecek);

            // Assert
            Assert.AreEqual(true, act.Success);

            // Arrange
            Odenecek.Aciklama = "";

            // Act
            act = repoOdenecek.Update(Odenecek);

            // Assert
            Assert.AreEqual(false, act.Success);
            Assert.AreEqual("Update basarisiz", act.MessageList[0]);

            // Clean
            act = repoOdenecek.Remove(Odenecek.Id);
            Assert.AreEqual(act.Success, true);

            act = repoFirma.Remove(firma.Id);
            Assert.AreEqual(act.Success, true);
        }

        [TestMethod]
        public void CariSayisalModelDollarSuccess()
        {
            // Arrange
            var repo = new GenericRepository<Cari, Log>(db);
            var randomText = TravelInn.Common.RandomText.String(10);

            // Act
            var odenecek = new Cari()
            {
                Id = repo.NextId(),
                Aciklama = randomText,
                Dollar = 1,
                Euro = 0,
                TL = 0,
                Tarih = DateTime.Now,
                FirmaId = 0
            };

            // Assert
            Assert.AreEqual(true, odenecek.Validate().Success);
        }

        [TestMethod]
        public void CariSayisalModelEuroSuccess()
        {
            // Arrange
            var repo = new GenericRepository<Cari, Log>(db);
            var randomText = TravelInn.Common.RandomText.String(10);

            // Act
            var odenecek = new Cari()
            {
                Id = repo.NextId(),
                Aciklama = randomText,
                Dollar = 0,
                Euro = 1,
                TL = 0,
                Tarih = DateTime.Now,
                FirmaId = 0
            };

            // Assert
            Assert.AreEqual(true, odenecek.Validate().Success);

        }

        [TestMethod]
        public void CariSayisalModelTLSuccess()
        {
            // Arrange
            var repo = new GenericRepository<Cari, Log>(db);
            var randomText = TravelInn.Common.RandomText.String(10);

            // Act
            var odenecek = new Cari()
            {
                Id = repo.NextId(),
                Aciklama = randomText,
                Dollar = 0,
                Euro = 0,
                TL = 1,
                Tarih = DateTime.Now,
                FirmaId = 0
            };

            // Assert
            Assert.AreEqual(true, odenecek.Validate().Success);

        }

    }
}

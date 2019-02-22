using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharedKernel.Data;
using System;

namespace TravelInn.Data.Test
{
    [TestClass]
    public class OdemeTest
    {
        private TravelInnEntities db = new TravelInnEntities();

        /// <summary>
        /// NEXT
        /// </summary>
        [TestMethod]
        public void OdemeNextId()
        {
            // Arrange
            var repo = new GenericRepository<Odeme, Log>(db);

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
        public void OdemeAddAndRemoveSucess()
        {
            // Arrange
            var repoOdeme = new GenericRepository<Odeme, Log>(db);
            var repoFirma = new GenericRepository<Firma, Log>(db);
            var randomText = TravelInn.Common.RandomText.String(10);
            var firma = new Firma()
            {
                Id = repoFirma.NextId(),
                Ismi = randomText,
                Adresi = "Test"
            };

            var Odeme = new Odeme()
            {
                Id = repoOdeme.NextId(),
                Aciklama = randomText,
                Dollar = 0,
                Euro = 0,
                TL = 1,
                Tarih = DateTime.Now,
                FirmaId = firma.Id
            };

            // Act
            repoFirma.Add(firma);

            var act = repoOdeme.Add(Odeme);

            // Assert
            Assert.AreEqual(act.Success, true);

            act = repoOdeme.Remove(Odeme.Id);
            Assert.AreEqual(act.Success, true);

            act = repoFirma.Remove(firma.Id);
            Assert.AreEqual(act.Success, true);

        }

        [TestMethod]
        public void OdemeAddSayisalModelFail()
        {
            // Arrange
            var repoOdeme = new GenericRepository<Odeme, Log>(db);
            var repoFirma = new GenericRepository<Firma, Log>(db);
            var randomText = TravelInn.Common.RandomText.String(10);
            var firma = new Firma()
            {
                Id = repoFirma.NextId(),
                Ismi = randomText,
                Adresi = "Test"
            };

            var Odeme = new Odeme()
            {
                Id = repoOdeme.NextId(),
                Aciklama = randomText,
                Dollar = 0,
                Euro = 0,
                TL = 0,
                Tarih = DateTime.Now,
                FirmaId = firma.Id
            };


            // Act
            repoFirma.Add(firma);

            var act = repoOdeme.Add(Odeme);

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
        public void OdemeAddAndUpdateAndRemoveSucess()
        {
            // Arrange
            var repoOdeme = new GenericRepository<Odeme, Log>(db);
            var repoFirma = new GenericRepository<Firma, Log>(db);
            var randomText = TravelInn.Common.RandomText.String(10);
            var firma = new Firma()
            {
                Id = repoFirma.NextId(),
                Ismi = randomText,
                Adresi = "Test"
            };

            var Odeme = new Odeme()
            {
                Id = repoOdeme.NextId(),
                Aciklama = randomText,
                Dollar = 0,
                Euro = 0,
                TL = 1,
                Tarih = DateTime.Now,
                FirmaId = firma.Id
            };

            // Act
            repoFirma.Add(firma);

            var act = repoOdeme.Add(Odeme);

            // Assert
            Assert.AreEqual(act.Success, true);

            // Arrange
            Odeme.Aciklama = "whatever";

            // Act
            act = repoOdeme.Update(Odeme);

            // Assert
            Assert.AreEqual(true, act.Success);

            // Clean
            act = repoOdeme.Remove(Odeme.Id);
            Assert.AreEqual(act.Success, true);

            act = repoFirma.Remove(firma.Id);
            Assert.AreEqual(act.Success, true);

        }

        /// <summary>
        /// VALIDATION
        /// </summary>
        [TestMethod]
        public void OdemeSayisalModelFail()
        {
            // Arrange
            var repo = new GenericRepository<Odeme, Log>(db);
            var randomText = TravelInn.Common.RandomText.String(10);

            // Act
            var Odeme = new Odeme()
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
            Assert.AreEqual(false, Odeme.Validate().Success);
        }

        [TestMethod]
        public void OdemeSayisalMetadataFail()
        {
            // Arrange
            var repoOdeme = new GenericRepository<Odeme, Log>(db);
            var repoFirma = new GenericRepository<Firma, Log>(db);
            var randomText = TravelInn.Common.RandomText.String(10);
            var firma = new Firma()
            {
                Id = repoFirma.NextId(),
                Ismi = randomText,
                Adresi = "Test"
            };

            var Odeme = new Odeme()
            {
                Id = repoOdeme.NextId(),
                Aciklama = randomText,
                Dollar = 0,
                Euro = 0,
                TL = 1,
                Tarih = DateTime.Now,
                FirmaId = firma.Id
            };

            // Act
            repoFirma.Add(firma);

            var act = repoOdeme.Add(Odeme);

            // Assert
            Assert.AreEqual(act.Success, true);

            // Arrange
            Odeme.Aciklama = "whatever";

            // Act
            act = repoOdeme.Update(Odeme);

            // Assert
            Assert.AreEqual(true, act.Success);

            // Arrange
            Odeme.Aciklama = "";

            // Act
            act = repoOdeme.Update(Odeme);

            // Assert
            Assert.AreEqual(false, act.Success);
            Assert.AreEqual("Update basarisiz", act.MessageList[0]);

            // Clean
            act = repoOdeme.Remove(Odeme.Id);
            Assert.AreEqual(act.Success, true);

            act = repoFirma.Remove(firma.Id);
            Assert.AreEqual(act.Success, true);
        }

        [TestMethod]
        public void OdemeSayisalModelDollarSuccess()
        {
            // Arrange
            var repo = new GenericRepository<Odeme, Log>(db);
            var randomText = TravelInn.Common.RandomText.String(10);

            // Act
            var Odeme = new Odeme()
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
            Assert.AreEqual(true, Odeme.Validate().Success);
        }

        [TestMethod]
        public void OdemeSayisalModelEuroSuccess()
        {
            // Arrange
            var repo = new GenericRepository<Odeme, Log>(db);
            var randomText = TravelInn.Common.RandomText.String(10);

            // Act
            var Odeme = new Odeme()
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
            Assert.AreEqual(true, Odeme.Validate().Success);

        }

        [TestMethod]
        public void OdemeSayisalModelTLSuccess()
        {
            // Arrange
            var repo = new GenericRepository<Odeme, Log>(db);
            var randomText = TravelInn.Common.RandomText.String(10);

            // Act
            var Odeme = new Odeme()
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
            Assert.AreEqual(true, Odeme.Validate().Success);

        }

    }
}

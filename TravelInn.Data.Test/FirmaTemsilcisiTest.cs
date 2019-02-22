using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharedKernel.Data;

namespace TravelInn.Data.Test
{
    [TestClass]
    public class FirmaTemsilcisiTest
    {
        private TravelInnEntities db = new TravelInnEntities();

        /// <summary>
        /// NEXT
        /// </summary>
        [TestMethod]
        public void OdenecekNextId()
        {
            // Arrange
            var repo = new GenericRepository<FirmaTemsilcisi, Log>(db);

            // Act
            var maxId = repo.MaxId();

            var nextId = repo.NextId();

            // Assert
            Assert.AreEqual(maxId + 1, nextId);
        }

        /// <summary>
        /// ADD REMOVE
        /// </summary>
        [TestMethod]
        public void FirmaTemsilcisiAddAndRemoveSucess()
        {
            // Arrange
            var repoFirmaTemsilcisi = new GenericRepository<FirmaTemsilcisi, Log>(db);
            var repoFirma = new GenericRepository<Firma, Log>(db);
            var randomText = TravelInn.Common.RandomText.String(10);
            var firma = new Firma()
            {
                Id = repoFirma.NextId(),
                Ismi = randomText,
                Adresi = "Test"
            };

            var frmTemsilcisi = new FirmaTemsilcisi()
            {
                Id = repoFirmaTemsilcisi.NextId(),
                AdiSoyadi = randomText,
                FirmaId = firma.Id
            };

            // Act
            repoFirma.Add(firma);

            var act = repoFirmaTemsilcisi.Add(frmTemsilcisi);

            // Assert
            Assert.AreEqual(act.Success, true);

            act = repoFirmaTemsilcisi.Remove(frmTemsilcisi.Id);
            Assert.AreEqual(act.Success, true);

            act = repoFirma.Remove(firma.Id);
            Assert.AreEqual(act.Success, true);

        }

        [TestMethod]
        public void FirmaTemsilcisiModelFail()
        {
            // Arrange
            var repoFirmaTemsilcisi = new GenericRepository<FirmaTemsilcisi, Log>(db);
            var repoFirma = new GenericRepository<Firma, Log>(db);
            var randomText = TravelInn.Common.RandomText.String(10);
            var firma = new Firma()
            {
                Id = repoFirma.NextId(),
                Ismi = randomText,
                Adresi = "Test"
            };

            var frmTemsilcisi = new FirmaTemsilcisi()
            {
                Id = repoFirmaTemsilcisi.NextId(),
                AdiSoyadi = "",
                FirmaId = firma.Id
            };

            // Act
            repoFirma.Add(firma);

            var act = repoFirmaTemsilcisi.Add(frmTemsilcisi);

            // Assert
            Assert.AreEqual(act.Success, false);

            // exception hata verdigi icin cikar, yoksa hata devam eder
            //db.FirmaTemsilcisis.Remove(frmTemsilcisi);

            act = repoFirma.Remove(firma.Id);
            Assert.AreEqual(act.Success, true);

        }

        /// <summary>
        /// UPDATE
        /// </summary>
        [TestMethod]
        public void FirmaTemsilcisiUpdateSuccess()
        {
            // Arrange
            var repo = new GenericRepository<Firma, Log>(db);
            var randomText = TravelInn.Common.RandomText.String(10);
            var firma = new Firma()
            {
                Id = repo.NextId(),
                Ismi = randomText,
                Adresi = "Test"
            };

            // Act
            var act = repo.Add(firma);

            // Assert
            Assert.AreEqual(act.Success, true);

            // Arrange
            var repoFirmaTemsilcisi = new GenericRepository<FirmaTemsilcisi, Log>(db);
            randomText = TravelInn.Common.RandomText.String(10);
            var firmaTemsilcisi = new FirmaTemsilcisi()
            {
                Id = repoFirmaTemsilcisi.NextId(),
                AdiSoyadi = randomText,
                FirmaId = firma.Id,
            };

            // Act
            act = repoFirmaTemsilcisi.Add(firmaTemsilcisi);

            // Assert
            Assert.AreEqual(act.Success, true);


            // Act update
            firmaTemsilcisi.AdiSoyadi = "Another Person";
            act = repoFirmaTemsilcisi.Update(firmaTemsilcisi);

            // Assert
            Assert.AreEqual(true, act.Success);

            // Remove
            act = repoFirmaTemsilcisi.Remove(firmaTemsilcisi.Id);
            Assert.AreEqual(true, act.Success);

            act = repo.Remove(firma.Id);
            Assert.AreEqual(true, act.Success);

        }

        /// <summary>
        /// VALIDATION
        /// </summary>
        [TestMethod]
        public void FirmaTemsilcisiValidation()
        {
            // Arrange
            var repo = new GenericRepository<Firma, Log>(db);
            var randomText = TravelInn.Common.RandomText.String(10);
            var firma = new Firma()
            {
                Id = repo.NextId(),
                Ismi = randomText,
                Adresi = "Test"
            };

            // Act
            var act = repo.Add(firma);

            // Assert
            Assert.AreEqual(act.Success, true);

            // Arrange
            var repoFirmaTemsilcisi = new GenericRepository<FirmaTemsilcisi, Log>(db);
            randomText = TravelInn.Common.RandomText.String(10);
            var firmaTemsilcisi = new FirmaTemsilcisi()
            {
                Id = repoFirmaTemsilcisi.NextId(),
                AdiSoyadi = randomText,
                FirmaId = firma.Id,
            };

            // Act
            act = repoFirmaTemsilcisi.Add(firmaTemsilcisi);

            // Assert
            Assert.AreEqual(act.Success, true);


            // Act update
            firmaTemsilcisi.AdiSoyadi = "";
            act = repoFirmaTemsilcisi.Update(firmaTemsilcisi);

            // Assert
            Assert.AreEqual(false, act.Success);

            // Remove
            act = repoFirmaTemsilcisi.Remove(firmaTemsilcisi.Id);
            Assert.AreEqual(true, act.Success);

            act = repo.Remove(firma.Id);
            Assert.AreEqual(true, act.Success);

        }




    }
}

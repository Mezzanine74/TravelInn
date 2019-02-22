using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharedKernel.Data;

namespace TravelInn.Data.Test
{
    [TestClass]
    public class FirmaTest
    {
        private TravelInnEntities db = new TravelInnEntities();

        /// <summary>
        /// NEXT
        /// </summary>
        [TestMethod]
        public void FirmaNextId()
        {
            // Arrange
            var repo = new GenericRepository<Firma, Log>(db);

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
        public void FirmaAddSuccess()
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

            act = repo.Remove(firma.Id);
            Assert.AreEqual(act.Success, true);

        }

        [TestMethod]
        public void FirmaAddFail()
        {
            // Arrange
            var repo = new GenericRepository<Firma, Log>(db);
            var randomText = TravelInn.Common.RandomText.String(10);
            var firma = new Firma()
            {
                Id = repo.NextId(),
                Ismi = "",
                Adresi = "Test"
            };

            // Act
            var act = repo.Add(firma);

            // Assert
            Assert.AreEqual(false, act.Success);
            Assert.AreEqual("Ekleme basarisiz", act.MessageList[0]);

        }

        /// <summary>
        /// CIKARMA
        /// </summary>
        [TestMethod]
        public void FirmaRemoveSuccess()
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
            repo.Add(firma);

            var act = repo.Remove(firma.Id);

            // Assert
            Assert.AreEqual(act.Success, true);

        }

        [TestMethod]
        public void FirmaRemoveFail()
        {
            // Arrange
            var repo = new GenericRepository<Firma, Log>(db);

            // Act

            var act = repo.Remove(-1);

            // Assert
            Assert.AreEqual(act.Success, false);
            Assert.AreEqual(act.MessageList[0], "Silme basarisiz");

        }

        /// <summary>
        /// UPDATE
        /// </summary>
        [TestMethod]
        public void FirmaUpdateSuccess()
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

            // Act update
            firma.Ismi = "Kapadokya";
            act = repo.Update(firma);

            // Assert
            Assert.AreEqual(true, act.Success);

            // Remove
            act = repo.Remove(firma.Id);
            Assert.AreEqual(act.Success, true);

        }

        [TestMethod]
        public void FirmaUpdateFail()
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

            // Act update
            firma.Ismi = "";
            act = repo.Update(firma);

            // Assert
            Assert.AreEqual(false, act.Success);
            Assert.AreEqual("Update basarisiz", act.MessageList[0]);

            // Remove
            act = repo.Remove(firma.Id);
            Assert.AreEqual(act.Success, true);

        }

        /// <summary>
        /// VALIDATION
        /// </summary>
        [TestMethod]
        public void FirmaIsmiPreventDoublication()
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
            repo.Add(firma);

            // Arrange
            var firma2 = new Firma()
            {
                Id = repo.NextId(),
                Ismi = randomText,
                Adresi = "Test 2"
            };

            // Act
            var act = repo.Add(firma2);

            // Assert
            Assert.AreEqual(act.Success, false);
            Assert.AreEqual("Ekleme basarisiz", act.MessageList[0]);

            repo.Remove(firma.Id);
            repo.Remove(firma2.Id);

        }
    }
}

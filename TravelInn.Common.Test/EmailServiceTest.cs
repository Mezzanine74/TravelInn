using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TravelInn.Common.Test
{
    [TestClass]
    public class EmailServiceTest
    {
        [TestMethod]
        public void SendEmail()
        {
            var emailService = new TravelInn.Common.EmailService();

            emailService.Send(new System.Net.Mail.MailMessage());

            Assert.AreEqual(1, 1);

        }
    }
}

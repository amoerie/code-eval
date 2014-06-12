using NUnit.Framework;

namespace CodeEval.Tests
{
    [TestFixture]
    public class TestsForDiscountOffers
    {
        [Test]
        public void Customer_CalculateSuitabilityScore_WhenCustomerIsJackAbrahamAndProductIsiPad2_4_pack_ShouldBe6()
        {
            var customer = new Customer("Jack Abraham");
            var product = new Product("iPad 2 - 4-pack");
            var suitabilityScore = new SuitabilityScore(customer, product).Score;
            const double expectedSuitabilityScore = 6d;
            Assert.That(suitabilityScore, Is.EqualTo(expectedSuitabilityScore));
        }

        [Test]
        public void Customer_CalculateSuitabilityScore_WhenCustomerIsJohnEvansAndProductIsGirlScoutThinMints_ShouldBe6()
        {
            var customer = new Customer("John Evans");
            var product = new Product("Girl Scouts Thin Mints");
            var suitabilityScore = new SuitabilityScore(customer, product).Score;
            const double expectedSuitabilityScore = 6d;
            Assert.That(suitabilityScore, Is.EqualTo(expectedSuitabilityScore));
        }

        [Test]
        public void Customer_CalculateSuitabilityScore_WhenCustomerIsTedDziubaAndProductIsNerfCrossbow_ShouldBe9()
        {
            var customer = new Customer("Ted Dziuba");
            var product = new Product("Nerf Crossbow");
            var suitabilityScore = new SuitabilityScore(customer, product).Score;
            const double expectedSuitabilityScore = 9d;
            Assert.That(suitabilityScore, Is.EqualTo(expectedSuitabilityScore));
        }

        [Test]
        public void DiscountOffer_CalculateMaximumTotalScore_Scenario1()
        {
            var customerNames = "Jack Abraham,John Evans,Ted Dziuba".Split(',');
            var productNames = "iPad 2 - 4-pack,Girl Scouts Thin Mints,Nerf Crossbow".Split(',');
            var discountOffer = new DiscountOffers(customerNames, productNames);
            var maximumTotalScore = discountOffer.CalculateMaximumTotalScore();
            Assert.That(maximumTotalScore, Is.EqualTo(21.0));
        }

        [Test]
        public void DiscountOffer_CalculateMaximumTotalScore_Scenario2()
        {
            var customerNames = "Jeffery Lebowski,Walter Sobchak,Theodore Donald Kerabatsos,Peter Gibbons,Michael Bolton,Samir Nagheenanajar".Split(',');
            var productNames = "Half & Half,Colt M1911A1,16lb bowling ball,Red Swingline Stapler,Printer paper,Vibe Magazine Subscriptions - 40 pack".Split(',');
            var discountOffer = new DiscountOffers(customerNames, productNames);
            var maximumTotalScore = discountOffer.CalculateMaximumTotalScore();
            Assert.That(maximumTotalScore, Is.EqualTo(83.50));
        }

        [Test]
        public void DiscountOffer_CalculateMaximumTotalScore_Scenario3()
        {
            var customerNames = "Jareau Wade,Rob Eroh,Mahmoud Abdelkader,Wenyi Cai,Justin Van Winkle,Gabriel Sinkin,Aaron Adelson".Split(',');
            var productNames = "Batman No. 1,Football - Official Size,Bass Amplifying Headphones,Elephant food - 1024 lbs,Three Wolf One Moon T-shirt,Dom Perignon 2000 Vintage".Split(',');
            var discountOffer = new DiscountOffers(customerNames, productNames);
            var maximumTotalScore = discountOffer.CalculateMaximumTotalScore();
            Assert.That(maximumTotalScore, Is.EqualTo(71.25));
        }

        [Test]
        public void DiscountOffer_CalculateMaximumTotalScore_Scenario4()
        {
            var customerNames = "Jeffery Lebowski,Walter Sobchak,Gabriel Sinkinovski,aaaaaccccccc,bbbbbbbbbb,yyyyybbbbbbbbb,odd man out bbbbb".Split(',');
            var productNames = "abcdefhijklemnoxx17,abcdefghijklmnopqrstuvwxyz26,Batman No. 1,Printer paper,Half & Half,Colt M1911A1b".Split(',');
            var discountOffer = new DiscountOffers(customerNames, productNames);
            var maximumTotalScore = discountOffer.CalculateMaximumTotalScore();
            Assert.That(maximumTotalScore, Is.EqualTo(76.75));
        }
    }
}

using System;
using NUnit.Framework;

namespace CodeEval.Tests
{
    [TestFixture]
    public class TestsForDiscountOffers
    {
        [Test]
        public void Customer_CalculateSuitabilityScore_WhenCustomerIsJackAbrahamAndProductIsiPad2_4_pack_ShouldBe6()
        {
            var customer = new DiscountOffers.Customer("Jack Abraham");
            var product = new DiscountOffers.Product("iPad 2 - 4-pack");
            var suitabilityScore = new DiscountOffers.SuitabilityScore(customer, product).Score;
            const double expectedSuitabilityScore = 6d;
            Assert.That(suitabilityScore, Is.EqualTo(expectedSuitabilityScore));
        }

        [Test]
        public void Customer_CalculateSuitabilityScore_WhenCustomerIsJohnEvansAndProductIsGirlScoutThinMints_ShouldBe6()
        {
            var customer = new DiscountOffers.Customer("John Evans");
            var product = new DiscountOffers.Product("Girl Scouts Thin Mints");
            var suitabilityScore = new DiscountOffers.SuitabilityScore(customer, product).Score;
            const double expectedSuitabilityScore = 6d;
            Assert.That(suitabilityScore, Is.EqualTo(expectedSuitabilityScore));
        }

        [Test]
        public void Customer_CalculateSuitabilityScore_WhenCustomerIsTedDziubaAndProductIsNerfCrossbow_ShouldBe9()
        {
            var customer = new DiscountOffers.Customer("Ted Dziuba");
            var product = new DiscountOffers.Product("Nerf Crossbow");
            var suitabilityScore = new DiscountOffers.SuitabilityScore(customer, product).Score;
            const double expectedSuitabilityScore = 9d;
            Assert.That(suitabilityScore, Is.EqualTo(expectedSuitabilityScore));
        }

        [Test, Timeout(10000)]
        public void DiscountOffer_CalculateMaximumTotalScore_Scenario1()
        {
            var customerNames = "Jack Abraham,John Evans,Ted Dziuba".Split(',');
            var productNames = "iPad 2 - 4-pack,Girl Scouts Thin Mints,Nerf Crossbow".Split(',');
            var discountOffer = new DiscountOffers(customerNames, productNames);
            var maximumTotalScore = discountOffer.CalculateMaximumTotalScore();
            Assert.That(maximumTotalScore, Is.EqualTo(21.0));
        }

        [Test, Timeout(10000)]
        public void DiscountOffer_CalculateMaximumTotalScore_Scenario2()
        {
            var customerNames = "Jeffery Lebowski,Walter Sobchak,Theodore Donald Kerabatsos,Peter Gibbons,Michael Bolton,Samir Nagheenanajar".Split(',');
            var productNames = "Half & Half,Colt M1911A1,16lb bowling ball,Red Swingline Stapler,Printer paper,Vibe Magazine Subscriptions - 40 pack".Split(',');
            var discountOffer = new DiscountOffers(customerNames, productNames);
            var maximumTotalScore = discountOffer.CalculateMaximumTotalScore();
            Assert.That(maximumTotalScore, Is.EqualTo(83.50));
        }

        [Test, Timeout(10000)]
        public void DiscountOffer_CalculateMaximumTotalScore_Scenario3()
        {
            var customerNames = "Jareau Wade,Rob Eroh,Mahmoud Abdelkader,Wenyi Cai,Justin Van Winkle,Gabriel Sinkin,Aaron Adelson".Split(',');
            var productNames = "Batman No. 1,Football - Official Size,Bass Amplifying Headphones,Elephant food - 1024 lbs,Three Wolf One Moon T-shirt,Dom Perignon 2000 Vintage".Split(',');
            var discountOffer = new DiscountOffers(customerNames, productNames);
            var maximumTotalScore = discountOffer.CalculateMaximumTotalScore();
            Assert.That(maximumTotalScore, Is.EqualTo(71.25));
        }

        [Test, Timeout(10000)]
        public void DiscountOffer_CalculateMaximumTotalScore_Scenario4()
        {
            var customerNames = "Jeffery Lebowski,Walter Sobchak,Gabriel Sinkinovski,aaaaaccccccc,bbbbbbbbbb,yyyyybbbbbbbbb,odd man out bbbbb".Split(',');
            var productNames = "abcdefhijklemnoxx17,abcdefghijklmnopqrstuvwxyz26,Batman No. 1,Printer paper,Half & Half,Colt M1911A1b".Split(',');
            var discountOffer = new DiscountOffers(customerNames, productNames);
            var maximumTotalScore = discountOffer.CalculateMaximumTotalScore();
            Assert.That(maximumTotalScore, Is.EqualTo(76.75));
        }

        [Test]
        public void DiscountOffer_CalculateMaximumScore_Scenario5()
        {
            var customerNames = "John Evans,Samir Nagheenanajar,Jeffery Lebowski,Michael Bolton,Theodore Donald Kerabatsos,Gabriel Sinkin,Rob Eroh,Jack Abraham,Peter Gibbons,Justin Van Winkle".Split(',');
            var productNames = "Vibe Magazine Subscriptions - 40 pack,Widescreen Monitor - 30-inch,Football - Official Size,Colt M1911A1,Three Wolf One Moon T-shirt,Red Swingline Stapler,Half & Half".Split(',');
            var discountOffer = new DiscountOffers(customerNames, productNames);
            var maximumTotalScore = discountOffer.CalculateMaximumTotalScore();
            Assert.That(maximumTotalScore, Is.EqualTo(94.0d));
        }

        [Test]
        public void DiscountOffer_CalculateMaximumScore_Scenario6()
        {
            var customerNames = "Justin Van Winkle,Wenyi Cai,Michael Bolton,Theodore Donald Kerabatsos,Mahmoud Abdelkader,Jeffery Lebowski,John Evans,Aaron Adelson,Ted Dziuba,Samir Nagheenanajar,Jareau Wade,Walter Sobchak,Rob Eroh,Gabriel Sinkin".Split(',');
            var productNames = "Dom Perignon 2000 Vintage,Nerf Crossbow,Widescreen Monitor - 30-inch,iPad 2 - 4-pack,16lb Bowling ball,Printer paper,Football - Official Size,Elephant food - 1024 lbs,Vibe Magazine Subscriptions - 40 pack,Colt M1911A1".Split(',');
            var discountOffer = new DiscountOffers(customerNames, productNames);
            var maximumTotalScore = discountOffer.CalculateMaximumTotalScore();
            Assert.That(maximumTotalScore, Is.EqualTo(139.75d));
        }

        [Test]
        public void DiscountOffer_CalculateMaximumScore_Scenario7()
        {
            var customerNames = "Aaron Adelson,Jeffery Lebowski,Samir Nagheenanajar,Michael Bolton,Justin Van Winkle,Jack Abraham,Mahmoud Abdelkader,Jareau Wade,Rob Eroh,Gabriel Sinkin,Walter Sobchak,John Evans".Split(',');
            var productNames = "Dom Perignon 2000 Vintage,Girl Scouts Thin Mints,Printer paper,Three Wolf One Moon T-shirt,Widescreen Monitor - 30-inch,Batman No. 1,Vibe Magazine Subscriptions - 40 pack,iPad 2 - 4-pack,Red Swingline Stapler,16lb Bowling ball,Elephant food - 1024 lbs,Colt M1911A1,Football - Official Size,Bass Amplifying Headphones,Nerf Crossbow".Split(',');
            var discountOffer = new DiscountOffers(customerNames, productNames);
            var maximumTotalScore = discountOffer.CalculateMaximumTotalScore();
            Assert.That(maximumTotalScore, Is.EqualTo(139.75d));
        }

        [Test, Timeout(10000)]
        public void DiscountOffer_CalculateMaximumTotalScore_ShouldHandle20ScenariosUnder10Seconds()
        {
            var scenarios = new[]
            {
                "Jeffery Lebowski,John Evans,Mahmoud Abdelkader,Samir Nagheenanajar,Jack Abraham,Ted Dziuba,Justin Van Winkle,Rob Eroh,Theodore Donald Kerabatsos;Three Wolf One Moon T-shirt,Red Swingline Stapler,Elephant food - 1024 lbs,Nerf Crossbow,Dom Perignon 2000 Vintage,Bass Amplifying Headphones,16lb Bowling ball,Girl Scouts Thin Mints,Colt M1911A1,Printer paper,iPad 2 - 4-pack",
                "Jeffery Lebowski,Samir Nagheenanajar,Justin Van Winkle,Walter Sobchak,Jareau Wade,Gabriel Sinkin,Theodore Donald Kerabatsos,Rob Eroh,Mahmoud Abdelkader;16lb Bowling ball,iPad 2 - 4-pack,Widescreen Monitor - 30-inch,Girl Scouts Thin Mints,Elephant food - 1024 lbs,Football - Official Size,Red Swingline Stapler,Batman No. 1,Half & Half,Dom Perignon 2000 Vintage,Vibe Magazine Subscriptions - 40 pack,Colt M1911A1,Printer paper",
                "Gabriel Sinkin,John Evans,Michael Bolton,Theodore Donald Kerabatsos;16lb Bowling ball,Half & Half,Red Swingline Stapler,Three Wolf One Moon T-shirt,Printer paper,iPad 2 - 4-pack,Colt M1911A1,Nerf Crossbow,Batman No. 1",
                "Michael Bolton,Jack Abraham,Theodore Donald Kerabatsos;Colt M1911A1,Three Wolf One Moon T-shirt,16lb Bowling ball,Girl Scouts Thin Mints,Football - Official Size,Widescreen Monitor - 30-inch,Dom Perignon 2000 Vintage,Batman No. 1,iPad 2 - 4-pack,Elephant food - 1024 lbs,Vibe Magazine Subscriptions - 40 pack,Bass Amplifying Headphones,Half & Half",
                "Jack Abraham,Jareau Wade,Wenyi Cai,Jeffery Lebowski,Michael Bolton,Mahmoud Abdelkader,Samir Nagheenanajar,Peter Gibbons,Theodore Donald Kerabatsos,John Evans,Justin Van Winkle,Ted Dziuba,Aaron Adelson,Walter Sobchak,Rob Eroh,Gabriel Sinkin;Half & Half,Bass Amplifying Headphones,Football - Official Size,iPad 2 - 4-pack,Dom Perignon 2000 Vintage,Girl Scouts Thin Mints",
                "Jack Abraham,Samir Nagheenanajar,Theodore Donald Kerabatsos,Jeffery Lebowski,Wenyi Cai,Peter Gibbons,Ted Dziuba;",
                "Justin Van Winkle;Three Wolf One Moon T-shirt,Half & Half,iPad 2 - 4-pack,16lb Bowling ball,Elephant food - 1024 lbs,Red Swingline Stapler",
                "Jareau Wade,Jack Abraham,Justin Van Winkle,Peter Gibbons,Samir Nagheenanajar,Jeffery Lebowski,Mahmoud Abdelkader,Aaron Adelson,John Evans,Ted Dziuba,Walter Sobchak,Michael Bolton,Gabriel Sinkin,Theodore Donald Kerabatsos,Rob Eroh;Elephant food - 1024 lbs",
                "Aaron Adelson,Jeffery Lebowski,Samir Nagheenanajar,Michael Bolton,Justin Van Winkle,Jack Abraham,Mahmoud Abdelkader,Jareau Wade,Rob Eroh,Gabriel Sinkin,Walter Sobchak,John Evans;Dom Perignon 2000 Vintage,Girl Scouts Thin Mints,Printer paper,Three Wolf One Moon T-shirt,Widescreen Monitor - 30-inch,Batman No. 1,Vibe Magazine Subscriptions - 40 pack,iPad 2 - 4-pack,Red Swingline Stapler,16lb Bowling ball,Elephant food - 1024 lbs,Colt M1911A1,Football - Official Size,Bass Amplifying Headphones,Nerf Crossbow",
                "John Evans,Samir Nagheenanajar,Jeffery Lebowski,Michael Bolton,Theodore Donald Kerabatsos,Gabriel Sinkin,Rob Eroh,Jack Abraham,Peter Gibbons,Justin Van Winkle;Vibe Magazine Subscriptions - 40 pack,Widescreen Monitor - 30-inch,Football - Official Size,Colt M1911A1,Three Wolf One Moon T-shirt,Red Swingline Stapler,Half & Half",
                "Justin Van Winkle,Wenyi Cai,Michael Bolton,Theodore Donald Kerabatsos,Mahmoud Abdelkader,Jeffery Lebowski,John Evans,Aaron Adelson,Ted Dziuba,Samir Nagheenanajar,Jareau Wade,Walter Sobchak,Rob Eroh,Gabriel Sinkin;Dom Perignon 2000 Vintage,Nerf Crossbow,Widescreen Monitor - 30-inch,iPad 2 - 4-pack,16lb Bowling ball,Printer paper,Football - Official Size,Elephant food - 1024 lbs,Vibe Magazine Subscriptions - 40 pack,Colt M1911A1",
                "Jack Abraham,Michael Bolton,Justin Van Winkle,Jeffery Lebowski,Samir Nagheenanajar,Wenyi Cai,Walter Sobchak,Ted Dziuba,Theodore Donald Kerabatsos,Mahmoud Abdelkader,Jareau Wade,Rob Eroh,John Evans,Aaron Adelson,Gabriel Sinkin;Football - Official Size,Vibe Magazine Subscriptions - 40 pack,Half & Half",
                "Gabriel Sinkin,Wenyi Cai,Jack Abraham,Samir Nagheenanajar,John Evans,Rob Eroh;Elephant food - 1024 lbs,Half & Half,16lb Bowling ball,Football - Official Size,Girl Scouts Thin Mints,Vibe Magazine Subscriptions - 40 pack,Red Swingline Stapler,Batman No. 1,iPad 2 - 4-pack,Bass Amplifying Headphones,Dom Perignon 2000 Vintage,Nerf Crossbow,Printer paper",
                "Jareau Wade,Walter Sobchak,John Evans,Mahmoud Abdelkader,Wenyi Cai,Samir Nagheenanajar,Jack Abraham;Girl Scouts Thin Mints,Red Swingline Stapler,Three Wolf One Moon T-shirt,Half & Half,Widescreen Monitor - 30-inch,Bass Amplifying Headphones,Batman No. 1,Nerf Crossbow,Colt M1911A1,iPad 2 - 4-pack",
                "Justin Van Winkle,Peter Gibbons,Walter Sobchak,Samir Nagheenanajar,Rob Eroh,John Evans,Michael Bolton,Wenyi Cai,Jack Abraham,Jareau Wade,Ted Dziuba,Jeffery Lebowski,Gabriel Sinkin;Football - Official Size,Batman No. 1,Widescreen Monitor - 30-inch,Red Swingline Stapler,Girl Scouts Thin Mints,Half & Half,Colt M1911A1,16lb Bowling ball,Nerf Crossbow,Three Wolf One Moon T-shirt,Elephant food - 1024 lbs,Bass Amplifying Headphones,iPad 2 - 4-pack",
                "John Evans,Wenyi Cai,Gabriel Sinkin,Samir Nagheenanajar,Ted Dziuba,Justin Van Winkle,Jack Abraham;Printer paper,Dom Perignon 2000 Vintage,Bass Amplifying Headphones,Girl Scouts Thin Mints",
                "John Evans,Ted Dziuba,Gabriel Sinkin,Peter Gibbons,Michael Bolton,Jareau Wade,Aaron Adelson,Wenyi Cai,Jack Abraham,Samir Nagheenanajar,Theodore Donald Kerabatsos,Rob Eroh,Jeffery Lebowski;Printer paper,Widescreen Monitor - 30-inch,Three Wolf One Moon T-shirt,iPad 2 - 4-pack,Colt M1911A1,16lb Bowling ball,Football - Official Size,Dom Perignon 2000 Vintage,Vibe Magazine Subscriptions - 40 pack,Elephant food - 1024 lbs,Nerf Crossbow,Batman No. 1,Bass Amplifying Headphones,Red Swingline Stapler,Half & Half",
                "Aaron Adelson,Gabriel Sinkin,Samir Nagheenanajar,John Evans,Jareau Wade,Jeffery Lebowski,Jack Abraham,Mahmoud Abdelkader,Peter Gibbons,Justin Van Winkle,Wenyi Cai,Ted Dziuba,Rob Eroh,Michael Bolton,Theodore Donald Kerabatsos,Walter Sobchak;Girl Scouts Thin Mints,Red Swingline Stapler",
                "Mahmoud Abdelkader,Samir Nagheenanajar,Gabriel Sinkin,Theodore Donald Kerabatsos,Michael Bolton;",
                "Theodore Donald Kerabatsos,Walter Sobchak,Aaron Adelson,John Evans,Jack Abraham,Jareau Wade,Mahmoud Abdelkader,Michael Bolton;Girl Scouts Thin Mints,Half & Half,Batman No. 1,Widescreen Monitor - 30-inch,iPad 2 - 4-pack,Printer paper,Dom Perignon 2000 Vintage,Colt M1911A1,Elephant food - 1024 lbs,16lb Bowling ball,Nerf Crossbow,Bass Amplifying Headphones,Three Wolf One Moon T-shirt"
            };

            foreach (var scenario in scenarios)
            {
                var scenarioSplit = scenario.Split(';');
                var customerNames = scenarioSplit[0].Split(',');
                var productNames = scenarioSplit[1].Split(',');
                var discountOffer = new DiscountOffers(customerNames, productNames);
                Console.WriteLine(discountOffer.CalculateMaximumTotalScore());
            }
        }
    }
}

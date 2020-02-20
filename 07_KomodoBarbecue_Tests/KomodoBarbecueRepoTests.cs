using System;
using System.Collections.Generic;
using _07_KomodoBarbecue_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _07_KomodoBarbecue_Tests
{
    [TestClass]
    public class KomodoBarbecueRepoTests
    {
        private Barbecue_Repository _barbecueRepo = new Barbecue_Repository();

        [TestMethod]
        public void BarbecueRepo_AddToList_GetShouldReturnCorretCount()
        {
            //Arrange
            Barbecue barbecue = new Barbecue();
            Barbecue_Repository repo = new Barbecue_Repository();

            _barbecueRepo.AddBarbecueToList(barbecue);

            //Act
            List<Barbecue> actualList = _barbecueRepo.GetBarbecueList();

            int expected = 1;
            int actual = actualList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BarbecueRepo_RemoveFromList_GetShouldReturnCorrectCount()
        {
            SeedBarbecueList();
            int expected = 3;

            _barbecueRepo.RemoveBarbecueFromList("park");

            int barbecueCount = _barbecueRepo.GetBarbecueList().Count;

            Assert.AreEqual(expected, barbecueCount);
        }

        //Seed info for tests
        private void SeedBarbecueList()
        {
            DateTime dateOne = new DateTime(2020, 04, 11);
            Barbecue park = new Barbecue(dateOne, "park", 50, 20, 30, 100);

            DateTime dateTwo = new DateTime(2020, 05, 01);
            Barbecue conferenceRoom = new Barbecue(dateTwo, "Conference Room", 20, 10, 15, 50);

            DateTime dateThree = new DateTime(2020, 06, 10);
            Barbecue street = new Barbecue(dateThree, "Street", 20, 20, 20, 60);

            DateTime dateFour = new DateTime(2020, 07, 04);
            Barbecue yard = new Barbecue(dateFour, "Yard", 40, 40, 40, 120);

            _barbecueRepo.AddBarbecueToList(park);
            _barbecueRepo.AddBarbecueToList(conferenceRoom);
            _barbecueRepo.AddBarbecueToList(street);
            _barbecueRepo.AddBarbecueToList(yard);
        }
    }
}

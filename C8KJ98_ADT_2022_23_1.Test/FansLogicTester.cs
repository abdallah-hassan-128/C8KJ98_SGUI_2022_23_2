﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C8KJ98_ADT_2022_23_1.Logic;
using C8KJ98_ADT_2022_23_1.Repository;
using C8KJ98_ADT_2022_23_1.Models;
using Moq;
using NUnit.Framework;


namespace C8KJ98_ADT_2022_23_1.Test
{
    [TestFixture]

    class FansLogicTester
    {
        FansLogic FL;
        [SetUp]
        public void Init()
        {
            var MockFanRepository = new Mock<IFansRepository>();
            var MockReservationsRepository = new Mock<IReservationsRepository>();
            var fans = new List<Fans>()
            {
                new Fans(){ Id =1,City="Budapest1",Email="fan1@gmail.com",Name="fan1",PhoneNumber=11111111},
                new Fans(){Id =2,City="Budapest2",Email="fan2@gmail.com",Name="fan2",PhoneNumber=22222222},
                new Fans(){Id =3,City="Budapest3",Email="fan3@gmail.com",Name="fan3",PhoneNumber=33333333},
                new Fans(){Id =4,City="Budapest4",Email="fan4@gmail.com",Name="fan4",PhoneNumber=44444444},
                new Fans(){Id =5,City="Budapest5",Email="fan5@gmail.com",Name="fan5",PhoneNumber=55555555}
            }.AsQueryable();
            var Reservations = new List<Reservations>()
            {
                new Reservations(){Id = 1 , FanId=5,ArtistId=4,DateTime=new DateTime(2021,11,21) },
                new Reservations(){Id = 2 , FanId=2,ArtistId=5,DateTime=new DateTime(2021,11,22) },
                new Reservations(){Id = 3 , FanId=2,ArtistId=2,DateTime=new DateTime(2021,11,23) },
                new Reservations(){Id = 4 , FanId=1,ArtistId=3,DateTime=new DateTime(2021,11,29) },
                new Reservations(){Id = 5 , FanId=1,ArtistId=1,DateTime=new DateTime(2021,11,20) }
            }.AsQueryable();
            MockFanRepository.Setup((t) => t.GetAll()).Returns(fans);
            MockReservationsRepository.Setup((t) => t.GetAll()).Returns(Reservations);
            for (int i = 0; i < 5; i++)
            {
                MockFanRepository.Setup((t) => t.GetOne(i + 1)).Returns(fans.ToList()[i]);
            }
            FL = new FansLogic(MockReservationsRepository.Object, MockFanRepository.Object);
        }

        // Tests for crud-operations
        [Test]
        public void AddNewFanTest_Throws()
        {
            Fans fan = new Fans() { City = "budapest6", Email = "fan6@gmail.com", Name = null, PhoneNumber = 66666666 };
            //Arrange
            Assert.Throws<ArgumentException>(() => FL.AddNewFan(fan));
        }
        [Test]
        public void AddNewFanTest()
        {
            Fans fan = new Fans() { City = "budapest6", Email = "fan6@gmail.com", Name = "fan6", PhoneNumber = 66666666 };
            //Act

            Fans fan6 = FL.AddNewFan(fan);
            //Arrange
            Assert.That(fan6.Name, Is.EqualTo("fan6"));
        }

        [Test]
        public void DeleteFanTest_Throws()
        {
            //Arrange
            Assert.Throws<ArgumentException>(() => FL.DeleteFan(100));
        }

        // tests for non-crud methods
        [Test]
        public void BestFan()
        {
            //act 
            var result = FL.BestFan();
            var expected = new List<KeyValuePair<int, int>>() { new KeyValuePair<int, int>(1, 2), new KeyValuePair<int, int>(2, 2) };

            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void WorstFan()
        {
            //act 
            var result = FL.WorstFan();
            var expected = new List<KeyValuePair<int, int>>() { new KeyValuePair<int, int>(5, 1) };

            Assert.That(result, Is.EqualTo(expected));

        }
    }
}

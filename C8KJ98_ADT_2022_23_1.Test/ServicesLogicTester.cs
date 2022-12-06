using C8KJ98_ADT_2022_23_1.Logic;
using C8KJ98_ADT_2022_23_1.Models;
using C8KJ98_ADT_2022_23_1.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8KJ98_ADT_2022_23_1.Test
{
    [TestFixture]
    class ServicesLogicTester
    {
        ServicesLogic SL;
        [SetUp]
        public void Init()
        {
            var MockServicesRepository = new Mock<IServicesRepository>();
            var Services = new List<Services>()
            {
                new Services(){Id=1,Name="service1",Price=1,Rating=2},
                new Services(){Id=2,Name="service2",Price=2,Rating=3},
                new Services(){Id=3,Name="service3",Price=3,Rating=4},
                new Services(){Id=4,Name="service4",Price=4,Rating=5},
                new Services(){Id=5,Name="service5",Price=5,Rating=6},
            }.AsQueryable();
            MockServicesRepository.Setup((t) => t.GetAll()).Returns(Services);
            for (int i = 0; i < 5; i++)
            {
                MockServicesRepository.Setup((t) => t.GetOne(i + 1)).Returns(Services.ToList()[i]);
            }
            SL = new ServicesLogic(MockServicesRepository.Object);
        }

        [Test]
        public void AddServiceTest_Throws()
        {
            Services serv = new Services() { Name = null, Price = 100, Rating = 2 };
            //Arrange
            Assert.Throws<ArgumentException>(() => SL.AddNewService(serv));
        }
        [Test]
        public void DeleteServiceTest_Throws()
        {
            //Arrange
            Assert.Throws<Exception>(() => SL.DeleteService(100));
        }
    }
}

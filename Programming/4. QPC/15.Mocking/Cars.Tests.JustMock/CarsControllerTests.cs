namespace Cars.Tests.JustMock
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Cars.Contracts;
    using Cars.Tests.JustMock.Mocks;
    using Cars.Controllers;
    using System.Collections.Generic;
    using Cars.Models;
    using Cars.Infrastructure;


    [TestClass]
    public class CarsControllerTests
    {
        private ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
            : this(new JustMockCarsRepository())
        {
        }

        public CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A4", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        // added tests JustMock homework:
        [TestMethod]
        public void CreateCarsControllerWithoutRepository()
        {
            var actual = new CarsController();
            Assert.IsInstanceOfType(actual, typeof(CarsController));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DetailOfInvalidIdShouldThrowException()
        {
            var model = (Car)this.GetModel(() => this.controller.Details(-1));
        }

        [TestMethod]
        public void SearchingShouldReturnView()
        {
            var car1 = new Car
            {
                Id = 2,
                Make = "BMW",
                Model = "325i",
                Year = 2008
            };

            var car2 = new Car
            {
                Id = 3,
                Make = "BMW",
                Model = "330d",
                Year = 2007
            };

            var result = new List<Car>();
            result.Add(car1);
            result.Add(car2);
            var expected = (List<Car>)new View(result).Model;
            var actual = (List<Car>)this.controller.Search("BMW").Model;

            Assert.AreEqual(expected[0].Id, actual[0].Id);
            Assert.AreEqual(expected[0].Make, actual[0].Make);
            Assert.AreEqual(expected[0].Model, actual[0].Model);
            Assert.AreEqual(expected[0].Year, actual[0].Year);

            Assert.AreEqual(expected[1].Id, actual[1].Id);
            Assert.AreEqual(expected[1].Make, actual[1].Make);
            Assert.AreEqual(expected[1].Model, actual[1].Model);
            Assert.AreEqual(expected[1].Year, actual[1].Year);

            Assert.AreEqual(expected.Count, actual.Count);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortingWithInvalidParameterShouldThrowAnException()
        {
            this.controller.Sort("something");
        }

        [TestMethod]
        public void SortingByMake()
        {
            var actual = (List<Car>)this.controller.Sort("make").Model;
            var expected = new List<Car> 
            {
                new Car { Id = 1, Make = "Audi", Model = "A4", Year = 2005 },
                new Car { Id = 2, Make = "BMW", Model = "325i", Year = 2008 },
                new Car { Id = 3, Make = "BMW", Model = "330d", Year = 2007 },
                new Car { Id = 4, Make = "Opel", Model = "Astra", Year = 2010 },
            };

            Assert.AreEqual(expected[0].Id, actual[0].Id);
            Assert.AreEqual(expected[0].Make, actual[0].Make);
            Assert.AreEqual(expected[0].Model, actual[0].Model);
            Assert.AreEqual(expected[0].Year, actual[0].Year);

            Assert.AreEqual(expected[1].Id, actual[1].Id);
            Assert.AreEqual(expected[1].Make, actual[1].Make);
            Assert.AreEqual(expected[1].Model, actual[1].Model);
            Assert.AreEqual(expected[1].Year, actual[1].Year);

            Assert.AreEqual(expected[2].Id, actual[2].Id);
            Assert.AreEqual(expected[2].Make, actual[2].Make);
            Assert.AreEqual(expected[2].Model, actual[2].Model);
            Assert.AreEqual(expected[2].Year, actual[2].Year);

            Assert.AreEqual(expected[3].Id, actual[3].Id);
            Assert.AreEqual(expected[3].Make, actual[3].Make);
            Assert.AreEqual(expected[3].Model, actual[3].Model);
            Assert.AreEqual(expected[3].Year, actual[3].Year);
        }

        [TestMethod]
        public void SortingByYear()
        {
            var actual = (List<Car>)this.controller.Sort("year").Model;
            var expected = new List<Car> 
            {
                new Car { Id = 1, Make = "Audi", Model = "A4", Year = 2005 },
                new Car { Id = 3, Make = "BMW", Model = "330d", Year = 2007 },
                new Car { Id = 2, Make = "BMW", Model = "325i", Year = 2008 },
                new Car { Id = 4, Make = "Opel", Model = "Astra", Year = 2010 },
            };
            Assert.AreEqual(expected[0].Id, actual[0].Id);
            Assert.AreEqual(expected[0].Make, actual[0].Make);
            Assert.AreEqual(expected[0].Model, actual[0].Model);
            Assert.AreEqual(expected[0].Year, actual[0].Year);

            Assert.AreEqual(expected[1].Id, actual[1].Id);
            Assert.AreEqual(expected[1].Make, actual[1].Make);
            Assert.AreEqual(expected[1].Model, actual[1].Model);
            Assert.AreEqual(expected[1].Year, actual[1].Year);

            Assert.AreEqual(expected[2].Id, actual[2].Id);
            Assert.AreEqual(expected[2].Make, actual[2].Make);
            Assert.AreEqual(expected[2].Model, actual[2].Model);
            Assert.AreEqual(expected[2].Year, actual[2].Year);

            Assert.AreEqual(expected[3].Id, actual[3].Id);
            Assert.AreEqual(expected[3].Make, actual[3].Make);
            Assert.AreEqual(expected[3].Model, actual[3].Model);
            Assert.AreEqual(expected[3].Year, actual[3].Year);
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}

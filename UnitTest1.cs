using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpligatoristRESTAPI;
using OpligatoristRESTAPI.Managers;
using ObligatoriskOpgave;
using ObligatoriskOpgave.Models;
using ObligatoriskOpgave.Exeptions;

namespace OpligatoriskRESTAPITest
{
    [TestClass]
    public class UnitTest1
    {
        private CarManager _manager;
        private Car _car;
        [TestInitialize]
        public void Init()
        {
            _manager = new CarManager();
            _car = new Car();
        }

        [TestMethod]
        public void TestGetAll()
        {
            Assert.IsInstanceOfType(_manager.GetAll(), typeof(List<Car>));

            Assert.IsNotNull(_manager.GetAll());
        }

        [TestMethod]
        public void TestGetById()
        {
            Assert.IsInstanceOfType(_manager.GetById(1), typeof(Car));

            Assert.IsNotNull(_manager.GetById(1));
        }

        [TestMethod]
        public void TestPost()
        {
            Car carToCreate = new Car(32, "Gold", 999999.50, "XD69420");
            Car carCreated = _manager.CreateCar(carToCreate);
            Assert.IsNotNull(carCreated);
            Assert.AreEqual(carToCreate, carCreated);
        }

        [TestMethod]
        public void TestPut()
        {
            Car carCreated = _manager.CreateCar(new Car(32, "Gold", 999999.50, "XD69420"));
            Assert.AreEqual(5, carCreated.ID);

            Car carToModify = _manager.GetById(carCreated.ID);
            Assert.IsNotNull(carToModify);
            Assert.AreEqual("Gold", carToModify.Model);
            carToModify.Model = "Puntu";
            Car carModified = _manager.UpdateCar(carToModify, carToModify.ID);
            Assert.AreEqual(carToModify.Model, carModified.Model);
            carToModify.LicensePlate = "XD42420";
            carModified = _manager.UpdateCar(carToModify, carToModify.ID);
            Assert.AreEqual(carToModify.LicensePlate, carModified.LicensePlate);
        }

        [TestMethod]
        public void TestDelete()
        {
            Car carDeleted = _manager.DeleteCar(2);
            Assert.IsNotNull(carDeleted);
        }
    }
}

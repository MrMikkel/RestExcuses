using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestExcuses.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestExcuses.Models;
using Microsoft.EntityFrameworkCore;

namespace RestExcuses.Managers.Tests
{
    [TestClass()]
    public class ExcuseManagerDBTests
    {
        private ExcuseManagerDB _manager;
        private MovementManagerDB _movement;


        //        private IExcusesManager _manager;


        public ExcuseManagerDBTests()
        {
            var OptionsBuilder = new DbContextOptionsBuilder<ExcusesContext>();
            OptionsBuilder.UseSqlServer(Secret.ConnectionString);
            ExcusesContext ex = new ExcusesContext(OptionsBuilder.Options);
            _manager = new ExcuseManagerDB(ex);
            _movement = new MovementManagerDB(ex);
        }

       


        [TestMethod()]
        public void GetAllTest()
        {
            IEnumerable<ExcuseClass> ex = _manager.GetAll();
            Assert.IsTrue(ex.Last().Excuse.Contains("Test"));
        }

        [TestMethod()]
        public void PostExcuseTest()
        {
            ExcuseClass ex1 = new ExcuseClass(1,"Test excuse");
            ExcuseClass ex2 = new ExcuseClass(1, null);
            bool postedExcuseTrue = _manager.PostExcuse(ex1);
            bool postedExcuseFalse = _manager.PostExcuse(ex2);

            Assert.IsTrue(postedExcuseTrue);
            Assert.IsFalse(postedExcuseFalse);
        }

        [TestMethod()]
        public void PostAndGetLastTest()
        {
            Movement testMove = new Movement("test", DateTime.UtcNow);
            _movement.PostMovement(testMove);
            Movement m = _movement.GetLastEntry();
            Assert.AreEqual(testMove.movement, m.movement);
        }
        //public void TestUpdate()
        //{
        //    Creates a new Item which holds data to update another Item
        //    Item newItem = new Item(14, "TestItem", 3, 4);
        //    Updates the Item
        //    _manager.Update(1, newItem);
        //    Checks that Item in the manager has the name from the newItem
        //    Assert.AreEqual(newItem.Name, _manager.GetById(1).Name);

        //    Checks that we receive a null when trying to update something not existing in the manager
        //    Assert.IsNull(_manager.Update(4, newItem));

        //    Cleans up
        //    Item cleanUpItem = new Item() { Name = "Book about C#", ItemQuality = 300, Quantity = 10 };
        //    _manager.Update(1, cleanUpItem);
        //}
        [TestMethod()]
        public void UpdateExcusesTest()
        {
            //opretter et nyt obj. der indeholder data der skal opdatere en ikke eksisterende excuse
            ExcuseClass newExcuseClass = new ExcuseClass(20, "test20");
            //opdatere excuse
            _manager.UpdateExcuse(1, newExcuseClass);
            //tjekker om der er en excuse i manager, som har navnet fra den nye excuse
            Assert.AreEqual(newExcuseClass.Excuse, _manager.GetByID(1).Excuse);
            //tjekker om vi modtager null når vi forsøger at opdatere noget der ikke eksistere i managerklassen
            Assert.IsNull(_manager.UpdateExcuse(50, newExcuseClass));
            //clean up
            ExcuseClass cleanUpExcuse = new ExcuseClass()
            { Excuse = "testundskyldning 1" };
            _manager.UpdateExcuse(1, cleanUpExcuse);
        }
    }
}
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
        [TestMethod()]
        public void UpdateExcusesTest()
        {
            //Creates a new excuse which holds data to update another Excuse
            //opretter noget data
            ExcuseClass newExcuseClass = new ExcuseClass(20, "test20");
            //opdatere excuse
            //id nr 1, skal nu have de værdier fra den nyoprettede excuse
            //overskrevet id 1, med ''test20'', værdier fra nr 2 parameter
            _manager.UpdateExcuse(1, newExcuseClass);
            //tjekker om der er en excuse i manager, som har navnet fra den nye excuse
            Assert.AreEqual(newExcuseClass.Excuse, _manager.GetByID(1).Excuse);
            //clean up
            //ExcuseClass cleanUpExcuse = new ExcuseClass()
            //{ Excuse = "testundskyldning 1" };
            //_manager.UpdateExcuse(1, cleanUpExcuse);
        }
        //tester den med string
        [TestMethod()]
        public void UpdateExcusesTestString()
        {
            //opdatere excuse, via string
            //id nr 1, skal nu have de værdier fra den nyoprettede excuse
            //overskrevet id 1, med ''test20'', værdier fra nr 2 parameter
            _manager.UpdateExcuse(4, "Virker denne test?");
            //tjekker om der er en excuse i manager, som har navnet fra den nye excuse
            Assert.AreEqual("Virker denne test?", _manager.GetByID(4).Excuse);
            //clean up
            //ExcuseClass cleanUpExcuse = new ExcuseClass()
            //{ Excuse = "testundskyldning 1" };
            //_manager.UpdateExcuse(1, cleanUpExcuse);
        }
    }
}
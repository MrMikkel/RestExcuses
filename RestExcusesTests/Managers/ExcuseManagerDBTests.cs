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
        private ExcusesManagerDB _manager;
        private MovementsManagerDB _movements;
        //initialize dbcontext
        


        //        private IExcusesManager _manager;


        public ExcuseManagerDBTests()
        {
            var OptionsBuilder = new DbContextOptionsBuilder<ExcusesContext>();
            OptionsBuilder.UseSqlServer(Secret.ConnectionString);
            ExcusesContext ex = new ExcusesContext(OptionsBuilder.Options);
            _manager = new ExcusesManagerDB(ex);
            _movements = new MovementsManagerDB(ex);
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
            ExcuseClass ex1 = new ExcuseClass(1, "Test excuse");
            ExcuseClass ex2 = new ExcuseClass(1, null);
            ExcuseClass postedExcuseTrue = _manager.PostExcuse(ex1);
            ExcuseClass postedExcuseFalse = _manager.PostExcuse(ex2);

            Assert.IsTrue(postedExcuseTrue.Excuse==ex1.Excuse);
            Assert.IsTrue(postedExcuseFalse == null);
        }

        [TestMethod()]
        public void PostAndGetLastTest()
        {
            Movement testMove = new Movement("test", DateTime.UtcNow);
            _movements.PostMovement(testMove);
            Movement m = _movements.GetLastEntry();
            Assert.AreEqual(testMove.movement, m.movement);
        }
        [TestMethod()]
        public void UpdateExcusesTest()
        {
            //Creates a new excuse which holds data to update another Excuse
            //opretter noget data
            ExcuseClass newExcuseClass = new ExcuseClass(10, "test10");
            //opdatere excuse
            //id nr 1, skal nu have de værdier fra den nyoprettede excuse
            //overskrevet id 1, med ''test20'', værdier fra nr 2 parameter
            _manager.UpdateExcuse(newExcuseClass);
            //tjekker om der er en excuse i manager, som har navnet fra den nye excuse
            Assert.AreEqual(newExcuseClass.Excuse, _manager.GetByID(10).Excuse);
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

        [TestMethod()]
        public void DeleteExcusesTest()
        {
            ExcuseClass ex1 = new ExcuseClass(1, "delete test");
            ExcuseClass postedExcuse = _manager.PostExcuse(ex1);
            Assert.IsTrue(postedExcuse.Excuse==ex1.Excuse);

            bool ex2 = _manager.DeleteExcuse(postedExcuse.Id);

            Assert.IsTrue(ex2);
        }
        [TestMethod()]
        public void GetHistoryTest()
        {
            IOrderedEnumerable<CategoryCount> orderedList = _movements.GetHistory();
            Assert.IsTrue(orderedList.Any());
            Assert.IsTrue(orderedList.Count()==5);
            List<CategoryCount> result = orderedList.ToList();
            for (int i = 0; i < result.Count()-2; i++)
            {
                Assert.IsTrue(result[i].Count>=result[i+1].Count);
            }



        }

        [TestMethod()]
        public void DeleteAllMovementsTest()
        {
            Movement mov = new Movement("left", DateTime.UtcNow);
            _movements.PostMovement(mov);

            _movements.DeleteAllMovements();
            Movement newmov = _movements.GetLastEntry();
            Assert.IsNull(newmov);

        }
    }
}
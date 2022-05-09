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
    }
}
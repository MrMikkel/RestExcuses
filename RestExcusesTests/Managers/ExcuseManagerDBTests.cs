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
            IEnumerable<Excuse> ex = _manager.GetAll();
            Assert.IsTrue(ex.Last().ExcuseValue.Contains("Test"));
        }

        [TestMethod()]
        public void PostExcuseTest()
        {
            Excuse ex1 = new Excuse(1,"Test excuse");
            Excuse ex2 = new Excuse(1, null);
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
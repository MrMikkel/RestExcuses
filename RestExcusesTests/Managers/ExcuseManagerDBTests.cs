using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestExcuses.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestExcuses.Models;

namespace RestExcuses.Managers.Tests
{
    [TestClass()]
    public class ExcuseManagerDBTests
    {
        private ExcuseManagerDB _manager;

//        private IExcusesManager _manager;
        

        public ExcuseManagerDBTests()
        {

        }

       
        public ExcuseManagerDBTests(ExcusesContext context)
        {
            _manager = new ExcuseManagerDB(context);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            IEnumerable<Excuses> ex = _manager.GetAll();
            Assert.IsTrue(ex.Last().Excuse.Contains("3"));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacmanREST.Models;
using PacmanREST.Controllers;
using System.Net;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PacmanREST.Tests
{
    [TestClass]
    public class TestCarerController
    {
        [TestMethod]
        public void PostCarer_ShouldReturnSamePatient()
        {
            var controller = new CarerController(new TestPacmanRESTContext());
            var item = new Pacman_carer_db() {device_id = null, name = "MyName", phone = 123456 , ID=null };
            var result = controller.PostPacman_carer_db(item) as CreatedAtRouteNegotiatedContentResult<Pacman_carer_db>;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.Content.name, item.name);

        }

        [TestMethod]
        public void PutCarer_ShouldReturnStatusCode()
        {
            var controller = new CarerController(new TestPacmanRESTContext());
            var item = GetDemoCarer();
            var result = controller.PutPacman_carer_db(1, item) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [TestMethod]
        public void PutProduct_ShouldFail_WhenDifferentID()
        {
            var controller = new CarerController(new TestPacmanRESTContext());

            var badresult = controller.PutPacman_carer_db(999, GetDemoCarer());
            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }

        [TestMethod]
        public void GetCarer_ShouldReturnPatienttWithSameID()
        {
            var context = new TestPacmanRESTContext();
            context.Pacman_carer_db.Add(GetDemoCarer());

            var controller = new CarerController(context);
            var result = controller.GetPacman_carer_db(1) as OkNegotiatedContentResult<Pacman_carer_db>;

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Content.ID);
        }

        Pacman_carer_db GetDemoCarer()
        {
            return new Pacman_carer_db() { ID = 1, device_id = "lotsofstringhere", name = "demoPatient", phone = 4321, address = "address", email = "email@domain.com" };
        }

        [TestMethod]
        public void GetCarer_ShouldReturnAllPatients()
        {
            var context = new TestPacmanRESTContext();
            context.Pacman_carer_db.Add(new Pacman_carer_db { ID = 1, device_id = "lotsofstringhere", name = "demoPatient", phone = 4321, address="address", email = "email@domain.com" });
            context.Pacman_carer_db.Add(new Pacman_carer_db { ID = 2, device_id = "lotsofstringhere", name = "demoPatient", phone = 4321, address="address", email = "email@domain.com" });
            context.Pacman_carer_db.Add(new Pacman_carer_db { ID = 3, device_id = "lotsofstringhere", name = "demoPatient", phone = 4321, address="address", email = "email@domain.com" });

            var controller = new CarerController(context);
            var result = controller.GetPacman_carer_db() as TestPatientDbSet;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }

        [TestMethod]
        public void DeleteCarer_ShouldReturnOK()
        {
            var context = new TestPacmanRESTContext();
            var item = GetDemoCarer();
            context.Pacman_carer_db.Add(item);

            var controller = new CarerController(context);
            var result = controller.DeletePacman_carer_db(3) as OkNegotiatedContentResult<Pacman_carer_db>;

            Assert.IsNotNull(result);
            Assert.AreEqual(item.ID, result.Content.ID);
        }
        
    }
}

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
    public class TestPatientController
    {
        [TestMethod]
        public void PostPatient_ShouldReturnSamePatient()
        {
            var controller = new PatientController(new TestPacmanRESTContext());
            var item = new Pacman_patient_db() {device_id = null, name = "MyName", phone = "123456", ID=null };
            var result = controller.PostPacman_patient_db(item) as CreatedAtRouteNegotiatedContentResult<Pacman_patient_db>;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.Content.name, item.name);

        }

        [TestMethod]
        public void PutPatient_ShouldReturnStatusCode()
        {
            var controller = new PatientController(new TestPacmanRESTContext());
            var item = GetDemoPatient();
            var result = controller.PutPacman_patient_db(1, item) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [TestMethod]
        public void PutProduct_ShouldFail_WhenDifferentID()
        {
            var controller = new PatientController(new TestPacmanRESTContext());

            var badresult = controller.PutPacman_patient_db(999, GetDemoPatient());
            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }

        [TestMethod]
        public void GetPatient_ShouldReturnPatienttWithSameID()
        {
            var context = new TestPacmanRESTContext();
            context.Pacman_patient_db.Add(GetDemoPatient());

            var controller = new PatientController(context);
            var result = controller.GetPacman_patient_db(1) as OkNegotiatedContentResult<Pacman_patient_db>;

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Content.ID);
        }

        Pacman_patient_db GetDemoPatient()
        {
            return new Pacman_patient_db() { ID = 1, device_id = "lotsofstringhere", name = "demoPatient", phone = "4321" };
        }

        [TestMethod]
        public void GetPatient_ShouldReturnAllPatients()
        {
            var context = new TestPacmanRESTContext();
            context.Pacman_patient_db.Add(new Pacman_patient_db { ID = 1, device_id = "lotsofstringhere", name = "demoPatient", phone = "4321" });
            context.Pacman_patient_db.Add(new Pacman_patient_db { ID = 2, device_id = "lotsofstringhere", name = "demoPatient", phone = "4321" });
            context.Pacman_patient_db.Add(new Pacman_patient_db { ID = 3, device_id = "lotsofstringhere", name = "demoPatient", phone = "4321" });

            var controller = new PatientController(context);
            var result = controller.GetPacman_patient_db() as TestPatientDbSet;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }

        [TestMethod]
        public void DeletePatient_ShouldReturnOK()
        {
            var context = new TestPacmanRESTContext();
            var item = GetDemoPatient();
            context.Pacman_patient_db.Add(item);

            var controller = new PatientController(context);
            var result = controller.DeletePacman_patient_db(3) as OkNegotiatedContentResult<Pacman_patient_db>;

            Assert.IsNotNull(result);
            //Assert.AreEqual(item.ID, result.Content.ID);
        }
        
    }
}

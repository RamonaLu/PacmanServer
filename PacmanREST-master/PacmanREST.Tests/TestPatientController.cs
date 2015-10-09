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
    class TestPatientController
    {
        [TestMethod]
        public void PostProduce_ShouldReturnSameProduct()
        {
            var controller = new PatientController(new TestPacmanRESTContext());
            var patient = new Pacman_patient_db() {device_id = null, name = "MyName", phone = "123456" };
            var result = controller.PostPacman_patient_db(patient) as CreatedAtRouteNegotiatedContentResult<Pacman_patient_db>;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content.ID);

        }

        
    }
}

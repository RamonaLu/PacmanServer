using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacmanREST.Models;

namespace PacmanREST.Tests
{
    class TestLocationDbSet : TestDbSet<Pacman_location_db>
    {
        public override Pacman_location_db Find(params object[] keyValues)
        {
            return this.SingleOrDefault(patient => patient.ID == (int)keyValues.Single());
        }
    }
}

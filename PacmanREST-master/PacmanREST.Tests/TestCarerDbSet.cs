using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacmanREST.Models;

namespace PacmanREST.Tests
{
    class TestCarerDbSet : TestDbSet<Pacman_carer_db>
    {
        public override Pacman_carer_db Find(params object[] keyValues)
        {
            return this.SingleOrDefault(patient => patient.ID == (int)keyValues.Single());
        }
    }
}

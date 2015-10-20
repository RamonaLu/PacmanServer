using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacmanREST.Models;

namespace PacmanREST.Tests
{
    class TestFencesDbSet : TestDbSet<Fence>
    {
        public override Fence Find(params object[] keyValues)
        {
            return this.SingleOrDefault(patient => patient.ID == (int)keyValues.Single());
        }
    }
}

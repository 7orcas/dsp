using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Modules.Machines.Ent;

namespace Backend.Modules.Machines
{
    public interface IMachineService
    {
        Task<List<Machine>> GetMachines();
    }
}

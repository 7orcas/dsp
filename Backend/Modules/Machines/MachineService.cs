using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Modules.Machines.Ent;

namespace Backend.Modules.Machines
{
    public class MachineService: IMachineService
    {

        public async Task<List<Machine>> GetMachines()
        {
            return await Task.Run(() =>
            {
                List <Machine> machines = new List<Machine>();

    Thread.Sleep(2000);

                machines.Add(new Machine { 
                    Code = "M1",
                    Description = "M1 Description",
                });
                machines.Add(new Machine
                {
                    Code = "M2",
                    Description = "M2 Description",
                });
                return machines;
            });
        }



    }
}

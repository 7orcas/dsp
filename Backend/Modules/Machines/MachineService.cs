using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.App;
using Backend.Modules._Base;
using Backend.Modules.Machines.Ent;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace Backend.Modules.Machines
{
    public class MachineService: BaseService, IMachineService
    {
        public async Task<List<Machine>> GetMachines()
        {
            List <Machine> machines = new List<Machine>();
            await Sql.Run(
                    "SELECT * FROM Machine m" + Sql.AddBaseEntity("m"),
                    r => {
                        var m = ReadBaseEntity<Machine>(r);
                        m.StationPairs = GetInt(r, "StationPairs");
                        machines.Add(m);
                    }
            );
            return machines;
        }
    }
}

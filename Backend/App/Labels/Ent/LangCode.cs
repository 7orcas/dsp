using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Language code
 * Non persisted entity (maybe added tot he database at a future date)
 */


namespace Backend.App.Labels.Ent
{
    public class LangCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public bool IsDefault { get; set; }
    }
}

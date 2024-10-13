using Backend.App;
using Backend.App.Labels.Ent;
using Backend.Modules._Base;
using Microsoft.Data.SqlClient;

namespace Backend.App.Labels
{
    public class LabelService : BaseService, ILabelService
    {
        public async Task<List<Label>> GetLabels()
        {
            List <Label> list = new List<Label>();
            await Sql.Run(
                    "SELECT * FROM App.Label l",
                    r => {
                        var m = ReadEntity<Label>(r);
                        list.Add(m);
                    }
            );
            return list;
        }

        private T ReadEntity<T>(SqlDataReader r) where T: Label, new()
        {
            var entity = new T();
            entity._OrgId = GetIdNull(r, "_OrgId");
            entity.Id = GetId(r, "Id");
            entity.Code = (string)r["Code"];
            entity.Description = GetString(r, "Descr");
            entity.Encoded = GetString(r, "Encoded");
            entity.Updated = (DateTime)r["Updated"];

            return entity;
        }
    }
}

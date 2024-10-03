using Backend.Modules.Moulds.Ent;
using Microsoft.Data.SqlClient;

namespace Backend.Modules.Moulds
{
    public class MouldService: IMouldService
    {

        public async Task<List<MouldGroup>> GetMouldGroups()
        {
            return await Task.Run(() =>
            {
                List <MouldGroup> groups = new List<MouldGroup>();

   // Thread.Sleep(2000);


                var connectionString = "Server=np:localhost;Database=dsp;TrustServerCertificate=True;Authentication=Active Directory Integrated;";

                var connection = new SqlConnection(connectionString);
                try
                {
                    connection.Open();
                    var command = new SqlCommand("SELECT * FROM MouldGroup m INNER JOIN _BaseEntity b ON b.Id = m._id", connection);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        groups.Add(new MouldGroup
                        {
                            Code = (string)reader["Code"],
                            Description = (string)reader["Descr"],
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return groups;
            });
        }



    }
}

using MySql.Data;
using MySql.Data.MySqlClient;


internal class FotosRepository
{
    private readonly string _connectionString = "server=20.67.52.115;uid=root;pwd=P@ssword1;database=testdb";
        //@"Data Source=C:\Programming\Beau\Back-end\API\Scripts\ExotischNederland.db";

    public FotosRepository()
    {
        InitializeDatabase();
    }

    private void InitializeDatabase()
    {
        CreateOpenConnection();
    }

    private MySqlConnection CreateOpenConnection()
    {
        var connection = new MySqlConnection(_connectionString);
        connection.Open();
        return connection;
    }

    public List<Fotos> HaalAlleFotosOp()
    {
        var connection = CreateOpenConnection();

        var soorten = new List<Fotos>();
        string selectQuery = @"
            SELECT * FROM FOTO;";
        using var command = new MySqlCommand(selectQuery, connection);

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            int fid = reader.GetInt32(0);
            byte foto = reader.GetByte(1);
            soorten.Add(new Fotos
            (
                fid,
                foto
            ));
        }

        return soorten;
    }
    public void VoegFotoToe(Fotos Foto)
    {
        var connection = CreateOpenConnection();

        string insertQuery = @"
            INSERT INTO FOTO (Fid, Foto)
            VALUES (@Fid, @Foto);";

        using var command = new MySqlCommand(insertQuery, connection);
        command.Parameters.AddWithValue("@Fid", Foto.Fid);
        command.Parameters.AddWithValue("@Foto", Foto.Foto);

        command.ExecuteNonQuery();
    }

    public void VerwijderFoto(String foto)
    {
        using var connection = CreateOpenConnection();

        string deleteQuery = @"
        DELETE FROM FOTO
        WHERE Foto = @Foto;";

        using var command = new MySqlCommand(deleteQuery, connection);
        command.Parameters.AddWithValue("@Foto", foto);

        command.ExecuteNonQuery();
    }
}
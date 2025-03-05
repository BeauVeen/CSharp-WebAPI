using MySql.Data.MySqlClient;

internal class GeluidenRepository
{
    private readonly string _connectionString = "server=20.67.52.115;uid=root;pwd=P@ssword1;database=testdb";

    public GeluidenRepository()
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

    public List<Geluiden> HaalAlleGeluidenOp()
    {
        var connection = CreateOpenConnection();

        var soorten = new List<Geluiden>();
        string selectQuery = @"
            SELECT * FROM GELUID;";
        using var command = new MySqlCommand(selectQuery, connection);

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            int gid = reader.GetInt32(0);
            string geluid = reader.GetString(1);
            soorten.Add(new Geluiden
            (
                    gid,
                    geluid
            ));
        }

        return soorten;
    }
    public void VoegGeluidToe(Geluiden Geluid)
    {
        var connection = CreateOpenConnection();

        string insertQuery = @"
            INSERT INTO GELUID (Gid, Geluid)
            VALUES (@Gid, @Geluid);";

        using var command = new MySqlCommand(insertQuery, connection);
        command.Parameters.AddWithValue("@Gid", Geluid.Gid);
        command.Parameters.AddWithValue("@Geluid", Geluid.Geluid);

        command.ExecuteNonQuery();
    }

    public void VerwijderGeluid(String geluid)
    {
        using var connection = CreateOpenConnection();

        string deleteQuery = @"
        DELETE FROM GELUID
        WHERE Geluid = @Geluid;";

        using var command = new MySqlCommand(deleteQuery, connection);
        command.Parameters.AddWithValue("@Geluid", geluid);

        command.ExecuteNonQuery();
    }
}
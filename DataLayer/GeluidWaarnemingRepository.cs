using MySql.Data.MySqlClient;

internal class GeluidWaarnemingRepository
{
    private readonly string _connectionString = "server=20.67.52.115;uid=root;pwd=P@ssword1;database=testdb";

    public GeluidWaarnemingRepository()
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

    public List<GeluidWaarneming> HaalAlleGeluidWaarnemingenOp()
    {
        var connection = CreateOpenConnection();

        var soorten = new List<GeluidWaarneming>();
        string selectQuery = @"
            SELECT * FROM GELUIDWAARNEMING;";
        using var command = new MySqlCommand(selectQuery, connection);

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            int wid = reader.GetInt32(0);
            int gid = reader.GetInt32(1);
            soorten.Add(new GeluidWaarneming
            (
                wid,
                gid
            ));
        }

        return soorten;
    }
    public void VoegGeluidWaarnemingToe(GeluidWaarneming geluidWaarneming)
    {
        var connection = CreateOpenConnection();

        string insertQuery = @"
            INSERT INTO GELUIDWAARNEMING (Wid, Gid)
            VALUES (@Wid, @Gid);";

        using var command = new MySqlCommand(insertQuery, connection);
        command.Parameters.AddWithValue("@Wid", geluidWaarneming.Wid);
        command.Parameters.AddWithValue("@Gid", geluidWaarneming.Gid);

        command.ExecuteNonQuery();
    }

    public void VerwijderGeluidWaarneming(String wid)
    {
        using var connection = CreateOpenConnection();

        string deleteQuery = @"
        DELETE FROM GELUIDWAARNEMING
        WHERE Wid = @Wid;";

        using var command = new MySqlCommand(deleteQuery, connection);
        command.Parameters.AddWithValue("@Wid", wid);

        command.ExecuteNonQuery();
    }
}
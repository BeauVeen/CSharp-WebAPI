using MySql.Data.MySqlClient;

internal class FotoWaarnemingRepository
{
    private readonly string _connectionString = "server=20.67.52.115;uid=root;pwd=P@ssword1;database=testdb";

    public FotoWaarnemingRepository()
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

    public List<FotoWaarneming> HaalAlleFotoWaarnemingenOp()
    {
        var connection = CreateOpenConnection();

        var soorten = new List<FotoWaarneming>();
        string selectQuery = @"
            SELECT * FROM FOTOWAARNEMING;";
        using var command = new MySqlCommand(selectQuery, connection);

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            int wid = reader.GetInt32(0);
            int fid = reader.GetInt32(1);
            soorten.Add(new FotoWaarneming
            (
                wid,
                fid
            ));
        }

        return soorten;
    }
    public void VoegFotoWaarnemingToe(FotoWaarneming fotoWaarneming)
    {
        var connection = CreateOpenConnection();

        string insertQuery = @"
            INSERT INTO FOTOWAARNEMING (Wid, Fid)
            VALUES (@Wid, @Fid);";

        using var command = new MySqlCommand(insertQuery, connection);
        command.Parameters.AddWithValue("@Wid", fotoWaarneming.Wid);
        command.Parameters.AddWithValue("@Fid", fotoWaarneming.Fid);

        command.ExecuteNonQuery();
    }

    public void VerwijderFotoWaarneming(String wid)
    {
        using var connection = CreateOpenConnection();

        string deleteQuery = @"
        DELETE FROM FOTOWAARNEMING
        WHERE Wid = @Wid;";

        using var command = new MySqlCommand(deleteQuery, connection);
        command.Parameters.AddWithValue("@Wid", wid);

        command.ExecuteNonQuery();
    }
}
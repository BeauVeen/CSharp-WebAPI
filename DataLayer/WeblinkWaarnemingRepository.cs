using MySql.Data.MySqlClient;

internal class WeblinkWaarnemingRepository
{
    private readonly string _connectionString = "server=20.67.52.115;uid=root;pwd=P@ssword1;database=testdb";

    public WeblinkWaarnemingRepository()
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

    public List<WeblinkWaarneming> HaalAlleWeblinkWaarnemingenOp()
    {
        var connection = CreateOpenConnection();

        var soorten = new List<WeblinkWaarneming>();
        string selectQuery = @"
            SELECT * FROM WEBLINKWAARNEMING;";
        using var command = new MySqlCommand(selectQuery, connection);

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            int wid = reader.GetInt32(0);
            int webid = reader.GetInt32(1);
            soorten.Add(new WeblinkWaarneming
            (
                wid,
                webid
            ));
        }

        return soorten;
    }
    public void VoegWeblinkWaarnemingToe(WeblinkWaarneming weblinkWaarneming)
    {
        var connection = CreateOpenConnection();

        string insertQuery = @"
            INSERT INTO WEBLINKWAARNEMING (Wid, Webid)
            VALUES (@Wid, @Webid);";

        using var command = new MySqlCommand(insertQuery, connection);
        command.Parameters.AddWithValue("@Wid", weblinkWaarneming.Wid);
        command.Parameters.AddWithValue("@Webid", weblinkWaarneming.Webid);


        command.ExecuteNonQuery();
    }

    public void VerwijderWeblinkWaarneming(String wid)
    {
        using var connection = CreateOpenConnection();

        string deleteQuery = @"
        DELETE FROM WEBLINKWAARNEMING
        WHERE Wid = @Wid;";

        using var command = new MySqlCommand(deleteQuery, connection);
        command.Parameters.AddWithValue("@Wid", wid);

        command.ExecuteNonQuery();
    }
}
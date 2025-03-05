using MySql.Data.MySqlClient;

internal class SoortRepository
{
    private readonly string _connectionString = "server=20.67.52.115;uid=root;pwd=P@ssword1;database=testdb";

    public SoortRepository()
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

    public List<Soorten> HaalAlleSoortenOp()
    {
        var connection = CreateOpenConnection();

        var soorten = new List<Soorten>();
        string selectQuery = @"
            SELECT * FROM SOORT;";
        using var command = new MySqlCommand(selectQuery, connection);

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            int sid = reader.GetInt32(0);
            string soort = reader.GetString(1);
            string voorkomen = reader.GetString(2);
            soorten.Add(new Soorten
            (
                sid,
                soort,
                voorkomen
            ));
        }

        return soorten;
    }
    public void VoegSoortToe(Soorten Soort)
    {
        var connection = CreateOpenConnection();

        string insertQuery = @"
            INSERT INTO SOORT (Sid, Soort, Voorkomen)
            VALUES (@Sid, @Soort, @Voorkomen);";

        using var command = new MySqlCommand(insertQuery, connection);
        command.Parameters.AddWithValue("@Sid", Soort.Sid);
        command.Parameters.AddWithValue("@Soort", Soort.Soort);
        command.Parameters.AddWithValue("@Voorkomen", Soort.Voorkomen);

        command.ExecuteNonQuery();
    }

    public void VerwijderSoort(String soort)
    {
        using var connection = CreateOpenConnection();

        string deleteQuery = @"
        DELETE FROM SOORT
        WHERE Soort = @Soort;";

        using var command = new MySqlCommand(deleteQuery, connection);
        command.Parameters.AddWithValue("@Soort", soort);

        command.ExecuteNonQuery();
    }
}
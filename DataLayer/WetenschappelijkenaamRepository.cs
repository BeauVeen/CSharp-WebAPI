using MySql.Data.MySqlClient;

internal class WetenschappelijkenaamRepository
{
    private readonly string _connectionString = "server=20.67.52.115;uid=root;pwd=P@ssword1;database=testdb";

    public WetenschappelijkenaamRepository()
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

    public List<Wetenschappelijkenaam> HaalAlleWetenschappelijkenamenOp()
    {
        var connection = CreateOpenConnection();

        var soorten = new List<Wetenschappelijkenaam>();
        string selectQuery = @"
            SELECT * FROM WETENSCHAPPELIJKENAAM;";
        using var command = new MySqlCommand(selectQuery, connection);

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            int wnid = reader.GetInt32(0);
            string naam = reader.GetString(1);
            string wetenschappelijkeNaam = reader.GetString(2);
            soorten.Add(new Wetenschappelijkenaam
            (
                wnid,
                naam,
                wetenschappelijkeNaam
            ));
        }

        return soorten;
    }
    public void VoegWetenschappelijkenaamToe(Wetenschappelijkenaam wetenschappelijkeNaam)
    {
        var connection = CreateOpenConnection();

        string insertQuery = @"
            INSERT INTO WETENSCHAPPELIJKENAAM (WNid, Naam, WetenschappelijkeNaam)
            VALUES (@WNid, @Naam, @WetenschappelijkeNaam);";

        using var command = new MySqlCommand(insertQuery, connection);
        command.Parameters.AddWithValue("@WNid", wetenschappelijkeNaam.WNid);
        command.Parameters.AddWithValue("@Naam", wetenschappelijkeNaam.Naam);
        command.Parameters.AddWithValue("@WetenschappelijkeNaam", wetenschappelijkeNaam.WetenschappelijkeNaam);

        command.ExecuteNonQuery();
    }

    public void VerwijderWetenschappelijkenaam(String naam)
    {
        using var connection = CreateOpenConnection();

        string deleteQuery = @"
        DELETE FROM WETENSCHAPPELIJKENAAM
        WHERE Naam = @Naam;";

        using var command = new MySqlCommand(deleteQuery, connection);
        command.Parameters.AddWithValue("@Naam", naam);

        command.ExecuteNonQuery();
    }
}
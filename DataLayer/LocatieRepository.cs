using MySql.Data.MySqlClient;

internal class LocatieRepository
{
    private readonly string _connectionString = "server=20.67.52.115;uid=root;pwd=P@ssword1;database=testdb";

    public LocatieRepository()
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

    public List<Locatie> HaalAlleLocatiesOp()
    {
        var connection = CreateOpenConnection();

        var soorten = new List<Locatie>();
        string selectQuery = @"
            SELECT * FROM LOCATIE;";
        using var command = new MySqlCommand(selectQuery, connection);

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            int lid = reader.GetInt32(0);
            string locatienaam = reader.GetString(1);
            string provincie = reader.GetString(2);
            float breedtegraad = reader.GetFloat(3);
            float lengtegraad = reader.GetFloat(4);
            soorten.Add(new Locatie
            (
                lid,
                locatienaam,
                provincie,
                breedtegraad,
                lengtegraad
            ));
        }

        return soorten;
    }
    public void VoegLocatieToe(Locatie Locatie)
    {
        var connection = CreateOpenConnection();

        string insertQuery = @"
            INSERT INTO LOCATIE (Lid, Locatienaam, Provincie, Breedtegraad, Lengtegraad)
            VALUES (@Lid, @Locatienaam, @Provincie, @Breedtegraad, @Lengtegraad);";

        using var command = new MySqlCommand(insertQuery, connection);
        command.Parameters.AddWithValue("@Lid", Locatie.Lid);
        command.Parameters.AddWithValue("@Locatienaam", Locatie.Locatienaam);
        command.Parameters.AddWithValue("@Provincie", Locatie.Provincie);
        command.Parameters.AddWithValue("@Breedtegraad", Locatie.Breedtegraad);
        command.Parameters.AddWithValue("@Lengtegraad", Locatie.Lengtegraad);

        command.ExecuteNonQuery();
    }

    public void VerwijderLocatie(String lid)
    {
        using var connection = CreateOpenConnection();

        string deleteQuery = @"
        DELETE FROM LOCATIE
        WHERE Lid = @Lid;";

        using var command = new MySqlCommand(deleteQuery, connection);
        command.Parameters.AddWithValue("@Lid", lid);

        command.ExecuteNonQuery();
    }
}
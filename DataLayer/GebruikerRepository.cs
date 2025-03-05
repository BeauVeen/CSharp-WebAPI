using MySql.Data.MySqlClient;

internal class GebruikerRepository
{
    private readonly string _connectionString = "server=20.67.52.115;uid=root;pwd=P@ssword1;database=testdb";

    public GebruikerRepository()
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

    public List<Gebruiker> HaalAlleGebruikersOp()
    {
        var connection = CreateOpenConnection();

        var soorten = new List<Gebruiker>();
        string selectQuery = @"
            SELECT * FROM GEBRUIKER;";
        using var command = new MySqlCommand(selectQuery, connection);

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            string weergavenaam = reader.GetString(0);
            string naam = reader.GetString(1);
            string email = reader.GetString(2);
            string biografie = reader.GetString(3);
            string taal = reader.GetString(4);
            string geslacht = reader.GetString(5);
            int geboortejaar = reader.GetInt32(6);
            string telefoonnummer = reader.GetString(7);
            string land = reader.GetString(8);

            soorten.Add(new Gebruiker
            (
                weergavenaam,
                naam,
                email,
                biografie,
                taal,
                geslacht,
                geboortejaar,
                telefoonnummer,
                land
            ));
        }

        return soorten;
    }
    public void VoegGebruikerToe(Gebruiker Gebruiker)
    {
        var connection = CreateOpenConnection();

        string insertQuery = @"
            INSERT INTO GEBRUIKER (Weergavenaam, Naam, Email, Biografie, Taal, Geslacht, Geboortejaar, Telefoonnummer, Land)
            VALUES (@Weergavenaam, @Naam, @Email, @Biografie, @Taal, @Geslacht, @Geboortejaar, @Telefoonnummer, @Land);";

        using var command = new MySqlCommand(insertQuery, connection);
        command.Parameters.AddWithValue("@Weergavenaam", Gebruiker.Weergavenaam);
        command.Parameters.AddWithValue("@Naam", Gebruiker.Naam);
        command.Parameters.AddWithValue("@Email", Gebruiker.Email);
        command.Parameters.AddWithValue("@Biografie", Gebruiker.Biografie);
        command.Parameters.AddWithValue("@Taal", Gebruiker.Taal);
        command.Parameters.AddWithValue("@Geslacht", Gebruiker.Geslacht);
        command.Parameters.AddWithValue("@Geboortejaar", Gebruiker.Geboortejaar);
        command.Parameters.AddWithValue("@Telefoonnummer", Gebruiker.Telefoonnummer);
        command.Parameters.AddWithValue("@Land", Gebruiker.Land);


        command.ExecuteNonQuery();
    }

    public void VerwijderGebruiker(String weergavenaam)
    {
        using var connection = CreateOpenConnection();

        string deleteQuery = @"
        DELETE FROM GEBRUIKER
        WHERE Weergavenaam = @Weergavenaam;";

        using var command = new MySqlCommand(deleteQuery, connection);
        command.Parameters.AddWithValue("@Weergavenaam", weergavenaam);

        command.ExecuteNonQuery();
    }
}
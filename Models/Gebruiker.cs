public class Gebruiker
{
    public string Weergavenaam { get; private set; }
    public string Naam { get; private set; }
    public string Email { get; private set; }
    public string Biografie { get; private set; }
    public string Taal { get; private set; }
    public string Geslacht { get; private set; }
    public int Geboortejaar { get; private set; }
    public string Telefoonnummer { get; private set; }
    public string Land { get; private set; }


    public Gebruiker(string weergavenaam, string naam, string email, string biografie, string taal, string geslacht, int geboortejaar, string telefoonnummer, string land)
    {
        Weergavenaam = weergavenaam;
        Naam = naam;
        Email = email;
        Biografie = biografie;
        Taal = taal;
        Geslacht = geslacht;
        Geboortejaar = geboortejaar;
        Telefoonnummer = telefoonnummer;
        Land = land;
    }
}
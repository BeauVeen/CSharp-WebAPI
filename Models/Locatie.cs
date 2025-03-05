public class Locatie
{
    public int Lid { get; private set; }
    public string Locatienaam { get; private set; }
    public string Provincie { get; private set; }
    public float Breedtegraad { get; private set; }
    public float Lengtegraad { get; private set; }


    public Locatie(int lid, string locatienaam, string provincie, float breedtegraad, float lengtegraad)
    {
        Lid = lid;
        Locatienaam = locatienaam;
        Provincie = provincie;
        Breedtegraad = breedtegraad;
        Lengtegraad = lengtegraad;
    }
}
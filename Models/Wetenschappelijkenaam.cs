public class Wetenschappelijkenaam
{
    public int WNid { get; private set; }
    public string Naam { get; private set; }
    public string WetenschappelijkeNaam { get; private set; }

    public Wetenschappelijkenaam(int wnid, string naam, string wetenschappelijkenaam)
    {
        WNid = wnid;
        Naam = naam;
        WetenschappelijkeNaam = wetenschappelijkenaam;
    }
}
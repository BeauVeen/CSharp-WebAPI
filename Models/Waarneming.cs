public class Waarneming
{
    public int Wid { get; private set; }
    public string Omschrijving { get; private set; }
    public int Sid { get; private set; }
    public string Datum { get; private set; }
    public string Tijd { get; private set; }
    public int WNid { get; private set; }
    public int Lid { get; private set; }
    public string Toelichting { get; private set; }
    public int Aantal { get; private set; }
    public string Geslacht { get; private set; }
    public string Gebruiker { get; private set; }
    public string Zekerheid { get; private set; }
    public int Webid { get; private set; }
    public string ManierDelen { get; private set; }



    public Waarneming(int wid, string omschrijving, int sid, string datum, string tijd, int wnid, int lid, string toelichting, int aantal, string geslacht, string gebruiker, string zekerheid, int webid, string manierdelen)
    {
        Wid = wid;
        Omschrijving = omschrijving;
        Sid = sid;
        Datum = datum;
        Tijd = tijd;
        WNid = wnid;
        Lid = lid;
        Toelichting = toelichting;
        Aantal = aantal;
        Geslacht = geslacht;
        Gebruiker = gebruiker;
        Zekerheid = zekerheid;
        Webid = webid;
        ManierDelen = manierdelen;
    }
}
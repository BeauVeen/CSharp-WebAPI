public class Geluiden
{
    public int Gid { get; private set; }
    public string Geluid { get; private set; }

    public Geluiden(int gid, string geluid)
    {
        Gid = gid;
        Geluid = geluid;
    }
}
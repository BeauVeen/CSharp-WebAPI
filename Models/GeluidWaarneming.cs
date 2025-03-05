public class GeluidWaarneming
{
    public int Wid { get; private set; }
    public int Gid { get; private set; }

    public GeluidWaarneming(int wid, int gid)
    {
        Wid = wid;
        Gid = gid;
    }
}
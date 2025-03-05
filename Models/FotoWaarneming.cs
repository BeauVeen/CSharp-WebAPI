public class FotoWaarneming
{
    public int Wid { get; private set; }
    public int Fid { get; private set; }

    public FotoWaarneming(int wid, int fid)
    {
        Wid = wid;
        Fid = fid;
    }
}
public class WeblinkWaarneming
{
    public int Wid { get; private set; }
    public int Webid { get; private set; }

    public WeblinkWaarneming(int wid, int webid)
    {
        Wid = wid;
        Webid = webid;
    }
}
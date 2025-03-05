public class Weblinks
{
    public int Webid { get; private set; }
    public string Weblink { get; private set; }

    public Weblinks(int webid, string weblink)
    {
        Webid = webid;
        Weblink = weblink;
    }
}
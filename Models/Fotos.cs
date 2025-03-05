public class Fotos
{
    public int Fid { get; private set; }
    public byte Foto { get; private set; }

    public Fotos(int fid, byte foto)
    {
        Fid = fid;
        Foto = foto;
    }
}
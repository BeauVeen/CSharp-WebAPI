public class FotosService
{
    private readonly FotosRepository _repository;

    public FotosService()
    {
        _repository = new FotosRepository();
    }
    public List<Fotos> HaalAlleFotosOp()
    {
        return _repository.HaalAlleFotosOp();
    }

    public void RegistreerFoto(Fotos Foto)
    {
        _repository.VoegFotoToe(Foto);
    }

    public bool VerwijderFoto(String soort)
    {
        //TODO: implementeer 
        //var soort = _repository.HaalInheemseSoortOp(naam);
        //if (soort == null)
        //{
        //    return false;
        //}

        _repository.VerwijderFoto(soort);
        return true;
    }
}
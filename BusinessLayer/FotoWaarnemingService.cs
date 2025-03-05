public class FotoWaarnemingService
{
    private readonly FotoWaarnemingRepository _repository;

    public FotoWaarnemingService()
    {
        _repository = new FotoWaarnemingRepository();
    }
    public List<FotoWaarneming> HaalAlleFotoWaarnemingenOp()
    {
        return _repository.HaalAlleFotoWaarnemingenOp();
    }

    public void RegistreerFotoWaarneming(FotoWaarneming fotoWaarneming)
    {
        _repository.VoegFotoWaarnemingToe(fotoWaarneming);
    }

    public bool VerwijderFotoWaarneming(String soort)
    {
        //TODO: implementeer 
        //var soort = _repository.HaalInheemseSoortOp(naam);
        //if (soort == null)
        //{
        //    return false;
        //}

        _repository.VerwijderFotoWaarneming(soort);
        return true;
    }
}
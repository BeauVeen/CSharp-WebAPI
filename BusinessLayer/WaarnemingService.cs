public class WaarnemingService
{
    private readonly WaarnemingRepository _repository;

    public WaarnemingService()
    {
        _repository = new WaarnemingRepository();
    }
    public List<Waarneming> HaalAlleWaarnemingenOp()
    {
        return _repository.HaalAlleWaarnemingenOp();
    }

    public void RegistreerWaarneming(Waarneming waarneming)
    {
        _repository.VoegWaarnemingToe(waarneming);
    }

    public bool VerwijderWaarneming(String soort)
    {
        //TODO: implementeer 
        //var soort = _repository.HaalInheemseSoortOp(naam);
        //if (soort == null)
        //{
        //    return false;
        //}

        _repository.VerwijderWaarneming(soort);
        return true;
    }
}
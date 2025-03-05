public class GeluidWaarnemingService
{
    private readonly GeluidWaarnemingRepository _repository;

    public GeluidWaarnemingService()
    {
        _repository = new GeluidWaarnemingRepository();
    }
    public List<GeluidWaarneming> HaalAlleGeluidWaarnemingenOp()
    {
        return _repository.HaalAlleGeluidWaarnemingenOp();
    }

    public void RegistreerGeluidWaarneming(GeluidWaarneming geluidWaarneming)
    {
        _repository.VoegGeluidWaarnemingToe(geluidWaarneming);
    }

    public bool VerwijderGeluidWaarneming(String soort)
    {
        //TODO: implementeer 
        //var soort = _repository.HaalInheemseSoortOp(naam);
        //if (soort == null)
        //{
        //    return false;
        //}

        _repository.VerwijderGeluidWaarneming(soort);
        return true;
    }
}
public class WeblinkWaarnemingService
{
    private readonly WeblinkWaarnemingRepository _repository;

    public WeblinkWaarnemingService()
    {
        _repository = new WeblinkWaarnemingRepository();
    }
    public List<WeblinkWaarneming> HaalAlleWeblinkWaarnemingenOp()
    {
        return _repository.HaalAlleWeblinkWaarnemingenOp();
    }

    public void RegistreerWeblinkWaarneming(WeblinkWaarneming weblinkWaarneming)
    {
        _repository.VoegWeblinkWaarnemingToe(weblinkWaarneming);
    }

    public bool VerwijderWeblinkWaarneming(String soort)
    {
        //TODO: implementeer 
        //var soort = _repository.HaalInheemseSoortOp(naam);
        //if (soort == null)
        //{
        //    return false;
        //}

        _repository.VerwijderWeblinkWaarneming(soort);
        return true;
    }
}
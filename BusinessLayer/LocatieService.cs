public class LocatieService
{
    private readonly LocatieRepository _repository;

    public LocatieService()
    {
        _repository = new LocatieRepository();
    }
    public List<Locatie> HaalAlleLocatiesOp()
    {
        return _repository.HaalAlleLocatiesOp();
    }

    public void RegistreerLocatie(Locatie Locatie)
    {
        _repository.VoegLocatieToe(Locatie);
    }

    public bool VerwijderLocatie(String soort)
    {
        //TODO: implementeer 
        //var soort = _repository.HaalInheemseSoortOp(naam);
        //if (soort == null)
        //{
        //    return false;
        //}

        _repository.VerwijderLocatie(soort);
        return true;
    }
}
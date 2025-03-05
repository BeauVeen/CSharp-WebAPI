public class GeluidenService
{
    private readonly GeluidenRepository _repository;

    public GeluidenService()
    {
        _repository = new GeluidenRepository();
    }
    public List<Geluiden> HaalAlleGeluidenOp()
    {
        return _repository.HaalAlleGeluidenOp();
    }

    public void RegistreerGeluid(Geluiden Geluid)
    {
        _repository.VoegGeluidToe(Geluid);
    }

    public bool VerwijderGeluid(String soort)
    {
        //TODO: implementeer 
        //var soort = _repository.HaalInheemseSoortOp(naam);
        //if (soort == null)
        //{
        //    return false;
        //}

        _repository.VerwijderGeluid(soort);
        return true;
    }
}
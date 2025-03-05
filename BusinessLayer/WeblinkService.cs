public class WeblinkService
{
    private readonly WeblinkRepository _repository;

    public WeblinkService()
    {
        _repository = new WeblinkRepository();
    }
    public List<Weblinks> HaalAlleWeblinksOp()
    {
        return _repository.HaalAlleWeblinksOp();
    }

    public void RegistreerWeblink(Weblinks Weblink)
    {
        _repository.VoegWeblinkToe(Weblink);
    }

    public bool VerwijderWeblink(String soort)
    {
        //TODO: implementeer 
        //var soort = _repository.HaalInheemseSoortOp(naam);
        //if (soort == null)
        //{
        //    return false;
        //}

        _repository.VerwijderWeblink(soort);
        return true;
    }
}
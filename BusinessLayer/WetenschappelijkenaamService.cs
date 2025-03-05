public class WetenschappelijkenaamService
{
    private readonly WetenschappelijkenaamRepository _repository;

    public WetenschappelijkenaamService()
    {
        _repository = new WetenschappelijkenaamRepository();
    }
    public List<Wetenschappelijkenaam> HaalAlleWetenschappelijkenamenOp()
    {
        return _repository.HaalAlleWetenschappelijkenamenOp();
    }

    public void RegistreerWetenschappelijkenaam(Wetenschappelijkenaam wetenschappelijkeNaam)
    {
        _repository.VoegWetenschappelijkenaamToe(wetenschappelijkeNaam);
    }

    public bool VerwijderWetenschappelijkenaam(String soort)
    {
        //TODO: implementeer 
        //var soort = _repository.HaalInheemseSoortOp(naam);
        //if (soort == null)
        //{
        //    return false;
        //}

        _repository.VerwijderWetenschappelijkenaam(soort);
        return true;
    }
}
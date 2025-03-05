public class SoortService
{
    private readonly SoortRepository _repository;

    public SoortService()
    {
        _repository = new SoortRepository();
    }
    public List<Soorten> HaalAlleSoortenOp()
    {
        return _repository.HaalAlleSoortenOp();
    }

    public void RegistreerSoort(Soorten Soort)
    {
        _repository.VoegSoortToe(Soort);
    }

    public bool VerwijderSoort(String soort)
    {
        //TODO: implementeer 
        //var soort = _repository.HaalInheemseSoortOp(naam);
        //if (soort == null)
        //{
        //    return false;
        //}

        _repository.VerwijderSoort(soort);
        return true;
    }
}
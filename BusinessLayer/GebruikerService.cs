public class GebruikerService
{
    private readonly GebruikerRepository _repository;

    public GebruikerService()
    {
        _repository = new GebruikerRepository();
    }
    public List<Gebruiker> HaalAlleGebruikersOp()
    {
        return _repository.HaalAlleGebruikersOp();
    }

    public void RegistreerGebruiker(Gebruiker Gebruiker)
    {
        _repository.VoegGebruikerToe(Gebruiker);
    }

    public bool VerwijderGebruiker(String soort)
    {
        //TODO: implementeer 
        //var soort = _repository.HaalInheemseSoortOp(naam);
        //if (soort == null)
        //{
        //    return false;
        //}

        _repository.VerwijderGebruiker(soort);
        return true;
    }
}
using UnityEngine;
using RatRace;
using BLL;
using RatRaceBLL;

public class ServiceManager : MonoBehaviour
{
    private static Manager _instance;

    public static Manager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new Manager();
                RaceManager raceManager = new RaceManager(new RatRaceRepositoryJSON());
                Bookmaker bookmaker = new Bookmaker(new RatRaceRepositoryJSON());
                raceManager.Load();
                bookmaker.Load();
                _instance.raceManager = raceManager;
                _instance.bookmaker = bookmaker;
            }
            return _instance;
        }
    }
}
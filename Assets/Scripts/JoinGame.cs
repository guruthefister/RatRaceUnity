using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using RatRace;
using BLL;
using RatRaceBLL;

public class JoinGame : MonoBehaviour
{
    public GameObject BetInfo;
    public GameObject BetOnRat;

    public static Race CurrentRace;
    public Text Name, Money, Track, Rats, MinBet;

    public void Awake()
    {
        RaceManager raceManager = ServiceManager.Instance.raceManager;
        
        int numberOfRats = RNG.Range(2, 10);
        List<Rat> rats = new List<Rat>();
        for (int i = 0; i < numberOfRats; i++)
        {
            Rat rat = raceManager.CreateRat("rat " + (i + 1));
            rats.Add(rat);
        }

        int lenghtOfTrack = RNG.Range(100, 500);
        Track track = raceManager.CreateTrack("Track " + lenghtOfTrack, lenghtOfTrack);

        int raceID = RNG.Range(1, 1000);
        Race race = raceManager.CreateRace(raceID, rats, track);
        CurrentRace = race;

        Name.text += Login.CurrentPlayer.Name;
        Money.text += Login.CurrentPlayer.Money.ToString();
        Track.text += track.TrackLength.ToString();
        Rats.text += numberOfRats.ToString();
        MinBet.text += race.MinBetSize.ToString();
    }

    public void Yes()
    {
        BetInfo.SetActive(false);
        BetOnRat.SetActive(true);
    }

    public void No()
    {
        Name.text = "Name: ";
        Money.text = "Money: ";
        Track.text = "Track Lenght: ";
        Rats.text = "Number of Rats: ";
        MinBet.text = "Minimum bet size: ";
        Awake();
    }

    public void Ben()
    {
        int random = RNG.Range(1, 2);
        if(random == 1)
        {
            Yes();
            return;
        }
        No();
    }
}
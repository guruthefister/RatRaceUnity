using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using RatRace;

public class Betting : MonoBehaviour
{
    public Text Min;
    public Text Max;
    public Text Error;
    public InputField PlayerBet;
    public Dropdown Rat;

   public void betting()
    { 
        Max.text += Login.CurrentPlayer.Money.ToString();
        Min.text += JoinGame.CurrentRace.MinBetSize.ToString();
    }

    public void PlaceBet()
    {
        int.TryParse(PlayerBet.text, out int betSize);
        int max = Login.CurrentPlayer.Money;
        int min = JoinGame.CurrentRace.MinBetSize;

        if (betSize > max || betSize < min)
        {
            Error.enabled = true;
            return;
        }

        Race race = JoinGame.CurrentRace;
        Rat rat = race.Rats.Find(ratToFind => ratToFind.Name == Rat.itemText.text);
        Player player = Login.CurrentPlayer;
        ServiceManager.Instance.bookmaker.PlaceBet(race, rat, player, betSize);
        race.ConductRace();
        SceneManager.LoadScene(2);
    }
}

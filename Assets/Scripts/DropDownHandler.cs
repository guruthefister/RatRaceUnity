using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RatRace;

public class DropDownHandler : MonoBehaviour
{
    void Start()
    {
        var dropdown = transform.GetComponent<Dropdown>();

        dropdown.options.Clear();

        foreach (var rat in JoinGame.CurrentRace.Rats)
        {
            dropdown.options.Add(new Dropdown.OptionData() { text = rat.Name });
        }
    }
}

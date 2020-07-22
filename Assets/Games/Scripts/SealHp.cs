using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SealHp : MonoBehaviour
{
    // Cached References.
    Text text;

    // The player's health.
    int pHealth;

    // Start is called before the first frame update.
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame.
    void Update()
    {
        // Gets the value of pHealth from the "Seal" script.
        pHealth = FindObjectOfType<Seal>().GetComponent<Seal>().pHealth;

        // Displays the player's health.
        text.text = "HP" + pHealth;
    }
}
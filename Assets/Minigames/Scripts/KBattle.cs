using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]

public class KBattle : MonoBehaviour
{
    // Cached References.
    Text iText;
    SavenSceneLoader saveNScene;

    // Variables.

    // The player's health.
    int pHealth = 12;

    // The enemy's health.
    int eHealth = 30;

    // Decreases by 1 every second and decreases player health when <= 0.
    int timer = 15;

    // Page number that corresponds to an elements of the arrays.
    public int page = 0;

    // Array for pages of battle situations.  
    [TextArea(4, 50)]
    public string[] battleText;

    // Displays text from the element "battleText" array that corresponds to "page".
    public void TextDisplay()
    {
        iText.text = "RIN " + pHealth + "HP" + "  ROCK " + eHealth +
                     "HP" + "  Laser Timer " + timer + "S"
                     + Environment.NewLine + battleText[page].ToString();
    }

    // Loads the menu scene when the "Esc" key is pressed.
    public void LoadMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            saveNScene.Menu();
        }
    }

    // Decreases "timer" by 1 every second.
    public IEnumerator Lasers()
    {
        WaitForSeconds wait = new WaitForSeconds(1);
        while (eHealth > 0)
        {
                timer--;
                yield return wait;
        }
    }

    // Resets the timer when it reaches 0 and decreases "pHealth."
    public void Reset()
    {
        if (timer <= 0)
        {
            pHealth -= 2;
            timer = 15;
        }
    }
 

// Changes "eHealth" and "pHealth" based on the number key pressed for each page.
public void Choice()
    {
        switch (page)
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    pHealth -= 1;
                }
                if(Input.GetKeyDown(KeyCode.Alpha2))
                {
                    // Left open for potential future use and consistency.
                }
                if(Input.GetKeyDown(KeyCode.Alpha3))
                {

                }
                break;
            case 1:
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {

                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    pHealth -= 3;
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    pHealth -= 5;
                }
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    pHealth -= 3;
                    eHealth -= 3;
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    pHealth -= 2;
                    eHealth -= 3;
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {

                }
                break;
            case 3:
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    pHealth -= 2;
                    eHealth -= 2;
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    eHealth -= 1;
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    pHealth -= 5;
                }
                break;
            case 4:
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    eHealth -= 3;
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    eHealth -= 3;
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    pHealth += 2;
                }
                break;
            case 5:
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    eHealth -= 2;
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    eHealth -= 1;
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {

                }
                break;
            case 6:
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    eHealth -= 2;
                    pHealth -= 1;
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    eHealth -= 1;
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {

                }
                break;
            case 7:
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    eHealth -= 2;
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    eHealth -= 1;
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    eHealth -= 2;
                }
                break;
            case 8:
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    pHealth -= 4;
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    pHealth -= 1;
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {

                }
                break;
        }

        // Changes the page after a choice is made.
        if ( (Input.GetKeyDown(KeyCode.Alpha1)) || (Input.GetKeyDown(KeyCode.Alpha2)) || (Input.GetKeyDown(KeyCode.Alpha3)) )
        {
            page = UnityEngine.Random.Range(0, battleText.Length);
        }

    }

    public void NextScene()
    {
        // Switches the scene based on the outcome of the battle.
        if (eHealth <= 0)
        {
            saveNScene.loadName = "KWin";
            saveNScene.LoadScene();
        }
        if (pHealth <= 0)
        {
            saveNScene.loadName = "KLose";
            saveNScene.LoadScene();
        }
    }

    // Start is called before the first frame update.
    void Start()
    {
        // Picks a random page.
        page = UnityEngine.Random.Range(0, battleText.Length);

        StartCoroutine(Lasers());

        iText = GameObject.Find("TextBoxText").GetComponent<Text>();
        saveNScene = GameObject.Find("ScriptHolder").GetComponent<SavenSceneLoader>();
    }

    // Update is called once per frame.
    void Update()
    {
        TextDisplay();
        Reset();
        Choice();
        NextScene();
        LoadMenu();
    }
}


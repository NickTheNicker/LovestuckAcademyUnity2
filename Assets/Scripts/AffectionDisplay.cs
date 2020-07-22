using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;


public class AffectionDisplay : MonoBehaviour
{
    // Cached References.
    Text iText;
    SavenSceneLoader saveNScene;

    public void AffectionText()
    {
        string text = "Character Affection" + Environment.NewLine + Environment.NewLine +
            "Shiro " + saveNScene.save.sAffection + " Affection points" + Environment.NewLine + Environment.NewLine +
            "Lilith " + saveNScene.save.lAffection + " Affection points" + Environment.NewLine + Environment.NewLine +
            "Elora  " + saveNScene.save.eAffection + " Affection points";
        iText.text = text;
    }

    // Loads the menu scene when the "Esc" key is pressed.
    public void LoadMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            saveNScene.Menu();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        iText = GameObject.Find("TextBoxText").GetComponent<Text>();
        saveNScene = GameObject.Find("ScriptHolder").GetComponent<SavenSceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        AffectionText();
        LoadMenu();
    }
}

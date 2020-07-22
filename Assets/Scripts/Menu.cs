using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    SavenSceneLoader saveNScene;
    public Save save;
    GameObject confirmCanvas;

    // Whether the confirm screen/functions for starting a new game is on or off.
    bool confirmScreen = false;

    // Starts a new game.
    private void NewGame()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Asks to confirm starting a new game, if a save file exists.
            if (saveNScene.saveExists)
            {
                confirmScreen = true;
                confirmCanvas.gameObject.SetActive(true);
            }
            else 
            {
                SceneManager.LoadScene("Introduction");
            } 
        }
    }

    // Runs when a save exists but the player wants to start a new game.
    public void Confirm()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            confirmScreen = false;
            confirmCanvas.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            saveNScene.ForceDeleteSaves();
            SceneManager.LoadScene("Introduction");
        } 
    }

    // Loads save data if any.
    private void Continue()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            saveNScene.LoadLastScene();
        }
    }

    // Opens the lore viewing scene.
    private void Lore()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("Lore");
        }
    }

    // Opens the affection point display scene.
    private void Affection()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneManager.LoadScene("Affection");
        }
    }

    // Exits the game.
    private void Quit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            saveNScene.Exit();
        }
    }
     
// Start is called before the first frame update
void Start()
    {
        saveNScene = GameObject.Find("ScriptHolder").GetComponent<SavenSceneLoader>();
        confirmCanvas = GameObject.Find("Confirmation");
        confirmCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       if (confirmScreen)
        {
            Confirm();
        }
       else
        {
            NewGame();
            Continue();
        }

        Quit();
        Lore();
        Affection();
    }
}


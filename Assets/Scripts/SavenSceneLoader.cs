using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SavenSceneLoader : MonoBehaviour
{
    // Cached References.
    public Save save;

    public string loadName;
    public string currentScene;
    public bool saveExists;
    

    // Loads the "Menu" scene.
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    // Loads the "FirstDay" scene.
    public void FirstDay()
    {
        SceneManager.LoadScene("FirstDay");
    }

    // Loads the scene named in the string "loadName".
    public void LoadScene()
    {
        SceneManager.LoadScene(loadName);
    }
    // Closes the program.
    public void Exit()
    {
        Application.Quit();
    }

    // Save system from Josh Browne and Aidan Diprose. 
    public void SaveToFile()
    {
        BinaryFormatter bF = new BinaryFormatter();
        FileStream file;
        // Makes sure the file to save to exists.
        if (File.Exists(Application.persistentDataPath + "Saves.txt"))
        {
            file = File.Open(Application.persistentDataPath + "Saves.txt", FileMode.Open);
        }
        // Creates a new save file.
        else
        {
            file = File.Create(Application.persistentDataPath + "Saves.txt");
        }
        bF.Serialize(file, save);
        file.Close();
    }

    public void LoadFromFile()
    {
        BinaryFormatter bF = new BinaryFormatter();
        FileStream file;
        // Makes sure the save file exists.
        if (File.Exists(Application.persistentDataPath + "Saves.txt"))
        {
            file = File.Open(Application.persistentDataPath + "Saves.txt", FileMode.Open);
        }
        else
        {
            file = File.Create(Application.persistentDataPath + "Saves.txt");
            Save tempSaves = new Save();
            bF.Serialize(file, tempSaves);
            file.Close();
            save = new Save();
            return;

        }
        // Gets the data from the save.
        try
        {
            save = (Save)bF.Deserialize(file);
        }
        catch
        {
            file.Close();
            ForceDeleteSaves();
            LoadFromFile();
            return;
        }
        file.Close();
    }

    public void ForceDeleteSaves()
    {
        if (File.Exists(Application.persistentDataPath + "Saves.txt"))
        {
            File.Delete(Application.persistentDataPath + "Saves.txt");
        }
    }
    // End of code written by Josh Browne and Aidan Diprose.

    public void CheckSave()
    {
        if (File.Exists(Application.persistentDataPath + "Saves.txt"))
        {
            saveExists = true;
        }
        else
        {
            saveExists = false;
        }
    }

    public void LoadLastScene()
    {
        SceneManager.LoadScene(save.lastScene);
    }

    // Tracks the scenes you have already seen by updating bools in save.
    public void SaveTracker()
    {
        switch (currentScene)
        {
            case "ShiroMeet":
                save.sMeet = true;
                break;
            case "Club1st":
                save.club1 = true;
                break;
            case "Club2nd":
                save.club2 = true;
                break;
            case "Club3rd":
                save.club3 = true;
                break;

            case "LilithMeet":
                save.lMeet = true;
                break;
            case "Roof1st":
                save.roof1 = true;
                break;
            case "Roof2nd":
                save.roof2 = true;
                break;
            case "Roof3rd":
                save.roof3 = true;
                break;

            case "EloraMeet":
                save.eMeet = true;
                break;
            case "Library1st":
                save.library1 = true;
                break;
            case "Library2nd":
                save.library2 = true;
                break;
            case "Library3rd":
                save.library3 = true;
                break;
        }
    }

    void Start()
    {
        // Checks and gets the save file.
        CheckSave();
        LoadFromFile();

        // Gets the name of the current scene.
        currentScene = SceneManager.GetActiveScene().name;

        SaveTracker();

        // Hides the cursor.
        Cursor.visible = false;
    }
    private void Update()
    {
        // Saves the name of the current scene you are on.
        if (  (currentScene != "Menu") && (currentScene != "Lore") && (currentScene != "Affection") )
        {
            save.lastScene = SceneManager.GetActiveScene().name;
            SaveToFile();
        }


        /* Save Testing Code.
        Debug.Log(save.sAffection);
        Debug.Log(save.lunchCount);
        Debug.Log(save.sMeet);
        Debug.Log(save.club1);
        Debug.Log(save.lastScene);
        */
    }
}

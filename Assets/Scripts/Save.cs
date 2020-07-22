using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save 
{
    // Shiro's affection points.
    public int sAffection;

    // Lilith's affection points.
    public int lAffection;

    // Elora's affection points.
    public int eAffection;

    // The last scene the player was in.
    public string lastScene;

    // Tracks progress through lunch events.
    public int lunchCount;

    // Character Events where false = has not seen and true = has seen.

    // Shiro Events. 
    public bool sMeet;
    public bool club1;
    public bool club2;
    public bool club3;
    public bool club4;

    // Lilith Events.
    public bool lMeet;
    public bool roof1;
    public bool roof2;
    public bool roof3;
    public bool roof4;

    // Elora Events.
    public bool eMeet;
    public bool library1;
    public bool library2;
    public bool library3;
    public bool library4;
}

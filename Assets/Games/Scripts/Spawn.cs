using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Cached References.
    public GameObject bPrefab;
    public GameObject gPrefab;
    public GameObject dPrefab;

    public void BSpawn()
    {
        Vector2 spawnLocation = new Vector2(-9, 19);
        GameObject bonehead = Instantiate(bPrefab, spawnLocation, bPrefab.transform.rotation);
    }

    public IEnumerator Spawning()
    {
        WaitForSeconds wait = new WaitForSeconds(1);
       
        yield return wait;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Cached References.
    public GameObject bPrefab;
    public GameObject gPrefab;
    public GameObject dPrefab;

    // Location where enemies spawn.
    Vector2 spawnLocation = new Vector2(-9, 19);

    // Spawns a "Bonehead" enemy every 5 seconds
    public IEnumerator BSpawn()
    {
        WaitForSeconds wait = new WaitForSeconds(5);

        GameObject bonehead = Instantiate(bPrefab, spawnLocation, bPrefab.transform.rotation);

        yield return wait;

        StartCoroutine(BSpawn());
    }

    // Spawns a "Ghost" enemy every 6 seconds.
    public IEnumerator GSpawn()
    {
        WaitForSeconds wait = new WaitForSeconds(6);

        GameObject ghost = Instantiate(gPrefab, spawnLocation, gPrefab.transform.rotation);

        yield return wait;

        StartCoroutine(GSpawn());
    }

    // Spawns a "Demon" enemy after 65 seconds.
    public IEnumerator DSpawn()
    {
        WaitForSeconds wait = new WaitForSeconds(65);

        yield return wait;

        GameObject demon = Instantiate(dPrefab, spawnLocation, dPrefab.transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BSpawn());
        StartCoroutine(GSpawn());
        StartCoroutine(DSpawn());
    }
}

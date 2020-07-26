﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seal : MonoBehaviour
{
    // Cached References.
    SavenSceneLoader saveNScene;
    SpriteRenderer sprite;
    BoxCollider2D box;
    Rigidbody2D rigid;
    Component halo;

    // Variables.

    // The player's health.
    public int pHealth = 10;
    int maxHealth = 10;
    public int cooldown;
    readonly float pSpeed = 30f;
    readonly float maxSpeed = 45f;
    public bool invincible = false;

    // Methods.

    // Regenerates the player's health.
    public IEnumerator Regen()
    {
        WaitForSeconds wait = new WaitForSeconds(1);
        while (pHealth > 0)
        {
            while (pHealth < maxHealth)
            {
                pHealth++;
                yield return wait;
            }
            yield return wait;
        }

        // The coroutine does not repeat by itself so it must be set manually.
        StartCoroutine(Regen());
    }


    // Player's movement.
    private void Move()
    {
        if ((Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            rigid.velocity = new Vector2(-pSpeed, rigid.velocity.y);
        }
        if ((Input.GetKeyDown(KeyCode.S)) || (Input.GetKeyDown(KeyCode.DownArrow)))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, -pSpeed);
        }
        if ((Input.GetKeyDown(KeyCode.D)) || (Input.GetKeyDown(KeyCode.RightArrow)))
        {
            rigid.velocity = new Vector2(pSpeed, rigid.velocity.y);
        }
        if ((Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.UpArrow)))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, pSpeed);
        }

        // Prvents the player's speed from going beyond the set value.
        if (rigid.velocity.x > pSpeed)
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        if (rigid.velocity.y > pSpeed)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, maxSpeed);
        }
        if (rigid.velocity.x < -pSpeed)
        {
            rigid.velocity = new Vector2(-maxSpeed, rigid.velocity.y);
        }
        if (rigid.velocity.y < -pSpeed)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, -maxSpeed);
        }
    }

    // Turns the "invincible" bool off for an "Invoke" in the next method.
    public void Invincibility()
    {
        invincible = false;
    }

    // Decreases player health by 1 if "invincible" is false when colliding with an enemy.
    public void Damage()
    {
        if ((box.IsTouchingLayers(LayerMask.GetMask("Enemy"))) && (!invincible))
        {
            invincible = true;
            pHealth--;
            Invoke("Invincibility", 1);
        }
    }

    // Increases cooldown by 1 every second if it is less than 7.
    public IEnumerator Cooldown()
    {
        
        WaitForSeconds wait = new WaitForSeconds(1);
        while (cooldown < 7)
        {
            cooldown++;

            yield return wait;
        }
    }

    // Makes the player invincible for a short while when they press space.
    public void ActivateInvincibility()
    {
        if ((Input.GetKeyDown(KeyCode.Space)) && (cooldown == 7))
        {
            invincible = true;
            cooldown = 0;

            // Starts the couroutine again.
            StartCoroutine(Cooldown());

            // Turns on the halo.
            halo.GetType().GetProperty("enabled").SetValue(halo, true);
        }

        // Stops invincibility after 3 seconds.
        if (cooldown == 3)
        {
            invincible = false;

            // Turns off the halo. 
            halo.GetType().GetProperty("enabled").SetValue(halo, false);
        }
    }

    // Goes to the next scene.
    public void NextScene()
    {
        saveNScene.LoadScene();
    }

    // Kills the player and loads the next scene after a delay.
    public void Death()
    {
        if (pHealth <= 0)
        {
            sprite.enabled = false;
            box.enabled = false;

            Invoke("NextScene", 2);
        }
    }

    // Start is called before the first frame update.
    void Start()
    {
        saveNScene = GameObject.Find("ScriptHolder").GetComponent<SavenSceneLoader>();
        sprite = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
        rigid = GetComponent<Rigidbody2D>();
        halo = GetComponent("Halo");

        // Turns of the halo.
        halo.GetType().GetProperty("enabled").SetValue(halo, false);

        // Starts certain coroutines.
        StartCoroutine(Cooldown());
        StartCoroutine(Regen());
    }

    // Update is called once per frame.
    void Update()
    {
        Move();
        Damage();
        Death();
        ActivateInvincibility();
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seal : MonoBehaviour
{
    // Cached References.
    SavenSceneLoader saveNScene;
    BoxCollider2D box;
    Rigidbody2D rigid;
    Component halo;

    // Variables.

    // The player's health.
    public int pHealth = 12;
    public int maxHealth = 12;

    readonly float pSpeed = 30f;
    readonly float maxSpeed = 45f;

    bool invincible = false;
    int cooldown = 7; 

    // Methods.

    // Regenerates player health.
    public IEnumerator Regen()
    {
        WaitForSeconds wait = new WaitForSeconds(2);
        if (pHealth < maxHealth)
        {
            pHealth++;
            yield return wait;
        }
    }

    // Player's movement.
    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            rigid.velocity = new Vector2(-pSpeed, rigid.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, -pSpeed);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rigid.velocity = new Vector2(pSpeed, rigid.velocity.y);
        }
        if ((Input.GetKeyDown(KeyCode.W))  )
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

    // Decreases player health by 1 if "invincible" is false when colliding with an enemy.
    public void Damage()
    {
        if ((box.IsTouchingLayers(LayerMask.GetMask("Enemy"))) && (!invincible))
        {
            pHealth--;
        }
    }

    // Increases cooldown by 1 every second if it is less than 7.
    public IEnumerator Cooldown()
    {
        WaitForSeconds wait = new WaitForSeconds(1);
        if (cooldown < 7)
        {
            cooldown++;
            yield return wait;
        }
    }

    // Makes the player invincible for a short while when they press space.
    public void Invincibility()
    {
        if ((Input.GetKeyDown(KeyCode.Space)) && (cooldown == 7))
        {
            invincible = true;
            cooldown = 0;
            // Turns on the halo.
            halo.GetType().GetProperty("enabled").SetValue(halo, true);
        }

        if (cooldown == 3)
        {
            invincible = false;
            // Turns off the halo. 
            halo.GetType().GetProperty("enabled").SetValue(halo, false);
        }
    }

    // Start is called before the first frame update.
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        rigid = GetComponent<Rigidbody2D>();
        halo = GetComponent("Halo");

        // Turns of the halo.
        halo.GetType().GetProperty("enabled").SetValue(halo, false);

        // Starts Coroutines.
        StartCoroutine(Regen());
        StartCoroutine(Cooldown());
    }

    // Update is called once per frame.
    void Update()
    {
        Move();
        Damage();
        Invincibility();

        Debug.Log(cooldown);
        Debug.Log(invincible);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    // Cached References.
    BoxCollider2D box;
    CapsuleCollider2D cap;
    Rigidbody2D rigid;
    SpriteRenderer sprite;
    Transform ePlace;
    Transform pPlace;

    int eHealth = 2;
    int color;

    readonly float eSpeed = 8f;
    readonly float maxSpeed = 20f;

    // Methods.

    // Launches the enemy.
    private void Follow()
    {
        if ((ePlace.position.x - 4) < pPlace.position.x)
        {
            rigid.velocity = new Vector2(eSpeed, rigid.velocity.y);
        }
        else
        {
            rigid.velocity = new Vector2(-eSpeed, rigid.velocity.y);
        }
        if ((ePlace.position.y - 4) < pPlace.position.y)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, eSpeed);
        }
        else
        {
            rigid.velocity = new Vector2(rigid.velocity.x, -eSpeed);
        }

        // Prvents the enemy's speed from going beyond the set value.
        if (rigid.velocity.x > eSpeed)
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        if (rigid.velocity.y > eSpeed)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, maxSpeed);
        }
        if (rigid.velocity.x < -eSpeed)
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        if (rigid.velocity.y < -eSpeed)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, maxSpeed);
        }
    }

    // Allows the enemy to move past platforms when the player is directly under one.
    public void Avoid()
    {
        if (cap.IsTouchingLayers(LayerMask.GetMask("Area")))
        {
            rigid.velocity = new Vector2(Mathf.Sign(pPlace.position.x) * 20, rigid.velocity.y);
        }
    }


    // Changes the colour of the enemy if it collides with something except other enemies.
    public void Colour()
    {
        switch (color)
        {
            // Red.
            case 1:
                sprite.color = new Color(1f, 0f, 0f);
                break;

            // Yellow.
            case 2:

                sprite.color = new Color(1f, 1f, 0f);
                break;

            // Blue.
            case 3:
                sprite.color = new Color(1f, 0f, 0f);
                break;

            // Purple.
            case 4:
                sprite.color = new Color(1f, 0f, 1f);
                break;
        }

        if ((box.IsTouchingLayers(LayerMask.GetMask("Player"))) || (box.IsTouchingLayers(LayerMask.GetMask("Area"))))
        {
            color = Random.Range(1, 5);
        }
    }

    // Decreases enemy health by 1 after colliding with the player.
    public void Damage()
    {
        if (box.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            eHealth--;
        }
    }

    // Destroys enemy when health < 0.
    public void Death()
    {
        if (eHealth < 0)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        cap = GetComponentInChildren<CapsuleCollider2D>();
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        ePlace = GetComponent<Transform>();
        pPlace = FindObjectOfType<Seal>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
        Avoid();
        Colour();
        Damage();
        Death();
    }
}
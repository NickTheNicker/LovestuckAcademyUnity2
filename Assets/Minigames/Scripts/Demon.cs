using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : MonoBehaviour
{
    // Cached References.
    SavenSceneLoader saveNScene;
    BoxCollider2D box;
    CapsuleCollider2D cap;
    Rigidbody2D rigid;
    SpriteRenderer sprite;
    Transform ePlace;
    Transform pPlace;
    Seal seal;

    int eHealth = 30;
    readonly float eSpeed = 10f;
    readonly float maxSpeed = 10f;

    // Methods.

    // Makes the enemy follow the player if the player is not invincible.
    private void Follow()
    {
        if (!seal.invincible)
        {

            if (ePlace.position.x < pPlace.position.x)
            {
                rigid.velocity = new Vector2(eSpeed, rigid.velocity.y);
            }
            else
            {
                rigid.velocity = new Vector2(-eSpeed, rigid.velocity.y);
            }
            if (ePlace.position.y < pPlace.position.y)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, eSpeed);
            }
            else
            {
                rigid.velocity = new Vector2(rigid.velocity.x, -eSpeed);
            }
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

    // Decreases enemy health by 1 after colliding with the player.
    public void Damage()
    {
        if (box.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            eHealth--;
        }
    }

    // Goes to the next scene.
    public void NextScene()
    {
        saveNScene.LoadScene();
    }

    // Kills the enemy and loads the next scene after a delay.
    public void Death()
    {
        if (eHealth < 0)
        {
            sprite.enabled = false;
            box.enabled = false;
            cap.enabled = false;

            Invoke("NextScene", 1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        saveNScene = GameObject.Find("ScriptHolder").GetComponent<SavenSceneLoader>();
        box = GetComponent<BoxCollider2D>();
        cap = GetComponentInChildren<CapsuleCollider2D>();
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        ePlace = GetComponent<Transform>();
        pPlace = FindObjectOfType<Seal>().transform;
        seal = FindObjectOfType<Seal>().GetComponent<Seal>();
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
        Avoid();
        Damage();
        Death();
    }
}


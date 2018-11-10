﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTrigger : MonoBehaviour {

    public LayerMask Explosions;
    public GameObject Fireup;
    public GameObject Bombup;
    public bool isDestructible;
    bool instantiated;
    public float destroyTime;
    public bool spawnFireup;
    public bool spawnBombup;
    public bool spawnHeart;
    bool hit;
    public bool hasAnim;
    public Animator anim;
    Rigidbody2D rigidbody;
    public Patrol patrol;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {      
        if (hasAnim)
        { 
        if (collision.gameObject.layer == 15)
        {
                if (isDestructible)
                {
                    if (hasAnim)
                    {

                        anim.SetBool("isHit", true);
                    }

                    rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
                    patrol.IsAlive = false;
                    rigidbody.bodyType = RigidbodyType2D.Static;

                    foreach (BoxCollider2D c in GetComponents<BoxCollider2D>())
                    {
                        Destroy(c);
                    }
                    foreach (CircleCollider2D c in GetComponents<CircleCollider2D>())
                    {
                        Destroy(c);
                    }

                    Destroy(patrol);
                    transform.Translate(new Vector3(0, 0, 0));
                    Object.Destroy(gameObject, destroyTime);
                }

                else
                {
                    Object.Destroy(gameObject, destroyTime);
                    if (!instantiated)
                    {
                        if (spawnFireup)
                        {
                            Instantiate(Fireup, new Vector2(transform.position.x, transform.position.y), Quaternion.Euler(0, 0, 0));
                            instantiated = true;
                        }
                        if (spawnBombup)
                        {
                            Instantiate(Bombup, new Vector2(transform.position.x, transform.position.y), Quaternion.Euler(0, 0, 0));
                            instantiated = true;
                        }
                        if (spawnHeart)
                        {

                        }
                    }
                }
            }
        }
        
    }

    // Update is called once per frame
    void Update () {
        
	}
}

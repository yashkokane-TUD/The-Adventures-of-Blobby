using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multipleAttackwalls : MonoBehaviour
{
    //public GameObject cs;
    public PlayerMovement Dash;
    public int count;

    public SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    /*private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                cs.SetActive(true);
            }
            
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
             cs.SetActive(false);   
            }
        }*/

        private void OnCollisionEnter2D(Collision2D collision)
            {
                if (collision.gameObject.tag == "Player")
                {
                    if (Dash.Dashing == true)
                    {
                        if (count == 0)
                        {
                            Destroy(gameObject);
                        }
                        else if (count!=0)
                        {
                            sprite.color = Color.blue;
                            count--;
                        }
                    }
                }
            }
}

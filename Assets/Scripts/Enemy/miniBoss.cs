using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;

public class miniBoss : MonoBehaviour
{
    [SerializeField]float speed;
    //public float range;
    [SerializeField]int enemyHealth;
    public PlayerMovement Dash; 
    //public float minDistance = 2f;
    public Slider slider;

    public GameObject _enemy;
    public Transform[] points;
    public Transform currentPosition;
    public int pointSelect;
    public SpriteRenderer sR;

    public GameObject boss_health;
    // Start is called before the first frame update
    void Start()
    {
        sR = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, currentPosition.position,
            speed * Time.deltaTime);

        if (_enemy.transform.position == currentPosition.position)
        {
            pointSelect++;
            sR.flipX = true;
            transform.Rotate(new Vector3(0, 180, 0));
            if (pointSelect == points.Length)
            {
                pointSelect = 0;
                sR.flipX = false;
                transform.Rotate(new Vector3(0, 0, 0));
            }
            currentPosition = points[pointSelect];
        }
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            boss_health.SetActive(false);
        }
    }

    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            enemyHealth -= 2;
            setHealth(enemyHealth);
        }
        if (other.gameObject.tag == "Player" && Dash.Dashing == true)
        {
            enemyHealth -= 1;
            setHealth(enemyHealth);
        }
    }

    private void setHealth(int health)
    {
            slider.value = health;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.Rotate(new Vector3(0, 180, 0));
            sR.color = Color.red;
           // speed = 3f;
        }
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public GameObject _dashAbility;
    public GameObject _enemy;
    public float moveSpeed;
    public Transform currentPosition;
    public Transform[] points;
    public int pointSelect;
    public int health = 3;
    public Animator anim;
    private HealthManager _healthManager;
    private SpriteRenderer mySR;
    private GameObject player;
    private Collider2D enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        mySR = GetComponentInChildren<SpriteRenderer>();
        currentPosition = points[pointSelect];
        anim = GetComponent<Animator>();
        _healthManager = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, currentPosition.position,
            moveSpeed * Time.deltaTime);

        if (_enemy.transform.position == currentPosition.position)
        {
            pointSelect++;
            mySR.flipX = true;
            if (pointSelect == points.Length)
            {
                pointSelect = 0;
                mySR.flipX = false;
            }
            currentPosition = points[pointSelect];
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EnemyHealth();
            anim.SetBool("canAttack",true);
           // _healthManager.HurtPlayer();
            anim.SetBool("canAttack",false);
            /*Debug.Log(("Dash"));*/
        }
    }

    public void EnemyHealth()
    {
        health = health - 1;
        if (health == 0)
        {
            Destroy(gameObject);
            _dashAbility.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "invisHero" || collision.gameObject.tag =="Hero_enemy1" ||collision.gameObject.tag =="Hero_enemy2")
        {
            Physics.IgnoreCollision(player.GetComponent<Collider>(),GetComponent<Collider>());
        }

        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bullet")
        {
            EnemyHealth();
        }
    }
}

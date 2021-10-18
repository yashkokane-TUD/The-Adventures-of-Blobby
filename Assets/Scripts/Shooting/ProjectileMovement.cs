using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private float projectileSpeed;
    //private Enemy Enemy;
    public Rigidbody2D rbody;
        
        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject, 2f);
        }
        // Update is called once per frame
        void Update()
        {
            rbody.velocity = projectileSpeed * transform.right;
            
            //transform.Translate(transform.right * projectileSpeed * Time.deltaTime,Space.World);
        }
        /*private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                //Debug.Log("hit");
                Enemy.EnemyHealth();
            }
        }*/
}

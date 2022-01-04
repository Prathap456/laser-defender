using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float bulletSpeed;
    

    //void Start()
    //{

    //}

    void Update()
    {
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            
            print("Bullet Collision");
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}


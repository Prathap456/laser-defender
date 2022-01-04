using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public GameObject bullet;
    public float offset;
    public int count = 7;
    public float time = 0.3f;
    public Slider healthbar;
    public SoundManager musicSource;
    
    void Start()
    {
        
    }

    void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(HorizontalInput * Time.deltaTime * speed, 0, 0);
        Vector2 MaxPosition = new Vector2(8.0f, transform.position.y);
        Vector2 MinPosition = new Vector2(-8.0f, transform.position.y);
        if (transform.position.x > 8.0f)
        {
            transform.position = MaxPosition;
        }
        else if (transform.position.x < -8.0f)
        {
            transform.position = MinPosition;
        }

        FireBullet();
        if (Input.GetKeyDown(KeyCode.R))
        {
            count = 7;
        }

        Vector3 sliderpos = Camera.main.WorldToScreenPoint(this.transform.position);
        healthbar.transform.position = sliderpos + new Vector3(0, -35.0f, 0);
    }

    private void FireBullet()
    {
        if (Input.GetKeyDown(KeyCode.Space)  && time >= 0.2f)
        {
            musicSource.Play("fire");
            bullet.transform.position = new Vector3(transform.position.x, transform.position.y + offset, 0);
            Instantiate(bullet, bullet.transform.position, Quaternion.identity);
            GameObject astrobj = ObjectPooler.singleTon.GetSpawnObj("Bullet");
            count--;
            if (astrobj != null)
            {
                print("Spacebar pressed");
               
                astrobj.SetActive(true);
                astrobj.transform.position = this.transform.position;
            }
            time = 0;
        }
        time = time + Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Enemy")
        {
            healthbar.value -= 0.5f; ;
            if (healthbar.value <= 0)
            {
                musicSource.Play("death");
             
                
                Destroy(healthbar.gameObject, 1.0f);
                Destroy(gameObject);
            }
        }

    }
}

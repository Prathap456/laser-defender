using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemymovements : MonoBehaviour
{
    public float speed = 0.5f;
    public int scorevalue = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Boundary")
        {
            gameObject.SetActive(false);
            PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
            playerMovement.healthbar.value -= 0.1f;
            if (playerMovement.healthbar.value <= 0)
            {
                SceneManager.LoadScene(0);
            }

        }
        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}

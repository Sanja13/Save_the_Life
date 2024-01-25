using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float rotationSpeed;
    [SerializeField] public GameObject dust;

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(collision.gameObject);

            GameManager.instance.GameOver();
        }
        else if(collision.tag == "Ground")
        {
            GameManager.instance.IncrementScore();

            gameObject.SetActive(false);
            GameObject dustEffect = Instantiate(dust, transform.position,Quaternion.identity);
            
            Destroy(dustEffect, 1f);
            Destroy(gameObject, 2f);
        }
    }
}

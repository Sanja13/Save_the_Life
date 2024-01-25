using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    Vector2 newPosition;
    private float xInput;
    public float moveSpeed;
    public float xPositionLimit;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        // sekogas dava vrednost od -1 i +1, ako stiskame leva strelka imame vrednost pomala od 0
        //obratno pogolema od 0
        xInput = Input.GetAxis("Horizontal");

        newPosition = transform.position;
        newPosition.x += xInput * moveSpeed;


        newPosition.x = Mathf.Clamp(newPosition.x, -xPositionLimit, xPositionLimit);
        rb.MovePosition(newPosition);
    }

}

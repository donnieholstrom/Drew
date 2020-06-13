using System;
using UnityEngine;

public class AlternateMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector2 movement;
    private Vector3 right;
    private Vector3 left;

    public float moveSpeed;

    [NonSerialized]
    public bool allowMovement = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.AddForce(movement * moveSpeed * Time.fixedDeltaTime);
    }
}
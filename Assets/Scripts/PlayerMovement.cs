using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector2 movement;
    private Vector3 right;
    private Vector3 left;

    public float moveSpeed;

    [NonSerialized]
    public bool allowMovement = true;

    public GameObject head;
    public GameObject body;

    private SortingGroup headGroup;
    private SortingGroup bodyGroup;

    public GameObject face;
    public GameObject headColor;
    public GameObject headOutline;

    public GameObject bodyColor;
    public GameObject bodyOutline;
    public GameObject shoeColor;

    private SpriteRenderer faceRenderer;
    private SpriteRenderer headColorRenderer;
    private SpriteRenderer headOutlineRenderer;

    private SpriteRenderer bodyColorRenderer;
    private SpriteRenderer bodyOutlineRenderer;
    private SpriteRenderer shoeColorRenderer;

    public bool interacting;

    private bool moving;

    private void Awake()
    {
        interacting = false;

        rb = GetComponent<Rigidbody2D>();

        right = new Vector3(rb.transform.localScale.x, rb.transform.localScale.y, rb.transform.localScale.z);
        left = new Vector3(-rb.transform.localScale.x, rb.transform.localScale.y, rb.transform.localScale.z);

        headGroup = head.GetComponent<SortingGroup>();
        bodyGroup = body.GetComponent<SortingGroup>();

        faceRenderer = face.GetComponent<SpriteRenderer>();
        headColorRenderer = headColor.GetComponent<SpriteRenderer>();
        headOutlineRenderer = headOutline.GetComponent<SpriteRenderer>();

        bodyColorRenderer = bodyColor.GetComponent<SpriteRenderer>();
        bodyOutlineRenderer = bodyOutline.GetComponent<SpriteRenderer>();
        shoeColorRenderer = shoeColor.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (!moving)
        {
            return;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (interacting) return;

        if (context.started)
        {
            moving = true;
        }

        if (context.canceled)
        {
            moving = false;
        }

        rb.AddForce(movement * moveSpeed * Time.fixedDeltaTime);

        UpdateSpriteLayers();
    }

    private void UpdateSpriteLayers()
    {
        if (rb.velocity == Vector2.zero)
        {
            return;
        }

        if (rb.velocity.x >= 0.2f)
        {
            rb.transform.localScale = right;
        }

        else if (rb.velocity.x <= -0.2f)
        {
            rb.transform.localScale = left;
        }

        if (rb.velocity.y >= 0.2f)
        {
            headGroup.sortingOrder = 1;
            bodyGroup.sortingOrder = 2;

            faceRenderer.sortingOrder = -1;
            headColorRenderer.sortingOrder = 0;
            headOutlineRenderer.sortingOrder = 1;

            bodyColorRenderer.sortingOrder = 2;
            bodyOutlineRenderer.sortingOrder = 3;
            shoeColorRenderer.sortingOrder = 2;
        }

        else if (rb.velocity.y <= -0.2f)
        {
            headGroup.sortingOrder = 2;
            bodyGroup.sortingOrder = 1;

            faceRenderer.sortingOrder = 3;
            headColorRenderer.sortingOrder = 1;
            headOutlineRenderer.sortingOrder = 2;

            bodyColorRenderer.sortingOrder = -1;
            bodyOutlineRenderer.sortingOrder = 0;
            shoeColorRenderer.sortingOrder = -1;
        }
    }
}
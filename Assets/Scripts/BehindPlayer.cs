using UnityEngine;

public class BehindPlayer : MonoBehaviour
{
    private GameObject player;
    private SpriteRenderer render;

    public float yOffset = 0f;

    public bool needsXOffset = false;
    public float xOffset = 0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        render = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        switch (needsXOffset)
        {
            case false:

                if (player.transform.position.y > transform.position.y + yOffset)
                {
                    render.color = new Color(255, 255, 255, 255);
                }

                else
                {
                    render.color = new Color(255, 255, 255, 0);
                }

                break;

            case true:

                if ((player.transform.position.y > transform.position.y + yOffset) && (player.transform.position.x > transform.position.x + xOffset))
                {
                    render.color = new Color(255, 255, 255, 255);
                }

                else
                {
                    render.color = new Color(255, 255, 255, 0);
                }

                break;
        }
    }
}
using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Fairy fairy;
    private Interactive interactive;
    private PlayerMovement playerMovement;

    public GameObject mainDialogueBox;
    public TextMeshProUGUI mainDialogueBoxText;

    private UIBox mainDialogueUIBox;

    private GameObject currentInteractive;

    private bool available;
    private bool interacting;


    private void Awake()
    {
        fairy = GameObject.FindGameObjectWithTag("Fairy").GetComponent<Fairy>();

        playerMovement = GetComponent<PlayerMovement>();

        available = true;

        mainDialogueUIBox = mainDialogueBox.GetComponent<UIBox>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactive") && available == true)
        {
            currentInteractive = collision.gameObject;

            fairy.HoverOnObject(collision.transform);

            available = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (available == true || currentInteractive == null)
        {
            return;
        }

        if (collision.gameObject == currentInteractive)
        {
            currentInteractive = null;

            fairy.FollowPlayer();

            available = true;
        }
    }

    private void Update()
    {
        if (currentInteractive == null)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            interactive = currentInteractive.GetComponent<Interactive>();

            if (interacting == false)
            {
                Interact(interactive);
            }

            else
            {
                if (interactive.thisInteractiveType == Interactive.InteractiveType.Object)
                {
                    mainDialogueUIBox.HideBox();
                    interacting = false;
                    playerMovement.interacting = false;
                }
            }
        }
    }

    private void Interact(Interactive _interactive)
    {
        mainDialogueBoxText.text = _interactive.description;
        mainDialogueUIBox.ShowBox();
        interacting = true;
        playerMovement.interacting = true;
    }
}
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

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
        if (!collision.CompareTag("Interactive") || available != true)
        {
            return;
        }

        currentInteractive = collision.gameObject;

        fairy.HoverOnObject(collision.transform);

        available = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (available || currentInteractive == null || collision.gameObject != currentInteractive)
        {
            return;
        }

        currentInteractive = null;

        fairy.FollowPlayer();

        available = true;
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            return;
        }

        interactive = currentInteractive.GetComponent<Interactive>();

        if (interacting == false)
        {
            InteractWith(interactive);
        }

        else
        {
            if (interactive.thisInteractiveType != Interactive.InteractiveType.Object) return;

            mainDialogueUIBox.HideBox();
            interacting = false;
            playerMovement.interacting = false;
        }
    }

    private void InteractWith(Interactive _interactive)
    {
        mainDialogueBoxText.text = _interactive.description;
        mainDialogueUIBox.ShowBox();
        interacting = true;
        playerMovement.interacting = true;
    }
}
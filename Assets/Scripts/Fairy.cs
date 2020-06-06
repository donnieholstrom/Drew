using System.Threading;
using UnityEngine;

public class Fairy : MonoBehaviour
{
    public float speed;
    public float distanceToStop;

    private Transform playerAttachPoint;
    private Transform target;

    private Rigidbody2D rb;
    private Vector3 direction;

    public enum FairyState
    {
        FollowingPlayer,
        HoveringOnObject
    }

    private FairyState fairyState;

    private void Awake()
    {
        playerAttachPoint = GameObject.FindGameObjectWithTag("FairyAttach").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        FollowPlayer();
    }

    private void FixedUpdate()
    {
        switch (fairyState)
        {
            case FairyState.FollowingPlayer:

                if (Vector3.Distance(transform.position, target.position) > distanceToStop)
                {
                    direction = target.position - transform.position;
                    rb.AddRelativeForce(direction.normalized * speed * Time.deltaTime, ForceMode2D.Force);
                }

                break;

            case FairyState.HoveringOnObject:

                if (Vector3.Distance(transform.position, target.position) > distanceToStop)
                {
                    direction = target.position - transform.position;
                    rb.AddRelativeForce(direction.normalized * speed * Time.deltaTime, ForceMode2D.Force);
                }

                break;
        }
    }

    public void FollowPlayer()
    {
        target = playerAttachPoint;
        fairyState = FairyState.FollowingPlayer;
    }

    public void HoverOnObject(Transform _target)
    {
        target = _target;
        fairyState = FairyState.HoveringOnObject;
    }
}
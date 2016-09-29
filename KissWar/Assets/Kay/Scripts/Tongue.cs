using UnityEngine;
using System.Collections;

public class Tongue : MonoBehaviour
{
    public enum TongueSide
    {
        Left,
        Right
    }

    public TongueSide tongueSide;

    public bool bridgeIsUp = false;
    [SerializeField]
    private bool changingBridgeStance = false;


    [Header("Distances")]
    public Vector3 distanceToMove;
    public Vector3 destination;
    public float timeToReachDestination;

    [Header("Timing")]
    [Tooltip("The time the tongues stay up, so the characters CAN cross the bridge")]
    public float timeUp;
    private float currentTimeUp;

    [Tooltip("The time the tongues stay down, so the characters CANT cross the bridge")]
    public float timeDown;
    private float currentTimeDown;


	// Use this for initialization
	void Start ()
    {
        currentTimeUp = timeUp;
        currentTimeDown = timeDown;

        if (tongueSide.Equals(TongueSide.Left))
        {
            if (bridgeIsUp)
            {
                destination = transform.position - distanceToMove;
            }
            else if (!bridgeIsUp)
            {
                destination = transform.position + distanceToMove;
            }
        }
        else if (tongueSide.Equals(TongueSide.Right))
        {
            if (bridgeIsUp)
            {
                destination = transform.position + distanceToMove;
            }
            else if (!bridgeIsUp)
            {
                destination = transform.position - distanceToMove;
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (changingBridgeStance)
        {
            if (bridgeIsUp)
            {
                if (tongueSide.Equals(TongueSide.Left))
                {
                    if (transform.position.x > destination.x)
                    {
                        transform.Translate((transform.right / timeToReachDestination) * Time.deltaTime);
                    }
                    else
                    {
                        destination = transform.position + distanceToMove;
                        changingBridgeStance = false;
                        bridgeIsUp = false;
                    }
                }
                else if (tongueSide.Equals(TongueSide.Right))
                {
                    if (transform.position.x < destination.x)
                    {
                        transform.Translate((-transform.right / timeToReachDestination) * Time.deltaTime);
                    } 
                    else
                    {
                        destination = transform.position - distanceToMove;
                        changingBridgeStance = false;
                        bridgeIsUp = false;
                    }
                }
            }
            else if (!bridgeIsUp)
            {
                if (tongueSide.Equals(TongueSide.Left))
                {
                    if (transform.position.x < destination.x)
                    {
                        transform.Translate((-transform.right / timeToReachDestination) * Time.deltaTime);
                    }
                    else
                    {
                        destination = transform.position - distanceToMove;
                        changingBridgeStance = false;
                        bridgeIsUp = true;
                    }
                }
                else if (tongueSide.Equals(TongueSide.Right))
                {
                    if (transform.position.x > destination.x)
                    {
                        transform.Translate((transform.right / timeToReachDestination) * Time.deltaTime);
                    }
                    else
                    {
                        destination = transform.position + distanceToMove;
                        changingBridgeStance = false;
                        bridgeIsUp = true;
                    }
                }
            }
        }
        else if (!changingBridgeStance)
        {
            if (bridgeIsUp)
            {
                currentTimeUp -= Time.deltaTime;
                if (currentTimeUp < 0)
                {
                    changingBridgeStance = true;
                    currentTimeDown = timeDown;
                }
            }
            else if (!bridgeIsUp)
            {
                currentTimeDown -= Time.deltaTime;
                if (currentTimeDown < 0)
                {
                    changingBridgeStance = true;
                    currentTimeUp = timeUp;
                }
            }
        }
	}
}

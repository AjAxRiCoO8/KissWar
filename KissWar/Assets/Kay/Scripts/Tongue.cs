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
    
    public bool bridgeIsUp = true;
    private bool changingBridgeStance = false;

    [Header("Distances")]
    public Vector3 distanceToMove;
    private Vector3 destination;
    public float timeToReachDestination;

    [Header("Timing")]
    public float timeUp;
    public float timeDown;

    private float currentTimeUp;
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

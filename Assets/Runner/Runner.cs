using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {

    public static float distanceTraveled;

    public float acceleration;

    public Vector3 jumpVelocity;

    public float gameOverY;

    private bool touchingPlatform;


    void Update () {
        if (touchingPlatform && Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody>().AddForce(jumpVelocity, ForceMode.VelocityChange);
            touchingPlatform = false;
        }
        distanceTraveled = transform.localPosition.x;

        if (transform.localPosition.y < gameOverY)
        {
            GameEventManager.TriggerGameOver();
        }
	}

    void FixedUpdate()
    {
        if (touchingPlatform)
        {
            GetComponent<Rigidbody>().AddForce(acceleration, 0f, 0f, ForceMode.Acceleration);
        }
    }

    void OnCollisionEnter ()
    {
        touchingPlatform = true;
    }

    void OnCollisionExit ()
    {
        touchingPlatform = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour {

    private Rigidbody2D rigidbodyRef;
    private const float THRUST = 5.0f;
    private const float ROTATION_SPEED = 1.0f;

    // Use this for initialization
    void Start () {
        rigidbodyRef = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("up"))
        {
            rigidbodyRef.AddRelativeForce(THRUST * Vector2.up);
        }
        else if (Input.GetKey("down"))
        {
            rigidbodyRef.AddRelativeForce(THRUST * Vector2.down);
        }

        if (Input.GetKey("left"))
        {
            transform.eulerAngles = new Vector3(0.0f, 0.0f, transform.eulerAngles.z + ROTATION_SPEED);
        }
        else if (Input.GetKey("right"))
        {
            transform.eulerAngles = new Vector3(0.0f, 0.0f, transform.eulerAngles.z - ROTATION_SPEED);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -SceneController.X_MIN_MAX, SceneController.X_MIN_MAX), Mathf.Clamp(transform.position.y, -SceneController.Y_MIN_MAX, SceneController.Y_MIN_MAX), 0.0f);
    }
}

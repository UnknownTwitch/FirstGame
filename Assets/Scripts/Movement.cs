using UnityEngine;
using System.Collections;

// This script moves the character controller forward
// and sideways based on the arrow keys.
// It also jumps when pressing space.
// Make sure to attach a character controller to the same game object.
// It is recommended that you make only one call to Move or SimpleMove per frame.

public class Movement : MonoBehaviour
{

    Vector3 movement;
    public float speed = 20f;
    int floorMask;
    float camRayLength = 1000f;
    Rigidbody playerRigidbody;

    private Vector3 moveDirection = Vector3.zero;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw ("Horizontal");
        float v = Input.GetAxisRaw ("Vertical");

        Move(h,v);
        Turning();
    }

    void Move (float h, float v)
    {
        movement.Set (h, 0f, v);

        movement = movement.normalized * speed * Time.deltaTime;

        playerRigidbody.MovePosition (transform.position + movement);

    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorhit;

        if (Physics.Raycast (camRay, out floorhit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorhit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            playerRigidbody.MoveRotation(newRotation);
        }
    }
}
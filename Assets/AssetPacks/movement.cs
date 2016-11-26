using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour
{
    public float speed;

    Vector3 targetDirection;
    Quaternion targetRotation;
    float horizontal;
    float vertical;
    Rigidbody rb;

    public static bool canMove;
    public static bool canRotate;

    void Start()
    {
        canMove = true;
        canRotate = true;
        rb = GetComponent<Rigidbody>();
    }

	void Update ()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        
        targetDirection = new Vector3(horizontal, 0f, vertical);

        if (targetDirection != Vector3.zero)
        {
            if(canRotate)
            {
                targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
                transform.rotation = targetRotation;
            }
        }

        if (horizontal != 0 || vertical != 0)
        {
            if (canMove)
                rb.AddForce(new Vector3(horizontal * speed, 0, vertical * speed), ForceMode.VelocityChange);
            // transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}

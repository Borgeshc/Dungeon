using UnityEngine;
using System.Collections;
using InControl;

public class movement : MonoBehaviour
{
    public float speed;

    Vector3 targetDirection;
    Quaternion targetRotation;
    float horizontal;
    float vertical;
    float horizontal2;
    float vertical2;
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
        var inputDevice = InputManager.ActiveDevice;

        horizontal = inputDevice.LeftStickX;
        vertical = inputDevice.LeftStickY;

        horizontal2 = inputDevice.RightStickX;
        vertical2 = inputDevice.RightStickY;

        print("LeftStickX " + horizontal);
        print("LeftStickY " + vertical);

        print("RightStickX " + horizontal2);
        print("RightStickY " + vertical2);
        targetDirection = new Vector3(0f, horizontal2, vertical);

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

using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour
{
    [Tooltip("This is the target that the gameobject will follow.")]
    public GameObject target;
    [Tooltip("This is how fast the gameobject will follow the target.")]
    public float speed;

    void Update()
    {
        transform.LookAt(target.transform);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}

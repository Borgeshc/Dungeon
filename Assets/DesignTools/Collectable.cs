using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour
{
    //This script requires a collider

    [Tooltip("The object you want to be a collectable.")]
    public GameObject collectable;

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}

using UnityEngine;
using System.Collections;

public class SpawnArrow : MonoBehaviour
{
    public GameObject arrow;

    void OnEnable()
    {
        Instantiate(arrow, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }
}

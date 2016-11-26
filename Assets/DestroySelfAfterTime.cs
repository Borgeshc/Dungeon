using UnityEngine;
using System.Collections;

public class DestroySelfAfterTime : MonoBehaviour
{
    public float destructTime;
	void Update ()
    {
        Destroy(gameObject, destructTime);
	}
}

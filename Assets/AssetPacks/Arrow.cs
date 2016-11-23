using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour
{
    public int speed;

	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}
}

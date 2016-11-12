using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    public GameObject arrow;
    public GameObject spawnPoint;

	// Use this for initialization
	void OnEnable ()
    {
        Instantiate(arrow, spawnPoint.transform.position, spawnPoint.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

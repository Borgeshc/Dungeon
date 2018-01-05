using UnityEngine;
using System.Collections;

public class ActivateObjectAfterSeconds : MonoBehaviour
{
    public GameObject objToActivate;
    public float activateAfter;
    public float turnOffAfter;
    
	void Start () {
        StartCoroutine(ActivateObject());
	}

    IEnumerator ActivateObject()
    {
        yield return new WaitForSeconds(activateAfter);
        objToActivate.SetActive(true);
        yield return new WaitForSeconds(turnOffAfter);
        objToActivate.SetActive(false);
    }
}

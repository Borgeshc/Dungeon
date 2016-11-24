using UnityEngine;
using System.Collections;

public class ClassChosen : MonoBehaviour
{
    public GameObject warriorClass;
    public GameObject berserkerClass;
    public GameObject archerClass;
    public GameObject mageClass;

    public GameObject playerSpawnpoint;

	void Start ()
    {
	    switch(ChooseClass.classChosen)
        {
            case 1:
                Instantiate(warriorClass, playerSpawnpoint.transform.position, playerSpawnpoint.transform.rotation);
                break;
            case 2:
                Instantiate(berserkerClass, playerSpawnpoint.transform.position, playerSpawnpoint.transform.rotation);
                break;
            case 3:
                Instantiate(archerClass, playerSpawnpoint.transform.position, playerSpawnpoint.transform.rotation);
                break;
            case 4:
                Instantiate(mageClass, playerSpawnpoint.transform.position, playerSpawnpoint.transform.rotation);
                break;
        }
	}
}

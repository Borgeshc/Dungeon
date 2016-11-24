using UnityEngine;
using System.Collections;

public class FurnaceRoom : MonoBehaviour
{
    public GameObject[] furnaces;
    public int spawnFires;
    int chosenFire1;
    int chosenFire2;
    int chosenFire3;

    int switchInt;

	void Update ()
    {
	    if((int)Time.time % spawnFires == 0 && Time.time != 0)
        {

            chosenFire1 = Random.Range(0, furnaces.Length);
            do
            {
                chosenFire2 = Random.Range(0, furnaces.Length);
            } while (chosenFire2 == chosenFire1);
            do
            {
                chosenFire3 = Random.Range(0, furnaces.Length);
            } while (chosenFire2 == chosenFire3);

            print("Chosen1 " + chosenFire1);
            print("Chosen2 " + chosenFire2);
            print("Chosen3 " + chosenFire3);

        }
	}
}

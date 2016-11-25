using UnityEngine;
using System.Collections;

public class SpawnSubAbility : MonoBehaviour
{
    public GameObject ability;
    public GameObject runeSpawn;
    public float spawnAfter;

    void OnEnable () {
        StartCoroutine(SpawnAbility());
	}
	
    IEnumerator SpawnAbility()
    {
        yield return new WaitForSeconds(spawnAfter);
        Instantiate(ability, runeSpawn.transform.position, runeSpawn.transform.rotation);
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KillCount : MonoBehaviour {
    public Text killCount;

    int score;
	public void UpdateScore ()
    {
        score++;
        killCount.text = "Kill Count: " + score;
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChooseClass : MonoBehaviour
{
    public static int classChosen;

    public void Warrior()
    {
        classChosen = 1;
        SceneManager.LoadScene("Game");
    }

    public void Berserker()
    {
        classChosen = 2;
        SceneManager.LoadScene("Game");
    }

    public void Archer()
    {
        classChosen = 3;
        SceneManager.LoadScene("Game");
    }
}

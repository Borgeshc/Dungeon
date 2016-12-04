using UnityEngine;
using System.Collections;

public class Tornado : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed; 
    float speed;
    int direction;

    void Start()
    {
        StartCoroutine(DirectionTimer());
    }
    void Update()
    {
        switch(direction)
        {
            case 0:
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                break;
            case 1:
                transform.Translate(Vector3.back * speed * Time.deltaTime);
                break;
            case 2:
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                break;
            case 3:
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                break;
        }
    }

    IEnumerator DirectionTimer()
    {

        direction = 0;
        speed = Random.Range(minSpeed, maxSpeed);
        yield return new WaitForSeconds(1);

        direction = Random.Range(0, 3);
        speed = Random.Range(minSpeed, maxSpeed);
        yield return new WaitForSeconds(2);

        direction = Random.Range(0, 3);
        speed = Random.Range(minSpeed, maxSpeed);
        yield return new WaitForSeconds(2);

        direction = Random.Range(0, 3);
        speed = Random.Range(minSpeed, maxSpeed);
        yield return new WaitForSeconds(2);

        direction = Random.Range(0, 3);
        speed = Random.Range(minSpeed, maxSpeed);
        yield return new WaitForSeconds(2);
    }
}

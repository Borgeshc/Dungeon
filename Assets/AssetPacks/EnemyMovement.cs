using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float attackRange;

    GameObject player;
    int attackType;
    Animator anim;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
	}
	
	void Update ()
    {
        if(player != null)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < attackRange)
            {
                attackType = Random.Range(0, 2);
                switch (attackType)
                {
                    case 0:
                        anim.SetBool("Attack1", true);
                        StartCoroutine(WaitForBoolChange(0));
                        break;
                    case 1:
                        anim.SetBool("Attack2", true);
                        StartCoroutine(WaitForBoolChange(1));
                        break;
                    case 2:
                        anim.SetBool("Attack3", true);
                        StartCoroutine(WaitForBoolChange(2));
                        break;
                }
            }
            else
            {
                transform.LookAt(player.transform);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);

                anim.SetBool("Attack1", false);
                anim.SetBool("Attack2", false);
                anim.SetBool("Attack3", false);
            }

        }
	}

    IEnumerator WaitForBoolChange(int attack)
    {
        yield return new WaitForSeconds(1);
        switch(attack)
        {
            case 0:
                anim.SetBool("Attack1", false);
                break;
            case 1:
                anim.SetBool("Attack2", false);
                break;
            case 2:
                anim.SetBool("Attack3", false);
                break;
        }
    }
}

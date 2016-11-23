 /// <summary>
/// 
/// </summary>

using UnityEngine;
using System;
using System.Collections;
  
[RequireComponent(typeof(Animator))]  

//Name of class must be name of file as well

public class LocomotionPlayer : MonoBehaviour {

    protected Animator animator;

    private float speed = 0;
    private float direction = 0;
    private Locomotion locomotion = null;
    private bool doneWaiting;

    Rigidbody rb;
    public BoxCollider meleeWeapon;

	void Start () 
	{
        animator = GetComponent<Animator>();
        locomotion = new Locomotion(animator);
        rb = GetComponent<Rigidbody>();
        meleeWeapon.enabled = false;
	}
    
	void Update () 
	{
        if (animator && Camera.main)
		{
            if(transform.tag == "Player")
            {
                JoystickToEvents.Do(transform, Camera.main.transform, ref speed, ref direction);
                locomotion.Do(speed * 6, direction * 180);

                if (Input.GetButtonDown("Fire1"))
                {
                    locomotion.Attack(1);
                    StartCoroutine(WaitToChangeBool(1));
                }
                if (Input.GetButtonDown("Fire2"))
                {
                    locomotion.Attack(2);
                    StartCoroutine(WaitToChangeBool(2));
                }
                if (Input.GetButtonDown("Fire3"))
                {
                    locomotion.Attack(3);
                    StartCoroutine(WaitToChangeBool(3));
                }
            }
            else
            {
                //Enemy movement 
            }
        }		
	}


    IEnumerator WaitToChangeBool(int attackType)
    {

        meleeWeapon.enabled = true;
        yield return new WaitForSeconds(1f);
        locomotion.StopAttack(attackType);
        meleeWeapon.enabled = false;
    }

}

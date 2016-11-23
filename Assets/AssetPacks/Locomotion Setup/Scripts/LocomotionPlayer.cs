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
    public GameObject gunBarrel;
    public GameObject aimShadow;
    bool isUsingBow;
    bool canShoot;

	void Start () 
	{
        animator = GetComponent<Animator>();
        locomotion = new Locomotion(animator);
        rb = GetComponent<Rigidbody>();
        if (meleeWeapon != null)
            meleeWeapon.enabled = false;
        else
        {
            gunBarrel.SetActive(false);
            aimShadow.SetActive(false);
            isUsingBow = true;
            canShoot = true;
        }
	}
    
	void Update () 
	{
        if (animator && Camera.main)
		{
            if(transform.tag == "Player")
            {
                JoystickToEvents.Do(transform, Camera.main.transform, ref speed, ref direction);
                locomotion.Do(speed * 6, direction * 180);

                if (isUsingBow)
                {
                    if (Input.GetButtonDown("Fire1"))
                    {
                        movement.canMove = false;
                        aimShadow.SetActive(true);
                    }
                    if (Input.GetButtonUp("Fire1") && canShoot)
                    {
                        canShoot = false;
                        locomotion.Attack(1);
                        StartCoroutine(WaitToChangeBool(1));
                        StartCoroutine(ShootArrow());
                    }
                }
                else
                {
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

                    else
                    {
                        //Enemy movement 
                    }

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
                    else
                    {
                        //Enemy movement 
                    }
                }
            }
        }		
	}


    IEnumerator WaitToChangeBool(int attackType)
    {
        if(meleeWeapon != null)
            meleeWeapon.enabled = true;

        yield return new WaitForSeconds(1f);
        locomotion.StopAttack(attackType);

        if (meleeWeapon != null)
            meleeWeapon.enabled = false;
    }

    IEnumerator ShootArrow()
    {
        yield return new WaitForSeconds(.7f);
        gunBarrel.SetActive(true);
        movement.canMove = true;
        aimShadow.SetActive(false);
        yield return new WaitForSeconds(.8f);
        canShoot = true;
    }

}

using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))]

//Name of class must be name of file as well

public class Berserker : MonoBehaviour
{

    protected Animator animator;

    private float speed = 0;
    private float direction = 0;
    private Locomotion locomotion = null;
    private bool doneWaiting;

    Rigidbody rb;
    public GameObject ability1;
    public GameObject ability2;
    public GameObject ability3;

    public float cancelAnimAt1;
    public float cancelAnimAt2;
    public float cancelAnimAt3;

    public float abilityLifetime1;
    public float abilityLifetime2;
    public float abilityLifetime3;

    public float ability1WaitTime;
    public float ability2WaitTime;
    public float ability3WaitTime;

    public float ability1Cooldown;
    public float ability2Cooldown;
    public float ability3Cooldown;

    bool canShoot;
    bool canCastAbility1;
    bool canCastAbility2;
    bool canCastAbility3;

    void Start()
    {
        animator = GetComponent<Animator>();
        locomotion = new Locomotion(animator);
        rb = GetComponent<Rigidbody>();
        canShoot = true;
        canCastAbility1 = true;
        canCastAbility2 = true;
        canCastAbility3 = true;
    }

    void Update()
    {
        if (animator && Camera.main)
        {
            if (transform.tag == "Player")
            {
                JoystickToEvents.Do(transform, Camera.main.transform, ref speed, ref direction);
                locomotion.Do(speed * 6, direction * 180);
                
                if (Input.GetButtonDown("Fire1") && canCastAbility1)
                {
                    if(ability1 != null)
                    {
                        locomotion.Attack(1);

                        StartCoroutine(WaitToUseAbility(ability1WaitTime, ability1));
                        StartCoroutine(AbilityLifeTime(abilityLifetime1, ability1));
                        StartCoroutine(AbilityCooldown(ability1Cooldown, 1));
                    }

                    StartCoroutine(CancelAnim(1, cancelAnimAt1));
                }

                if (Input.GetButtonDown("Fire2") && canCastAbility3)
                {
                    locomotion.Attack(3);

                    if (ability3 != null)
                    {
                        locomotion.Attack(3);
                        StartCoroutine(WaitToUseAbility(ability3WaitTime, ability3));
                        movement.canMove = false;
                        StartCoroutine(AbilityLifeTime(abilityLifetime3, ability3));
                        StartCoroutine(AbilityCooldown(ability3Cooldown, 3));
                    }

                    StartCoroutine(CancelAnim(3, cancelAnimAt3));
                }

                if (Input.GetButtonDown("Fire3") && canCastAbility2)
                {
                    locomotion.Attack(2);

                    if (ability2 != null)
                    {
                        StartCoroutine(WaitToUseAbility(ability2WaitTime, ability2));
                        movement.canRotate = false;
                        movement.canMove = false;
                        StartCoroutine(AbilityLifeTime(abilityLifetime2, ability2));
                        StartCoroutine(AbilityCooldown(ability2Cooldown, 2));
                    }

                    StartCoroutine(CancelAnim(2, cancelAnimAt2));
                }
            }
        }
    }


    IEnumerator CancelAnim(int attackType, float cancelAnimAt)      //Stops the animation at time
    {

        yield return new WaitForSeconds(cancelAnimAt);
        locomotion.StopAttack(attackType);
    }
    IEnumerator AbilityCooldown(float cooldown, int abilityToCooldown)
    {
        switch (abilityToCooldown)
        {
            case 1:
                canCastAbility1 = false;
                yield return new WaitForSeconds(cooldown);
                canCastAbility1 = true;
                break;

            case 2:
                canCastAbility2 = false;
                yield return new WaitForSeconds(cooldown);
                canCastAbility2 = true;
                break;

            case 3:
                canCastAbility3 = false;
                yield return new WaitForSeconds(cooldown);
                canCastAbility3 = true;
                break;
        }
    }

    IEnumerator WaitToUseAbility(float waitTime, GameObject ability)    //Lets the animation play for time before executing ability
    {
        yield return new WaitForSeconds(waitTime);
            ability.SetActive(true);
    }

    IEnumerator AbilityLifeTime(float lifeTime, GameObject usedAbility) //shuts off ability after time
    {
        yield return new WaitForSeconds(lifeTime);
        usedAbility.SetActive(false);

        movement.canMove = true;
        movement.canRotate = true;
    }

}



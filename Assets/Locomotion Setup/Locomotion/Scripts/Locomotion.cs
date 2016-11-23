using UnityEngine;
using System.Collections;

public class Locomotion
{
    private Animator m_Animator = null;
    
    private int m_SpeedId = 0;

    public float m_SpeedDampTime = 0.1f;
    
    public Locomotion(Animator animator)
    {
        m_Animator = animator;

        m_SpeedId = Animator.StringToHash("Speed");
    }

    public void Do(float speed, float direction)
    {
        AnimatorStateInfo state = m_Animator.GetCurrentAnimatorStateInfo(0);

        bool inTransition = m_Animator.IsInTransition(0);
        bool inIdle = state.IsName("Locomotion.Idle");
        bool inWalkRun = state.IsName("Locomotion.WalkRun");

        float speedDampTime = inIdle ? 0 : m_SpeedDampTime;
        
        m_Animator.SetFloat(m_SpeedId, speed, speedDampTime, Time.deltaTime);
    }	

    public void Attack(int attackType)
    {
        switch(attackType)
        {
            case 1:
                m_Animator.SetBool("Attack1", true);
                break;
            case 2:
                m_Animator.SetBool("Attack2", true);
                break;
            case 3:
                m_Animator.SetBool("Attack3", true);
                break;
        }
    }

    public void StopAttack(int attack)
    {
        switch (attack)
        {
            case 1:
                m_Animator.SetBool("Attack1", false);
                break;
            case 2:
                m_Animator.SetBool("Attack2", false);
                break;
            case 3:
                m_Animator.SetBool("Attack3", false);
                break;
        }
    }
}

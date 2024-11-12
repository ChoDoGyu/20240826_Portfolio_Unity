using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateDie : FSMSingleton<PlayerStateDie>, FSMState<PlayerManager>
{
    public void Enter(PlayerManager e)
    {
        e.m_isDie = true;
        e.m_aniManager.ParameterBool("Death", true);

    }
    public void Execute(PlayerManager e)
    {
        if(e.m_aniManager.m_animator.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            if(e.m_aniManager.m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
            {
                print("플레이어 죽었다.");
                e.gameObject.SetActive(false);
                
                //GameManager.Instance.IsDie();

            }
        }
    }
    public void Exit(PlayerManager e)
    {
        e.m_aniManager.ParameterBool("Death", false);
        e.m_isDie = false;
    }
}

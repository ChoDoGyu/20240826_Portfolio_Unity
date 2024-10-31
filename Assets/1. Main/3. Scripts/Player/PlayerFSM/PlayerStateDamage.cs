using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateDamage : FSMSingleton<PlayerStateDamage>, FSMState<PlayerManager>
{
    public void Enter(PlayerManager e)
    {
        print("플레이어 맞는다.");
        e.m_aniManager.ParameterBool("Damage", true);
    }
    public void Execute(PlayerManager e)
    {
        if (e.m_aniManager.m_animator.GetCurrentAnimatorStateInfo(0).IsName("Damage"))
        {
            if (e.m_aniManager.m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
            {
                if (e.m_hpManager.m_hp > 0)
                {
                    e.ChangeState(PlayerStateIdle.m_Inst);
                }
                else
                {
                    e.ChangeState(PlayerStateDie.m_Inst);
                }
                
            }
        }

    }
    public void Exit(PlayerManager e)
    {
        e.m_aniManager.ParameterBool("Damage", false);
    }
}

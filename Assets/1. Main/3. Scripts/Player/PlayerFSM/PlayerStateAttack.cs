using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerAttack;

public class PlayerStateAttack : FSMSingleton<PlayerStateAttack>, FSMState<PlayerManager>
{
    public void Enter(PlayerManager e)
    {
        print("PlayerStateAttack");
        e.m_move.m_agent.isStopped = true;
        e.m_attackCheck = true;
    }
    public void Execute(PlayerManager e)
    {
        if (e.m_moveCheck)
        {
            e.m_monsterController = null;
            e.m_attackCheck = false;
            e.ChangeState(PlayerStateChase.m_Inst);
        }
        else
        {
            if (e.m_attackAreaUnit.m_unitList.Count > 0)
            {
                e.m_move.Turn(e.m_monsterController.transform.position);
                
                if (Time.time > e.m_lastAttackTime + e.m_playerAttackDelay)
                {
                    e.m_aniManager.ParameterBool("DefaultAttack", true);
                    e.m_lastAttackTime = Time.time;
                }
                if (e.m_monsterController.m_isDie)
                {
                    if (e.m_attackAreaUnit.m_unitList.Count > 0)
                    {
                        e.m_monsterController = e.m_attackAreaUnit.m_unitList[0];
                    }
                }
            }
            else
            {
                e.m_monsterController = null;
                e.m_attackCheck = false;
                e.ChangeState(PlayerStateIdle.m_Inst);
            }
        }



    }
    public void Exit(PlayerManager e)
    {
        e.m_aniManager.ParameterBool("DefaultAttack", false);
    }
}

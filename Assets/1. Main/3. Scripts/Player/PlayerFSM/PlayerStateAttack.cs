using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateAttack : FSMSingleton<PlayerStateAttack>, FSMState<PlayerManager>
{
    public void Enter(PlayerManager e)
    {
        print("PlayerStateAttack");
        e.m_move.m_agent.isStopped = true;
    }
    public void Execute(PlayerManager e)
    {
        e.m_attackCheck = true;
        
        
        if (!e.CheckEnermy(e.m_monsterController))
        {
            e.ChangeState(PlayerStateIdle.m_Inst);
        }
        else
        {
            e.m_move.Turn(e.m_monsterController.transform.position);
            if (Time.time > e.m_lastAttackTime + e.m_playerAttackDelay)
            {
                print("playerAttack!!");
                for(int i = 0; i < e.m_attackAreaUnit.m_unitList.Count; i++)
                {
                    e.m_attackAreaUnit.m_unitList[i].m_hpManager.ReduceHp(e.m_playerAttackPoint);
                    e.m_attackAreaUnit.m_unitList[i].ChangeState(MonsterStateDamage.m_Inst);
                }
                
                e.m_lastAttackTime = Time.time;
            }
        }
        if (e.m_moveCheck)
        {
            e.ChangeState(PlayerStateChase.m_Inst);
        }

    }
    public void Exit(PlayerManager e)
    {
        e.m_monsterController = null;
        e.m_attackCheck = false;
        
        
    }
}

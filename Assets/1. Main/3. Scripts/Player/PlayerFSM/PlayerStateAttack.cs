using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateAttack : FSMSingleton<PlayerStateAttack>, FSMState<PlayerManager>
{
    public void Enter(PlayerManager e)
    {
        print("PlayerStateAttack");
        e.m_move.m_agent.stoppingDistance = e.m_attack.m_curAttackRange;
    }
    public void Execute(PlayerManager e)
    {
        e.m_attackCheck = true;
        e.m_move.Turn(e.m_monsterController.transform.position);
        if (Time.time > e.m_lastAttackTime + e.m_attackDelay)
        {
            print("playerAttack!!");
            e.m_lastAttackTime = Time.time;
        }
        
        if (!e.CheckEnermy(e.m_monsterController))
        {
            e.ChangeState(PlayerStateIdle.m_Inst);
            
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
        e.m_move.m_agent.stoppingDistance = 2;
    }
}

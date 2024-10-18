using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateChase : FSMSingleton<PlayerStateChase>, FSMState<PlayerManager>
{
    float number = 0;
    public void Enter(PlayerManager e)
    {
        print("PlayerStateChase");
        e.m_move.m_agent.speed = e.m_PlayerMoveSpeed;
        e.m_move.m_agent.isStopped = false;
    }
    public void Execute(PlayerManager e)
    {
        e.m_move.Set_Dest(e.m_movePoint);

        e.m_move.Turn(e.m_movePoint);

        float distance = Vector3.Distance(e.transform.position, e.m_movePoint);

        if(distance >= 1)
        {
            number += Time.deltaTime;
            e.m_aniManager.MoveAnimation(number);
        }
        else
        {
            e.m_aniManager.MoveAnimation(distance);
        }

        if (e.m_monsterController)
        {
            if (e.CheckEnermy(e.m_monsterController))
            {
                e.ChangeState(PlayerStateAttack.m_Inst);
            }
        }
        else
        {
            if (distance < 0.5f)
            {
                e.ChangeState(PlayerStateIdle.m_Inst);
            }
        }
        
    }
    public void Exit(PlayerManager e)
    {
        e.m_moveCheck = false;
        e.m_movePoint = Vector3.zero;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateChase : FSMSingleton<PlayerStateChase>, FSMState<PlayerManager>
{
    public void Enter(PlayerManager e)
    {
        print("PlayerStateChase");
    }
    public void Execute(PlayerManager e)
    {
        e.m_move.Set_Dest(e.m_movePoint);
        
        //if(Vector3.Distance(e.transform.position, e.m_movePoint) < 1f)
        //{
        //    e.ChangeState(PlayerStateIdle.m_Inst);
        //}
        if(e.CheckEnermy(e.m_monsterController))
        {
            e.ChangeState(PlayerStateAttack.m_Inst);
        }
    }
    public void Exit(PlayerManager e)
    {
        e.m_moveCheck = false;
        e.m_movePoint = Vector3.zero;
        print("Out");
    }
}

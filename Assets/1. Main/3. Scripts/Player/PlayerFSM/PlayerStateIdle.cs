using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateIdle : FSMSingleton<PlayerStateIdle>, FSMState<PlayerManager>
{
    public void Enter(PlayerManager e)
    {
        print("PlayerStateIdle");
        e.m_aniManager.MoveAnimation(0);
    }
    public void Execute(PlayerManager e)
    {
        if(e.m_moveCheck)
        {
            
            e.ChangeState(PlayerStateChase.m_Inst);
        }
        if(e.m_attackCheck)
        {
            e.ChangeState(PlayerStateAttack.m_Inst);
        }
        
    }
    public void Exit(PlayerManager e)
    {

    }
}

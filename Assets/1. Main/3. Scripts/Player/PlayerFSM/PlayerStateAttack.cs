using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateAttack : FSMSingleton<PlayerStateAttack>, FSMState<PlayerManager>
{
    public void Enter(PlayerManager e)
    {
        print("PlayerStateAttack");
    }
    public void Execute(PlayerManager e)
    {
        e.m_attackCheck = true;
        e.m_move.Turn(e.m_monsterController.transform.position);
        //print("playerAttack!!");
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
    }
}

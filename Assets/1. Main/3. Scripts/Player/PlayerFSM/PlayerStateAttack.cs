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
                    print("playerAttack!!");
                    for (int i = 0; i < e.m_attackAreaUnit.m_unitList.Count; i++)
                    {
                        MonsterController controller = e.m_attackAreaUnit.m_unitList[i].GetComponent<MonsterController>();
                        controller.m_hpManager.ReduceHp(e.m_playerAttackPoint);
                        controller.ChangeState(MonsterStateDamage.m_Inst);
                        //e.m_aniManager
                    }
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

        {
            //if (!e.CheckEnermy(e.m_monsterController))
            //{
            //    e.ChangeState(PlayerStateIdle.m_Inst);
            //}
            //else
            //{
            //    e.m_move.Turn(e.m_monsterController.transform.position);
            //    if (Time.time > e.m_lastAttackTime + e.m_playerAttackDelay)
            //    {
            //        print("playerAttack!!");
            //        for(int i = 0; i < e.m_attackAreaUnit.m_unitList.Count; i++)
            //        {
            //            MonsterController controller = e.m_attackAreaUnit.m_unitList[i].GetComponent<MonsterController>();
            //            controller.m_hpManager.ReduceHp(e.m_playerAttackPoint);
            //            controller.ChangeState(MonsterStateDamage.m_Inst);

            //            //e.m_attackAreaUnit.m_unitList[i].m_hpManager.ReduceHp(e.m_playerAttackPoint);
            //            //e.m_attackAreaUnit.m_unitList[i].ChangeState(MonsterStateDamage.m_Inst);


            //        }
            //        e.m_lastAttackTime = Time.time;
            //    }
            //    if (e.m_monsterController.m_isDie)
            //    {
            //        if (e.m_attackAreaUnit.m_unitList.Count > 0)
            //        {
            //            e.m_monsterController = e.m_attackAreaUnit.m_unitList[0];
            //        }
            //    }
            //}
        }

    }
    public void Exit(PlayerManager e)
    {
        
    }
}

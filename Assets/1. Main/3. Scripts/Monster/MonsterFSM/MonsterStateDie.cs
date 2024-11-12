using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateDie : FSMSingleton<MonsterStateDie>, FSMState<MonsterController>
{
    public void Enter(MonsterController e)
    {
        e.m_monsterAgent.isStopped = true;
        e.m_aniManager.ParameterBool("Death", true);
        
        e.m_player.m_attackAreaUnit.m_unitList.Remove(e);
        e.m_isDie = true;

    }
    public void Execute(MonsterController e)
    {
        if (e.m_aniManager.m_animator.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            if (e.m_aniManager.m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
            {
                print("몬스터 죽는다");
                e.gameObject.SetActive(false);
                Destroy(e.gameObject, 2f);
                e.transform.Translate(new Vector3(0,0,-Time.deltaTime));

            }
        }

    }
    public void Exit(MonsterController e)
    {

    }
}

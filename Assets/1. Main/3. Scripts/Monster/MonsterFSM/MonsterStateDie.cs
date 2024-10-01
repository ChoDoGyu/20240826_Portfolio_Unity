using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateDie : FSMSingleton<MonsterStateDie>, FSMState<MonsterController>
{
    public void Enter(MonsterController e)
    {
        e.m_monsterAgent.isStopped = true;
        print("���� �״´�");
        print("������ �Ʒ��� ����ɴ� �ִϸ��̼�");
        Destroy(e.gameObject, 2f);
        //e.m_player.m_attackAreaUnit.m_unitList.Remove(e.gameObject);
        e.m_player.m_attackAreaUnit.m_unitList.Remove(e);
        e.m_isDie = true;

    }
    public void Execute(MonsterController e)
    {
        //������ �Ʒ��� ����ɴ� �ִϸ��̼�
        

    }
    public void Exit(MonsterController e)
    {

    }
}

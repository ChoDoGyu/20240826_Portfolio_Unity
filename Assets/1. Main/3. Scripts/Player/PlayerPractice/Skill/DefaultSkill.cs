using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSkill : UseSkill
{

    public override void InitSeting()
    {
        base.InitSeting();
    }

    public override void Using()
    {
        base.Using();
        print("АјАн");
        for (int i = 0; i < m_playermanager.m_attackAreaUnit.m_unitList.Count; i++)
        {
            MonsterController controller = m_playermanager.m_attackAreaUnit.m_unitList[i].GetComponent<MonsterController>();
            controller.m_hpManager.ReduceHp(m_playermanager.m_playerAttackPoint + m_skillDataStruct.m_skillDamage);
            controller.ChangeState(MonsterStateDamage.m_Inst);
        }
    }
}

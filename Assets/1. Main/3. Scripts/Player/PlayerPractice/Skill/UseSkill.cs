using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SkillDataStruct
{
    public float m_skillDamage;
    public float m_attackRange;
    public float m_skillCoolTime;
}
public abstract class UseSkill : MonoBehaviour
{
    public SkillDataStruct m_skillDataStruct;

    public SkillData m_data;

    public virtual void InitSeting()
    {
        m_skillDataStruct.m_skillDamage = m_data.m_skillDamage;
        m_skillDataStruct.m_attackRange = m_data.m_attackRange;
        m_skillDataStruct.m_skillCoolTime = m_data.m_skillCoolTime;
    }

    public virtual void Using(GameObject obj)
    {
        obj.transform.localScale = new Vector3(3, 2, m_skillDataStruct.m_attackRange);
        obj.transform.localPosition = new Vector3(0, 0, m_skillDataStruct.m_attackRange / 2);
    }
}
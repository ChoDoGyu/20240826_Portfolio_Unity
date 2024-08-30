using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SkillData", menuName = "ScriptableObject/SkillData", order = int.MaxValue)]
public class SkillData : ScriptableObject
{
    [SerializeField]
    public string m_skillName;
    [SerializeField]
    public float m_skillDamage;
    [SerializeField]
    public float m_attackRange;
    [SerializeField]
    public float m_skillCoolTime;
}

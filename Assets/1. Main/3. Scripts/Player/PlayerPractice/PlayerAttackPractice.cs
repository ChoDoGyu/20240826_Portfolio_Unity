using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackPractice : MonoBehaviour
{
    [Header("현재 스킬")]
    public UseSkill m_curSkill;
    [Header("기본 스킬")]
    public UseSkill m_defaultSkill;
    public UseSkill m_lastSkill;

    [SerializeField, Header("공격 지역")]
    public GameObject m_attackArea;

    public float m_curAttackRange;
    public float m_curAttackPoint;

    void Start()
    {
        m_curSkill = m_defaultSkill;
        m_curSkill.InitSeting();
        m_lastSkill = m_curSkill;
    }
    void Update()
    {
        if (m_lastSkill != m_curSkill)
        {
            m_lastSkill = m_curSkill;
            m_curSkill.InitSeting();
        }
        m_curSkill.Using(m_attackArea);
        ChangeSkill();
    }
    void ChangeSkill()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SmashSkill smash = GetComponent<SmashSkill>();
            m_curSkill = smash;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SlashSkill slash = GetComponent<SlashSkill>();
            m_curSkill = slash;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            AirSkill air = GetComponent<AirSkill>();
            m_curSkill = air;
        }
    }


}

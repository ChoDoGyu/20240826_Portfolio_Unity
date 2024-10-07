using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using System.IO;
using UnityEditor;
//enum형으로 공격 스킬이 뭔지 정한 다음
//공격하면 오브젝트 하나로 됨
//스킬 데이터는 리스트에 넣어놓고 정할때마다 바꿔서 적용하면 됨
public class PlayerAttack : MonoBehaviour
{
    public enum SkillGroup
    {
        Skill0,//기본 기술(평타)
        Skill1,//스킬1
        Skill2,//스킬2
        Skill3//스킬3
    }
    [SerializeField,Header("현재 스킬")]
    public SkillGroup m_curskill;
    [SerializeField, Header("공격 지역")]
    public GameObject m_attackArea;
    [SerializeField, Header("스킬 데이터 리스트")]
    public List<SkillData> m_skillDataList = new List<SkillData>();

    public float m_curAttackRange;
    public float m_curAttackPoint;

    public bool m_skillState = false;
    public bool m_useSkill1 = false;
    public bool m_useSkill2 = false;
    public bool m_useSkill3 = false;

    void Awake()
    {
        
    }
    void Start()
    {

    }
    void Update()
    {
        SkillChange();
        UseSkill();
    }
    void SkillChange()
    {
        switch(m_curskill)
        {
            case SkillGroup.Skill0:
                m_curAttackRange = m_skillDataList[0].m_attackRange;
                m_attackArea.transform.localScale = new Vector3(3, 2, m_skillDataList[0].m_attackRange);
                m_attackArea.transform.localPosition = new Vector3(0, 0, m_skillDataList[0].m_attackRange / 2);
                m_curAttackPoint = m_skillDataList[0].m_skillDamage;
                break;
            case SkillGroup.Skill1:
                m_curAttackRange = m_skillDataList[1].m_attackRange;
                m_attackArea.transform.localScale = new Vector3(3, 2, m_skillDataList[1].m_attackRange);
                m_attackArea.transform.localPosition = new Vector3(0, 0, m_skillDataList[1].m_attackRange / 2);
                m_curAttackPoint = m_skillDataList[1].m_skillDamage;
                break;
            case SkillGroup.Skill2:
                m_curAttackRange = m_skillDataList[2].m_attackRange;
                m_attackArea.transform.localScale = new Vector3(3, 2, m_skillDataList[2].m_attackRange);
                m_attackArea.transform.localPosition = new Vector3(0, 0, m_skillDataList[2].m_attackRange / 2);
                m_curAttackPoint = m_skillDataList[2].m_skillDamage;
                break;
            case SkillGroup.Skill3:
                m_curAttackRange = m_skillDataList[3].m_attackRange;
                m_attackArea.transform.localScale = new Vector3(3, 2, m_skillDataList[3].m_attackRange);
                m_attackArea.transform.localPosition = new Vector3(0, 0, m_skillDataList[3].m_attackRange / 2);
                m_curAttackPoint = m_skillDataList[3].m_skillDamage;
                break;

        }
    }
    public void UseSkill()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            m_skillState = true;
            m_useSkill1 = true;
            m_useSkill2 = false;
            m_useSkill3 = false;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            m_skillState = true;
            m_useSkill1 = false;
            m_useSkill2 = true;
            m_useSkill3 = false;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            m_skillState = true;
            m_useSkill1 = false;
            m_useSkill2 = false;
            m_useSkill3 = true;
        }
        if(Input.GetKeyUp(KeyCode.Alpha1))
        {
            m_skillState = false;
            m_useSkill1 = false;
        }
        else if(Input.GetKeyUp(KeyCode.Alpha2))
        {
            m_skillState = false;
            m_useSkill2 = false;
        }
        else if( Input.GetKeyUp(KeyCode.Alpha3))
        {
            m_skillState = false;
            m_useSkill3 = false;
        }


        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    m_curskill = SkillGroup.Skill1;
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    m_curskill = SkillGroup.Skill2;
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    m_curskill = SkillGroup.Skill3;
        //}
        //if (Input.GetKeyUp(KeyCode.Alpha1))
        //{
        //    m_curskill = SkillGroup.Skill0;
        //}
        //else if (Input.GetKeyUp(KeyCode.Alpha2))
        //{
        //    m_curskill = SkillGroup.Skill0;
        //}
        //else if (Input.GetKeyUp(KeyCode.Alpha3))
        //{
        //    m_curskill = SkillGroup.Skill0;
        //}
    }
    
}

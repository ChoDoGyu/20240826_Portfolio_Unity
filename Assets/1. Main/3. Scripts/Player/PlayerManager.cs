using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : FSM<MonsterController>
{
    [HideInInspector]
    public PlayerMove m_move;
    [HideInInspector]
    public PlayerAttack m_attack;
    private Camera m_camera;
    [HideInInspector]//클릭한 몬스터 정보를 가져오기 위한 변수
    public MonsterController m_monsterController;
    [HideInInspector]
    public bool m_playerAttack = false;
    [SerializeField]
    AttackAreaUnitFind m_attackAreaUnit;
    void Awake()
    {
        m_move = GetComponent<PlayerMove>();
        m_attack = GetComponent<PlayerAttack>();
        m_camera = Camera.main;
    }
    void Update()
    {
        FSMUpdate();
        MouseClick();
    }
    public bool CheckDistance(Vector3 target, float distance)
    {
        var dist = transform.position - target;
        if (dist.sqrMagnitude <= Mathf.Pow(distance, 2f))
        {
            return true;
        }
        return false;
    }
    void MouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            m_move.m_agent.isStopped = false;
            RaycastHit hit;
            
            if (Physics.Raycast(m_camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.collider.TryGetComponent<IClickable>(out IClickable iTmp))
                {
                    iTmp.Click(this, hit.point);
                }
            }
            //if (EventSystem.current.IsPointerOverGameObject() == false)
            //{

            //}
            if (m_playerAttack)
            {
                m_attack.UseSkill1();
                m_move.m_agent.isStopped = true;
                //m_move.m_agent.stoppingDistance = 10f;
            }


        }
    }
    public bool CheckEnermy(MonsterController enermy)
    {
        if (m_attackAreaUnit.m_unitList.Count > 0)
        {
            for (int i = 0; i < m_attackAreaUnit.m_unitList.Count; i++)
            {
                if (m_attackAreaUnit.m_unitList[i] = enermy.gameObject)
                {
                    return true;
                }
                return false;
            }
        }
        return false;
    }
}

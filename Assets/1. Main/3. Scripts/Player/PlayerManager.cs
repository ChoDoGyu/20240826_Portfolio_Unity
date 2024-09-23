using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerManager : FSM<PlayerManager>
{
    [HideInInspector]
    public PlayerMove m_move;
    [HideInInspector]
    public PlayerAttack m_attack;
    private Camera m_camera;
    public PlayerStaus m_playerStaus;


    [HideInInspector]//클릭한 몬스터 정보를 가져오기 위한 변수
    public MonsterController m_monsterController;
    [SerializeField, Header("공걱범위")]
    AttackAreaUnitFind m_attackAreaUnit;
    //FSM 변수
    public bool m_moveCheck = false;
    public Vector3 m_movePoint = Vector3.zero;

    public bool m_attackCheck = false;

    #region 플레이어 스텟
    [HideInInspector]
    public int m_level;
    [HideInInspector]
    public int m_hp;
    [HideInInspector]
    public int m_damage;
    [HideInInspector]
    public int m_armor;
    [HideInInspector]
    public int m_moveSpeed;
    [HideInInspector]
    public int m_attackDelay;
    [HideInInspector]
    public float m_lastAttackTime = 0;
    #endregion
    void Awake()
    {
        m_move = GetComponent<PlayerMove>();
        m_attack = GetComponent<PlayerAttack>();
        m_playerStaus = GetComponent<PlayerStaus>();
        m_camera = Camera.main;

        InitState(this, PlayerStateIdle.m_Inst);
    }
    void Update()
    {
        FSMUpdate();
        MouseClick();
        CurrentStaus();
    }
    void MouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {
                RaycastHit hit;
                if (Physics.Raycast(m_camera.ScreenPointToRay(Input.mousePosition), out hit))
                {

                    if (hit.collider.TryGetComponent<IClickable>(out IClickable iTmp))
                    {
                        iTmp.Click(this, hit.point);
                    }
                }
            }
        }
    }
    public bool CheckEnermy(MonsterController enermy)
    {
        for (int i = 0; i < m_attackAreaUnit.m_unitList.Count; i++)
        {
            if (m_attackAreaUnit.m_unitList[i] = enermy.gameObject)
            {
                return true;
            }
        }
        return false;
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
    void CurrentStaus()
    {
        //m_level = m_playerStaus.m_level;
        m_hp = m_playerStaus.m_hp;
        m_damage = m_playerStaus.m_damage;
        m_armor = m_playerStaus.m_armor;
        m_moveSpeed = m_playerStaus.m_moveSpeed;
        m_attackDelay = m_playerStaus.m_attackDelay;
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerManager : FSM<PlayerManager>
{
    #region 컴포넌트 불러오기
    [HideInInspector]
    public PlayerMove m_move;
    [HideInInspector]
    public PlayerAttack m_attack;
    private Camera m_camera;
    public PlayerStaus m_playerStaus;
    public HPManager m_hpManager;
    public AnimationManager m_aniManager;
    #endregion

    //[HideInInspector]//클릭한 몬스터 정보를 가져오기 위한 변수
    public MonsterController m_monsterController;
    [SerializeField, Header("공걱범위")]
    public AttackAreaUnitFind m_attackAreaUnit;
    //FSM 변수
    public bool m_moveCheck = false;
    public Vector3 m_movePoint = Vector3.zero;

    public bool m_attackCheck = false;

    [Header("스폰포인트")]
    public Transform m_spawnPoint;
    [Header("죽었는지 여부")]
    public bool m_isDie = false;

    [Header("인벤토리")]
    public Inventory m_inventory;
    [Header("장비창")]
    public EquipmentInventory m_equipment;
    //[Header("클릭한 아이템")]
    //public ItemData m_clickedItem;

    [Header("포션 회복량")]
    float m_potion = 10f;

    #region 플레이어 스텟
    [HideInInspector]
    public int m_playerLevel;
    [HideInInspector]
    public float m_playerAttackPoint;
    [HideInInspector]
    public float m_PlayerArmorPoint;
    [HideInInspector]
    public float m_PlayerMoveSpeed;
    [HideInInspector]
    public float m_playerAttackDelay;
    [HideInInspector]
    public float m_lastAttackTime = 0;
    #endregion
    void Awake()
    {
        m_move = GetComponent<PlayerMove>();
        m_attack = GetComponent<PlayerAttack>();
        m_playerStaus = GetComponent<PlayerStaus>();
        m_hpManager = GetComponent<HPManager>();
        m_camera = Camera.main;
        m_aniManager = GetComponent<AnimationManager>();

        InitState(this, PlayerStateIdle.m_Inst);
    }
    void Start()
    {
        StartStaus();

    }
    void Update()
    {
        FSMUpdate();
        MouseClick();
        ChangeStaus();

        UsePotion();
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
            //if (m_attackAreaUnit.m_unitList[i] = enermy.gameObject)
            //{
            //    return true;
            //}
            if (m_attackAreaUnit.m_unitList[i] == enermy)
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
    void StartStaus()
    {
        //m_playerLevel = m_playerStaus.m_level;
        m_hpManager.m_hp = m_playerStaus.m_hp;
        m_playerAttackPoint = m_playerStaus.m_damage;
        m_PlayerArmorPoint = m_playerStaus.m_armor;
        m_PlayerMoveSpeed = m_playerStaus.m_moveSpeed;
        m_playerAttackDelay = m_playerStaus.m_attackDelay;
    }
    void ChangeStaus()
    {
        m_playerAttackPoint = m_playerStaus.m_damage + m_attack.m_curAttackPoint;
    }
    void UsePotion()
    {
        if(Input.GetKeyDown(KeyManager.Instance.GetKeyCode("Potion")))
        {
            m_hpManager.IncreaseHp(m_potion);
        }
    }
}

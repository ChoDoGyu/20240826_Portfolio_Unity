using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : FSM<PlayerManager>
{
    [HideInInspector]
    public PlayerMove m_move;
    [HideInInspector]
    public PlayerAttack m_attack;
    private Camera m_camera;
    //[HideInInspector]//클릭한 몬스터 정보를 가져오기 위한 변수
    public MonsterController m_monsterController;
    [SerializeField, Header("공걱범위")]
    AttackAreaUnitFind m_attackAreaUnit;
    //FSM 변수
    public bool m_moveCheck = false;
    public Vector3 m_movePoint = Vector3.zero;

    public bool m_attackCheck = false;
    void Awake()
    {
        m_move = GetComponent<PlayerMove>();
        m_attack = GetComponent<PlayerAttack>();
        m_camera = Camera.main;
        InitState(this, PlayerStateIdle.m_Inst);
    }
    void Update()
    {
        FSMUpdate();
        MouseClick();
    }
    void MouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
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
    //public void LookAtPos(RaycastHit hit)
    //{
    //    Vector3 desPos = new Vector3(hit.point.x, hit.point.y, hit.point.z);
    //    Vector3 dir = desPos - transform.position;
    //    Quaternion lookTarget = Quaternion.LookRotation(dir);

    //}
}

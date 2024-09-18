using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : FSM<MonsterController>, IClickable
{
    [SerializeField]
    private MonsterData m_monsterData;
    public MonsterData m_MonsterData => m_monsterData;
    [HideInInspector]
    public NavMeshAgent m_monsterAgent;
    [HideInInspector]
    public PlayerManager m_player;

    [HideInInspector]
    public float m_lastAttackTime = 0;

    HPManager m_hpManager;


    private void Awake()
    {
        m_monsterAgent = GetComponent<NavMeshAgent>();
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        InitState(this, MonsterStateIdle.m_Inst);
        
        m_hpManager = GetComponent<HPManager>();
        m_hpManager.m_hp = m_monsterData.m_hp;
    }
    void Update()
    {
        FSMUpdate();
        if(m_player.m_moveCheck)
        {
            m_player.m_movePoint = this.transform.position;

            //m_player.m_move.Set_Dest(this.transform.position);

            //if (CheckDistance(m_player.transform.position, m_player.m_attack.m_curAttackRange * 0.9f))
            //{
            //    m_player.m_move.m_agent.isStopped = true;
            //    //m_player.m_move.Set_Dest(m_player.transform.position);
            //    Debug.Log("플레이어 공격!!");
            //    m_clicked = false;
            //}
        }
    }
    //플레이어와의 거리 체크
    public bool CheckDistance(Vector3 target, float distance)
    {
        var dist = transform.position - target;
        if (dist.sqrMagnitude <= Mathf.Pow(distance, 2f))
        {
            return true;
        }
        return false;
    }
    //몬스터 이동 위치 전달
    public void Move(Vector3 targetPos)
    {
        m_monsterAgent.SetDestination(targetPos);
    }
    public void Turn(Vector3 targetPos)
    {
        Vector3 dir = targetPos - transform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), m_monsterAgent.angularSpeed);
    }
    //범위 확인 기즈모
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, m_monsterData.m_sightRange);
        Gizmos.DrawWireSphere(transform.position, m_monsterData.m_attackRange);
    }
    public void Click(PlayerManager player, Vector3 hitPos)
    {
        if (player == null)
            return;

        player.m_monsterController = this;

        player.m_moveCheck = true;
        
        //player.m_playerAttack = true;
    }
}

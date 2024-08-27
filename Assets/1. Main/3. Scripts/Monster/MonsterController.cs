using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : FSM<MonsterController>
{
    [SerializeField]
    private MonsterData m_monsterData;
    public MonsterData m_MonsterData => m_monsterData;

    NavMeshAgent m_monsterAgent;
    [SerializeField]
    public PlayerManager m_player;

    [HideInInspector]
    public float m_lastAttackTime = 0;

    private void Awake()
    {
        m_monsterAgent = GetComponent<NavMeshAgent>();
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        InitState(this, MonsterStateIdle._Inst);
    }
    void Update()
    {
        FSMUpdate();
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

    //범위 확인 기즈모
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, m_monsterData.m_sightRange);
        
    }
}

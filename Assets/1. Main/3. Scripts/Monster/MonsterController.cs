using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MonsterController : FSM<MonsterController>, IClickable
{
    public Rigidbody m_monsterRigidbody;
    public AnimationManager m_aniManager;
    [SerializeField]
    private MonsterData m_monsterData;
    public MonsterData m_MonsterData => m_monsterData;
    [HideInInspector]
    public NavMeshAgent m_monsterAgent;
    //[HideInInspector]
    public PlayerManager m_player;

    [HideInInspector]
    public float m_lastAttackTime = 0;

    public HPManager m_hpManager;

    public bool m_clicked = false;

    [SerializeField]
    public Slider m_slider;
    Camera m_Camera;

    public bool m_isDie = false;

    //[HideInInspector]//���� ��ġ
    public Vector3 m_startPos;
    [HideInInspector]//�÷��̾��� ����
    public Vector3 m_playerdir;

    private void Awake()
    {
        m_monsterRigidbody = GetComponent<Rigidbody>();
        m_monsterAgent = GetComponent<NavMeshAgent>();
        m_aniManager = GetComponent<AnimationManager>();
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        InitState(this, MonsterStateIdle.m_Inst);
        

        m_hpManager = GetComponent<HPManager>();
        m_hpManager.m_hp = m_monsterData.m_hp;

        m_Camera = Camera.main;

        //�¾ ��ġ ���� - �߰� ������ ����
        //m_startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //GameObject tmp = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //tmp.transform.position = m_startPos;
        m_monsterAgent.enabled = false;
        //StartCoroutine(Coroutine_NavMeshAgentEnable());
    }
    private void Start()
    {
        m_slider.maxValue = m_hpManager.m_hp;
        m_slider.value = m_hpManager.m_hp;

        m_monsterAgent.enabled = true;
    }
    void Update()
    {
        FSMUpdate();
        if(m_clicked)
        {
            m_player.m_movePoint = new Vector3(this.transform.position.x, m_player.transform.position.y, this.transform.position.z);
            if (m_player.m_attackCheck)
            {
                m_clicked = false;
            }
        }
        //ü�¹�
        m_slider.value = m_hpManager.m_hp;
        m_slider.transform.LookAt(m_Camera.transform.position);

        //�߰� �Ÿ� ����
        //if (!CheckDistance(m_startPos, m_MonsterData.m_sightRange * 2))
        //{
        //    ChangeState(MonsterStateReset.m_Inst);
        //}
        m_playerdir = m_player.transform.position - transform.position;
    }
    //�÷��̾���� �Ÿ� üũ
    public bool CheckDistance(Vector3 target, float distance)
    {
        var dist = transform.position - target;
        if (dist.sqrMagnitude <= Mathf.Pow(distance, 2f))
        {
            return true;
        }
        return false;
    }
    //���� �̵� ��ġ ����
    public void Move(Vector3 targetPos)
    {
        m_monsterAgent.SetDestination(targetPos);
    }
    public void Turn(Vector3 targetPos)
    {
        Vector3 dir = targetPos - transform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), m_monsterAgent.angularSpeed);
    }
    //���� Ȯ�� �����
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

        m_clicked = true;
        //player.m_playerAttack = true;
    }

    public void MonsterAttack()
    {
        Debug.Log("Monster Attack!!");
        m_player.m_hpManager.ReduceHp(m_MonsterData.m_damage);
        m_player.ChangeState(PlayerStateDamage.m_Inst);
    }
    IEnumerator Coroutine_NavMeshAgentEnable()
    {
        yield return new WaitForSeconds(0.5f);
        m_monsterAgent.enabled = true;
    }
}

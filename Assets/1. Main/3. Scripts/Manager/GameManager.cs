using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager m_instance;
    public static GameManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<GameManager>();
            }
            return m_instance;
        }
    }
    [SerializeField]
    public PlayerManager m_player;
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

    }
    private void Start()
    {
        m_player = FindObjectOfType<PlayerManager>();
        StartGameSetting();

    }
    private void Update()
    {

    }
    public void IsDie()
    {
        UIManager.Instance.m_respawn.SetActive(true);
    }
    public void Respawn()
    {
        m_player.ChangeState(PlayerStateRespawn.m_Inst);
        UIManager.Instance.m_respawn.SetActive(false);
    }

    void StartGameSetting()
    {
        #region 플레이어 상태
        if (DataManager.Instance.m_nowPlayer.m_inventory != null)
        {
            for (int i = 0; i < DataManager.Instance.m_nowPlayer.m_inventory.Count; i++)
            {
                m_player.m_inventory.m_items.Add(DataManager.Instance.m_nowPlayer.m_inventory[i]);
            }
        }
        if (DataManager.Instance.m_nowPlayer.m_equipment != null)
        {
            for (int i = 0; i < DataManager.Instance.m_nowPlayer.m_equipment.Count; i++)
            {
                m_player.m_equipment.m_items.Add(DataManager.Instance.m_nowPlayer.m_equipment[i]);
            }
        }
        m_player.m_playerStaus.m_level = DataManager.Instance.m_nowPlayer.m_level;
        m_player.m_playerStaus.m_hp = DataManager.Instance.m_nowPlayer.m_maxHp;
        m_player.m_hpManager.m_hp = DataManager.Instance.m_nowPlayer.m_curHp;
        m_player.m_playerStaus.m_damage = DataManager.Instance.m_nowPlayer.m_damage;
        m_player.m_playerStaus.m_armor = DataManager.Instance.m_nowPlayer.m_armor;
        m_player.m_playerStaus.m_moveSpeed = DataManager.Instance.m_nowPlayer.m_moveSpeed;
        m_player.m_playerStaus.m_attackDelay = DataManager.Instance.m_nowPlayer.m_attackDelay;
        m_player.transform.position = DataManager.Instance.m_nowPlayer.m_curTransform;
        //m_player.m_coin = DataManager.Instance.m_nowPlayer.m_coin;

        #endregion

        #region UI 초기화
        UIManager.Instance.m_EscWindow.SetActive(false);


        #endregion
    }
}

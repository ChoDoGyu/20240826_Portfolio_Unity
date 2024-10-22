using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/*
�����ϴ� ���
1. ������ �����Ͱ� ����
2. �����͸� ���̽����� ��ȯ
3. ���̽��� �ܺο� ����

�ҷ����� ���
1. �ܺο� ����� ���̽��� ������
2. ���̽��� ���������·� ��ȯ
3. �ҷ��� �����͸� ���
 */

public class PlayerData
{
    public string m_name;
    public int m_level = 1;
    public int m_maxHp = 50;
    public float m_curHp = 50;
    public int m_damage = 1;
    public int m_armor = 0;
    public int m_moveSpeed = 5;
    public int m_attackDelay = 2;
    public int m_coin;
    public List<ItemData> m_inventory;
    public List<ItemData> m_equipment;

    public Vector3 m_curTransform = new Vector3(500, 0, 500);
}

public class DataManager : MonoBehaviour
{
    static DataManager m_instance;

    public static DataManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<DataManager>();
            }
            return m_instance;
        }
    }

    public PlayerData m_nowPlayer = new PlayerData();

    public string m_path;   // ���
    public int m_nowSlot;   //���� ���� ��ȣ



    private void Awake()
    {
        #region �̱���
        if (m_instance == null)
        {
            m_instance = this;
        }
        else if(m_instance != this)
        {
            Destroy(m_instance.gameObject);
        }
        DontDestroyOnLoad(m_instance.gameObject);
        #endregion

        m_path = Application.persistentDataPath + "/save";//��� ����
        print(m_path);
    }

    public void SaveData()
    {

        string data = JsonUtility.ToJson(m_nowPlayer);

        File.WriteAllText(m_path + m_nowSlot.ToString(), data);

    }

    public void PlayingSaveData()
    {
        if (GameManager.Instance.m_player.m_inventory.m_items != null)
        {
            for (int i = 0; i < GameManager.Instance.m_player.m_inventory.m_items.Count; i++)
            {
                m_nowPlayer.m_inventory.Add(GameManager.Instance.m_player.m_inventory.m_items[i]);
            }
        }
        if (GameManager.Instance.m_player.m_equipment.m_items != null)
        {
            for (int i = 0; i < GameManager.Instance.m_player.m_equipment.m_items.Count; i++)
            {
                m_nowPlayer.m_inventory.Add(GameManager.Instance.m_player.m_equipment.m_items[i]);
            }
        }
        m_nowPlayer.m_level = GameManager.Instance.m_player.m_playerStaus.m_level;
        m_nowPlayer.m_maxHp = GameManager.Instance.m_player.m_playerStaus.m_hp;
        m_nowPlayer.m_curHp = GameManager.Instance.m_player.m_hpManager.m_hp;
        m_nowPlayer.m_damage = GameManager.Instance.m_player.m_playerStaus.m_damage;
        m_nowPlayer.m_armor = GameManager.Instance.m_player.m_playerStaus.m_armor;
        m_nowPlayer.m_moveSpeed = GameManager.Instance.m_player.m_playerStaus.m_moveSpeed;
        m_nowPlayer.m_attackDelay = GameManager.Instance.m_player.m_playerStaus.m_attackDelay;
        //m_nowPlayer.m_coin = GameManager.Instance.m_player.m_coin;
        m_nowPlayer.m_curTransform = GameManager.Instance.m_player.transform.position;


        string data = JsonUtility.ToJson(m_nowPlayer);

        File.WriteAllText(m_path + m_nowSlot.ToString(), data);
    }

    public void LoadData()
    {
        string data = File.ReadAllText(m_path + m_nowSlot.ToString());

        m_nowPlayer = JsonUtility.FromJson<PlayerData>(data);
    }

    public void DataClear()
    {
        m_nowSlot = -1;
        m_nowPlayer = new PlayerData();
    }
}

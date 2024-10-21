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
    public int m_level;
    public int m_hp;
    public int m_damage;
    public int m_armor;
    public int m_moveSpeed;
    public int m_attackDelay;
    public int m_coin;
}

public class DataManager : MonoBehaviour
{
    public static DataManager m_instance;

    PlayerData m_nowPlayer = new PlayerData();

    string m_path;
    string m_filename = "save";


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

        m_path = Application.persistentDataPath + "/";
    }

    void Start()
    {

    }
    public void SaveData()
    {
        string data = JsonUtility.ToJson(m_nowPlayer);

        File.WriteAllText(m_path + m_filename, data);
    }

    public void LoadData()
    {
        string data = File.ReadAllText(m_path + m_filename);

        m_nowPlayer = JsonUtility.FromJson<PlayerData>(data);
    }
}

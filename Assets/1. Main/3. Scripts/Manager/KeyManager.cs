using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System.Text;

[System.Serializable]
public class KeyData
{
    //�ش� Ű�� ���ó(�̸�)
    public string m_keyName;

    //����Ƽ���� �����ϴ� KeyCode ����
    public KeyCode m_keyCode;//json���·� ����� ���� keycode.I�� �ƴ϶� 106(����)�� ������ �ȴ�.(enum)

    //keyData ������
    public KeyData(string keyName, KeyCode keyCode)
    {
        this.m_keyName = keyName;
        this.m_keyCode = keyCode;
    }
}
//Ű �Է¿� ���� ������ ������ �ְ�, Ư���� ��ɿ� �����ϴ� Ű�� �����ϴ� �Ŵ��� Ŭ����
public class KeyManager : MonoBehaviour
{
    static KeyManager m_instance;
    public static KeyManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<KeyManager>();
            }
            return m_instance;
        }
    }

    private static string m_optionDataFileName = "/KeyData.json";
    private static string m_filePath = Application.dataPath + "/1. Main/1. Data/Json/KeyCode/KeyData.json";
    //private static string m_filePath;

    private Dictionary<string, KeyCode> m_keyDictionary;

    private void Awake()
    {
        m_keyDictionary = new Dictionary<string, KeyCode>();
        //m_filePath = Application.persistentDataPath + m_optionDataFileName;
        

        LoadOptionData();
    }
    private void LoadOptionData()
    {
        //����� ������ ���ٸ�
        if (File.Exists(m_filePath))
        {
            string fromJsonData = File.ReadAllText(m_filePath);

            List<KeyData> keyList = JsonConvert.DeserializeObject<List<KeyData>>(fromJsonData);

            foreach(var data in keyList)
            {
                m_keyDictionary.Add(data.m_keyName, data.m_keyCode);
            }
        }
        else//����� ������ ���ٸ�
        {
            Debug.Log(GetType() + "������ ����");
            ResetOptionData();
        }
    }
    //������Ʈ���� ������ �ش� ������ ������ �°� Ű�� �����Ѵ�.
    //��ũ��Ʈ���� ������ Ű�� �缳���Ѵ�.
    private void ResetOptionData()
    {
        m_keyDictionary.Clear();

        //�� ������ ����� Ű �����͵�
        m_keyDictionary.Add("Inventory", KeyCode.I);//������ �κ��丮
        m_keyDictionary.Add("Equipment", KeyCode.O);//��� �κ��丮
        m_keyDictionary.Add("Stat", KeyCode.P);//����
        m_keyDictionary.Add("Potion", KeyCode.Q);//����

        m_keyDictionary.Add("SkillQuickSlot1", KeyCode.Alpha1);//��ų ������1
        m_keyDictionary.Add("SkillQuickSlot2", KeyCode.Alpha2);//��ų ������2
        m_keyDictionary.Add("SkillQuickSlot3", KeyCode.Alpha3);//��ų ������3

        Debug.Log(GetType() + "�ʱ�ȭ");

        SaveOPtionData();
    }
    public void SaveOPtionData()
    {
        //��ųʸ��� �ִ� Ű �����͵��� ������Ʈ ����Ʈ�� �̿��Ͽ� �±׸� ���� ����ȭ��Ų��.
        //����Ʈ�� ������� �ʰ� ��ųʸ��� ����ȭ�ϸ� �±װ� ���⿡ ����� �� ����.
        //������Ʈ ����(KeyData)�� �����, Object type�� json ���Ϸ� �������.

        //KeyData�� ������Ʈ�� ���� ����Ʈ
        List<KeyData> keys = new List<KeyData>();

        //��� ��ųʸ��� �ִ� Ű ���� ����Ʈ�� �־��ش�.
        foreach(KeyValuePair<string, KeyCode> keyName in m_keyDictionary)
        {
            keys.Add(new KeyData(keyName.Key, keyName.Value));
        }

        //List<KeyData>�� serializeObject�� �ϸ� Object type json�� ���´�.
        string jsonData = JsonConvert.SerializeObject(keys);

        //���Ϸ� ����
        FileStream filestream = new FileStream(m_filePath, FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);
        filestream.Write(data, 0, data.Length);
        filestream.Close();

        Debug.Log(GetType() + "���Ͼ���");
    }

    /// <summary>
    /// Ű �̸��� ������� �ش� Ű�� ��ϵ� keycode�� �����Ѵ�.
    /// </summary>
    /// <param name="keyName"></param>
    /// <returns></returns>
    public KeyCode GetKeyCode(string keyName)
    {
        return m_keyDictionary[keyName];
    }

    /// <summary>
    /// �ش� Ű���� �ڱ� �ڽ��� ������ Ű�� ��ϵǾ� �ִ� ��츦 �����ϰ�, Ư���� Ű ������ �����ϱ� ���� Ű�� ü���Ѵ�.
    /// </summary>
    /// <returns>�Ҵ� ������ Ű�ΰ�?</returns>
    public bool CheckKey(KeyCode key, KeyCode currentKey)
    {
        //����1. ���� �Ҵ�� Ű�� ���� Ű�� �����ϵ��� �� ���� ������� �����Ѵ�.
        if(currentKey == key)
        {
            return true;
        }
        //1�� Ű �˻�.
        //Ű�¾Ʒ��� Ű�� ���ȴ�.
        if
        (
            key >= KeyCode.A && key <= KeyCode.Z ||         //97~122    A~Z
            key >= KeyCode.Alpha0 && key <= KeyCode.Alpha9 ||  //48~57     0~9
            key == KeyCode.Quote || //39         
            key == KeyCode.Comma || //44
            key == KeyCode.Period || //46
            key == KeyCode.Slash || //47
            key == KeyCode.Semicolon || //59
            key == KeyCode.LeftBracket || //91
            key == KeyCode.RightBracket || //93
            key == KeyCode.Minus || //45
            key == KeyCode.Equals || //61
            key == KeyCode.BackQuote //96
        ) { }
        else { return false; }

        //2�� Ű �˻�
        //1�� Ű �˻縦 ������ Ű �� ���� ���ǹ� Ű�� ������ �� ����.
        if
        (
            //�̵� Ű WASD
            key == KeyCode.W ||
            key == KeyCode.A ||
            key == KeyCode.S ||
            key == KeyCode.D
        ) { return false; }

        //3�� Ű �˻�
        //���� ������ Ű�� �� �̹� �Ҵ� �� Ű�� �ִ� ���� ���� �� �� ����.
        foreach(KeyValuePair<string, KeyCode> keyPair in m_keyDictionary)
        {
            if(key == keyPair.Value)
            {
                return false;
            }
        }

        //��� Ű �˻縦 ����ϸ� �ش� Ű�¼����� ������ Ű
        return true;
    }

    /// <summary>
    /// KeyName�� �ش��ϴ� Ű�� KeyCode�� key�� �����Ų��.
    /// </summary>
    /// <param name="keyCode">���� �����ϴ� Ű�� �ڵ尪(enum)</param>
    /// <param name="keyName">������ Ű(keyCode)�� keyName�� �Ҵ��Ѵ�</param>
    public void AssignKey(KeyCode keyCode, string keyName)
    {
        //��ųʸ�
        m_keyDictionary[keyName] = keyCode;

        //Ű ������ ���ÿ� ����
        SaveOPtionData();
    }
}

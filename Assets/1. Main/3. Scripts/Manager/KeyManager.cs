using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System.Text;

[System.Serializable]
public class KeyData
{
    //해당 키의 사용처(이름)
    public string m_keyName;

    //유니티에서 제공하는 KeyCode 값들
    public KeyCode m_keyCode;//json형태로 저장될 때는 keycode.I가 아니라 106(숫자)로 저장이 된다.(enum)

    //keyData 생성자
    public KeyData(string keyName, KeyCode keyCode)
    {
        this.m_keyName = keyName;
        this.m_keyCode = keyCode;
    }
}
//키 입력에 대한 정보를 가지고 있고, 특정한 기능에 대응하는 키를 관리하는 매니져 클래스
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
        //저장된 게임이 없다면
        if (File.Exists(m_filePath))
        {
            string fromJsonData = File.ReadAllText(m_filePath);

            List<KeyData> keyList = JsonConvert.DeserializeObject<List<KeyData>>(fromJsonData);

            foreach(var data in keyList)
            {
                m_keyDictionary.Add(data.m_keyName, data.m_keyCode);
            }
        }
        else//저장된 게임이 없다면
        {
            Debug.Log(GetType() + "파일이 없음");
            ResetOptionData();
        }
    }
    //프로젝트마다 별도로 해당 게임의 컨셉에 맞게 키를 설정한다.
    //스크립트에서 지정한 키로 재설정한다.
    private void ResetOptionData()
    {
        m_keyDictionary.Clear();

        //씬 내에서 사용할 키 데이터들
        m_keyDictionary.Add("Inventory", KeyCode.I);//아이템 인벤토리
        m_keyDictionary.Add("Equipment", KeyCode.O);//장비 인벤토리
        m_keyDictionary.Add("Stat", KeyCode.P);//스텟
        m_keyDictionary.Add("Potion", KeyCode.Q);//포션

        m_keyDictionary.Add("SkillQuickSlot1", KeyCode.Alpha1);//스킬 퀵슬롯1
        m_keyDictionary.Add("SkillQuickSlot2", KeyCode.Alpha2);//스킬 퀵슬롯2
        m_keyDictionary.Add("SkillQuickSlot3", KeyCode.Alpha3);//스킬 퀵슬롯3

        Debug.Log(GetType() + "초기화");

        SaveOPtionData();
    }
    public void SaveOPtionData()
    {
        //딕셔너리에 있는 키 데이터들을 오브젝트 리스트를 이용하여 태그를 만들어서 직렬화시킨다.
        //리스트를 사용하지 않고 딕셔너리만 직렬화하면 태그가 없기에 사용할 수 없다.
        //오브젝트 형태(KeyData)로 만들고, Object type의 json 파일로 만들었다.

        //KeyData를 오브젝트로 담을 리스트
        List<KeyData> keys = new List<KeyData>();

        //모든 딕셔너리에 있는 키 값을 리스트에 넣어준다.
        foreach(KeyValuePair<string, KeyCode> keyName in m_keyDictionary)
        {
            keys.Add(new KeyData(keyName.Key, keyName.Value));
        }

        //List<KeyData>를 serializeObject를 하면 Object type json이 나온다.
        string jsonData = JsonConvert.SerializeObject(keys);

        //파일로 쓰기
        FileStream filestream = new FileStream(m_filePath, FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);
        filestream.Write(data, 0, data.Length);
        filestream.Close();

        Debug.Log(GetType() + "파일쓰기");
    }

    /// <summary>
    /// 키 이름을 기반으로 해당 키에 등록된 keycode를 리턴한다.
    /// </summary>
    /// <param name="keyName"></param>
    /// <returns></returns>
    public KeyCode GetKeyCode(string keyName)
    {
        return m_keyDictionary[keyName];
    }

    /// <summary>
    /// 해당 키에서 자기 자신을 제외한 키가 등록되어 있는 경우를 방지하고, 특정한 키 설정을 방지하기 위해 키를 체그한다.
    /// </summary>
    /// <returns>할당 가능한 키인가?</returns>
    public bool CheckKey(KeyCode key, KeyCode currentKey)
    {
        //예외1. 현재 할당된 키에 같은 키로 설정하도록 한 경우는 허용으로 리턴한다.
        if(currentKey == key)
        {
            return true;
        }
        //1차 키 검사.
        //키는아래의 키만 허용된다.
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

        //2차 키 검사
        //1차 키 검사를 포함한 키 중 다음 조건문 키는 설정할 수 없다.
        if
        (
            //이동 키 WASD
            key == KeyCode.W ||
            key == KeyCode.A ||
            key == KeyCode.S ||
            key == KeyCode.D
        ) { return false; }

        //3차 키 검사
        //현재 설정된 키들 중 이미 할당 된 키가 있는 경우는 설정 할 수 없다.
        foreach(KeyValuePair<string, KeyCode> keyPair in m_keyDictionary)
        {
            if(key == keyPair.Value)
            {
                return false;
            }
        }

        //모든 키 검사를 통과하면 해당 키는설정이 가능한 키
        return true;
    }

    /// <summary>
    /// KeyName에 해당하는 키를 KeyCode인 key로 변경시킨다.
    /// </summary>
    /// <param name="keyCode">새로 설정하는 키의 코드값(enum)</param>
    /// <param name="keyName">설정된 키(keyCode)를 keyName에 할당한다</param>
    public void AssignKey(KeyCode keyCode, string keyName)
    {
        //딕셔너리
        m_keyDictionary[keyName] = keyCode;

        //키 파일을 로컬에 저장
        SaveOPtionData();
    }
}

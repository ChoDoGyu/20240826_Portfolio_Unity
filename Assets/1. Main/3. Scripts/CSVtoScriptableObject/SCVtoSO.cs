using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using static MonsterData;
using System.Threading;

public class SCVtoSO
{
    #region 몬스터 정보
    //CSV가 저장된 파일 위치
    private static string m_CSVMonsterPath = "/1. Main/1. Data/CSV/MonsterData.csv";
    
    [MenuItem("Utilities/Generate Monsters")]
    public static void GenerateMonsters()
    {
        //File.IO에서 사용하는 함수
        //File.ReadAllLines(FilePath)는 경로에 있는 파일의 텍스트를 모두 읽어 한 줄 단위로 나우어 배열 형태로 내보내는 함수
        string[] csvText = File.ReadAllLines(Application.dataPath + m_CSVMonsterPath);

        foreach (string allLine in csvText)
        {
            string[] splitData = allLine.Split(',');

            if (splitData.Length != 6)
            {
                Debug.LogError("This File Data Count isn't 6 count");
            }
            //ScriptableObject.CreateInstance<>함수는 Scriptable Object를 메모리에 생성하고 참조값을 반환하는 함수
            //그러므로 아직 파일로 생성되진 않았지만, Enemy라는 Scriptable Object의 클래스를 참조해서 쓰고 있다.
            MonsterData monster = ScriptableObject.CreateInstance<MonsterData>();
            monster.m_name = splitData[0];
            monster.m_hp = int.Parse(splitData[1]);
            monster.m_damage = int.Parse(splitData[2]);
            monster.m_sightRange = float.Parse(splitData[3]);
            monster.m_attackRange = float.Parse(splitData[4]);
            monster.m_attackDelay = float.Parse(splitData[5]);

            //AssetDatabase.CreateAsset를 이용해서 매개변수에 (생성할 파일, 파일 경로)를 정해주어 파일을 만듬
            AssetDatabase.CreateAsset(monster, $"Assets/1. Main/1. Data/ScriptableObject/Monster/{monster.m_name}.asset");
        }
        //파일을 디스크에 저장
        AssetDatabase.SaveAssets();
    }
    #endregion
    #region 스킬 정보
    private static string m_CSVSkillPath = "/1. Main/1. Data/CSV/SkillData.csv";
    [MenuItem("Utilities/Generate Skill")]
    public static void GenerateSkill()
    {
        //File.IO에서 사용하는 함수
        //File.ReadAllLines(FilePath)는 경로에 있는 파일의 텍스트를 모두 읽어 한 줄 단위로 나우어 배열 형태로 내보내는 함수
        string[] csvText = File.ReadAllLines(Application.dataPath + m_CSVSkillPath);

        foreach (string allLine in csvText)
        {
            string[] splitData = allLine.Split(',');

            if (splitData.Length != 4)
            {
                Debug.LogError("This File Data Count isn't 4 count");
            }
            //ScriptableObject.CreateInstance<>함수는 Scriptable Object를 메모리에 생성하고 참조값을 반환하는 함수
            //그러므로 아직 파일로 생성되진 않았지만, Enemy라는 Scriptable Object의 클래스를 참조해서 쓰고 있다.
            SkillData skill = ScriptableObject.CreateInstance<SkillData>();
            skill.m_skillName = splitData[0];
            skill.m_skillDamage = float.Parse(splitData[1]);
            skill.m_attackRange = float.Parse(splitData[2]);
            skill.m_skillCoolTime = float.Parse(splitData[3]);

            //AssetDatabase.CreateAsset를 이용해서 매개변수에 (생성할 파일, 파일 경로)를 정해주어 파일을 만듬
            AssetDatabase.CreateAsset(skill, $"Assets/1. Main/1. Data/ScriptableObject/Skill/{skill.m_skillName}.asset");
        }
        //파일을 디스크에 저장
        AssetDatabase.SaveAssets();
    }
    #endregion
    #region 아이템 정보
    private static string m_CSVItemPath = "/1. Main/1. Data/CSV/ItemData.csv";
    [MenuItem("Utilities/Generate Item")]
    public static void GenerateItem()
    {
        //File.IO에서 사용하는 함수
        //File.ReadAllLines(FilePath)는 경로에 있는 파일의 텍스트를 모두 읽어 한 줄 단위로 나우어 배열 형태로 내보내는 함수
        string[] csvText = File.ReadAllLines(Application.dataPath + m_CSVItemPath);

        foreach (string allLine in csvText)
        {
            string[] splitData = allLine.Split(',');

            if (splitData.Length != 6)
            {
                Debug.LogError("This File Data Count isn't 6 count");
            }
            //ScriptableObject.CreateInstance<>함수는 Scriptable Object를 메모리에 생성하고 참조값을 반환하는 함수
            //그러므로 아직 파일로 생성되진 않았지만, Enemy라는 Scriptable Object의 클래스를 참조해서 쓰고 있다.
            ItemData item = ScriptableObject.CreateInstance<ItemData>();
            item.m_itemName = splitData[0];
            item.m_itemCategory = splitData[1];
            item.m_itemCategoryNum = int.Parse(splitData[2]);
            item.m_effectNum = float.Parse(splitData[3]);
            item.m_itemPrice = int.Parse(splitData[4]);
            item.m_itemTooltip = splitData[5];

            //AssetDatabase.CreateAsset를 이용해서 매개변수에 (생성할 파일, 파일 경로)를 정해주어 파일을 만듬
            AssetDatabase.CreateAsset(item, $"Assets/1. Main/1. Data/ScriptableObject/Item/{item.m_itemName}.asset");
        }
        //파일을 디스크에 저장
        AssetDatabase.SaveAssets();
    }
    #endregion
}

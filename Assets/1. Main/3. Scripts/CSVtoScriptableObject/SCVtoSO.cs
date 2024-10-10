using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using static MonsterData;
using System.Threading;

public class SCVtoSO
{
    #region ���� ����
    //CSV�� ����� ���� ��ġ
    private static string m_CSVMonsterPath = "/1. Main/1. Data/CSV/MonsterData.csv";
    
    [MenuItem("Utilities/Generate Monsters")]
    public static void GenerateMonsters()
    {
        //File.IO���� ����ϴ� �Լ�
        //File.ReadAllLines(FilePath)�� ��ο� �ִ� ������ �ؽ�Ʈ�� ��� �о� �� �� ������ ����� �迭 ���·� �������� �Լ�
        string[] csvText = File.ReadAllLines(Application.dataPath + m_CSVMonsterPath);

        foreach (string allLine in csvText)
        {
            string[] splitData = allLine.Split(',');

            if (splitData.Length != 6)
            {
                Debug.LogError("This File Data Count isn't 6 count");
            }
            //ScriptableObject.CreateInstance<>�Լ��� Scriptable Object�� �޸𸮿� �����ϰ� �������� ��ȯ�ϴ� �Լ�
            //�׷��Ƿ� ���� ���Ϸ� �������� �ʾ�����, Enemy��� Scriptable Object�� Ŭ������ �����ؼ� ���� �ִ�.
            MonsterData monster = ScriptableObject.CreateInstance<MonsterData>();
            monster.m_name = splitData[0];
            monster.m_hp = int.Parse(splitData[1]);
            monster.m_damage = int.Parse(splitData[2]);
            monster.m_sightRange = float.Parse(splitData[3]);
            monster.m_attackRange = float.Parse(splitData[4]);
            monster.m_attackDelay = float.Parse(splitData[5]);

            //AssetDatabase.CreateAsset�� �̿��ؼ� �Ű������� (������ ����, ���� ���)�� �����־� ������ ����
            AssetDatabase.CreateAsset(monster, $"Assets/1. Main/1. Data/ScriptableObject/Monster/{monster.m_name}.asset");
        }
        //������ ��ũ�� ����
        AssetDatabase.SaveAssets();
    }
    #endregion
    #region ��ų ����
    private static string m_CSVSkillPath = "/1. Main/1. Data/CSV/SkillData.csv";
    [MenuItem("Utilities/Generate Skill")]
    public static void GenerateSkill()
    {
        //File.IO���� ����ϴ� �Լ�
        //File.ReadAllLines(FilePath)�� ��ο� �ִ� ������ �ؽ�Ʈ�� ��� �о� �� �� ������ ����� �迭 ���·� �������� �Լ�
        string[] csvText = File.ReadAllLines(Application.dataPath + m_CSVSkillPath);

        foreach (string allLine in csvText)
        {
            string[] splitData = allLine.Split(',');

            if (splitData.Length != 4)
            {
                Debug.LogError("This File Data Count isn't 4 count");
            }
            //ScriptableObject.CreateInstance<>�Լ��� Scriptable Object�� �޸𸮿� �����ϰ� �������� ��ȯ�ϴ� �Լ�
            //�׷��Ƿ� ���� ���Ϸ� �������� �ʾ�����, Enemy��� Scriptable Object�� Ŭ������ �����ؼ� ���� �ִ�.
            SkillData skill = ScriptableObject.CreateInstance<SkillData>();
            skill.m_skillName = splitData[0];
            skill.m_skillDamage = float.Parse(splitData[1]);
            skill.m_attackRange = float.Parse(splitData[2]);
            skill.m_skillCoolTime = float.Parse(splitData[3]);

            //AssetDatabase.CreateAsset�� �̿��ؼ� �Ű������� (������ ����, ���� ���)�� �����־� ������ ����
            AssetDatabase.CreateAsset(skill, $"Assets/1. Main/1. Data/ScriptableObject/Skill/{skill.m_skillName}.asset");
        }
        //������ ��ũ�� ����
        AssetDatabase.SaveAssets();
    }
    #endregion
    #region ������ ����
    private static string m_CSVItemPath = "/1. Main/1. Data/CSV/ItemData.csv";
    [MenuItem("Utilities/Generate Item")]
    public static void GenerateItem()
    {
        //File.IO���� ����ϴ� �Լ�
        //File.ReadAllLines(FilePath)�� ��ο� �ִ� ������ �ؽ�Ʈ�� ��� �о� �� �� ������ ����� �迭 ���·� �������� �Լ�
        string[] csvText = File.ReadAllLines(Application.dataPath + m_CSVItemPath);

        foreach (string allLine in csvText)
        {
            string[] splitData = allLine.Split(',');

            if (splitData.Length != 6)
            {
                Debug.LogError("This File Data Count isn't 6 count");
            }
            //ScriptableObject.CreateInstance<>�Լ��� Scriptable Object�� �޸𸮿� �����ϰ� �������� ��ȯ�ϴ� �Լ�
            //�׷��Ƿ� ���� ���Ϸ� �������� �ʾ�����, Enemy��� Scriptable Object�� Ŭ������ �����ؼ� ���� �ִ�.
            ItemData item = ScriptableObject.CreateInstance<ItemData>();
            item.m_itemName = splitData[0];
            item.m_itemCategory = splitData[1];
            item.m_itemCategoryNum = int.Parse(splitData[2]);
            item.m_effectNum = float.Parse(splitData[3]);
            item.m_itemPrice = int.Parse(splitData[4]);
            item.m_itemTooltip = splitData[5];

            //AssetDatabase.CreateAsset�� �̿��ؼ� �Ű������� (������ ����, ���� ���)�� �����־� ������ ����
            AssetDatabase.CreateAsset(item, $"Assets/1. Main/1. Data/ScriptableObject/Item/{item.m_itemName}.asset");
        }
        //������ ��ũ�� ����
        AssetDatabase.SaveAssets();
    }
    #endregion
}

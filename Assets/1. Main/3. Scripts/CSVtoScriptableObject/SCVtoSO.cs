using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class SCVtoSO
{
    //CSV�� ����� ���� ��ġ
    private static string m_monsterCSVPath = "/1. Main/1. Data/CSV/MonsterData.csv";
    [MenuItem("Utilities/Generate Monsters")]
    public static void GenerateMonsters()
    {
        //File.IO���� ����ϴ� �Լ�
        //File.ReadAllLines(FilePath)�� ��ο� �ִ� ������ �ؽ�Ʈ�� ��� �о� �� �� ������ ����� �迭 ���·� �������� �Լ�
        string[] csvText = File.ReadAllLines(Application.dataPath + m_monsterCSVPath);

        

        foreach (string allLine in csvText) 
        {
            string[] splitData = allLine.Split(',');
            
            if (splitData.Length != 6 )
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
            AssetDatabase.CreateAsset(monster, $"Assets/1. Main/1. Data/ScriptableObject/{monster.m_name}.asset");
        }
        //������ ��ũ�� ����
        AssetDatabase.SaveAssets();
    }
}

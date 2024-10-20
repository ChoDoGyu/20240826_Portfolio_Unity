using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ItemDataStruct
{
    public string m_itemName;       //������ �̸�
    public string m_itemCategory;
    public int m_itemCategoryNum;
    public float m_effectNum;       //���ݷ�, ����
    public int m_itemPrice;         //����
    public string m_itemTooltip;    //����

    public ItemDataStruct(string itemName, string itemCategory, int itemCategoryNum, float effectNum, int itemPrice, string itemTooltip)
    {
        this.m_itemName = itemName;
        this.m_itemCategory = itemCategory;
        this.m_itemCategoryNum = itemCategoryNum;
        this.m_effectNum = effectNum;
        this.m_itemPrice = itemPrice;
        this.m_itemTooltip = itemTooltip;
    }
}

[CreateAssetMenu(fileName = "ItemDataSO", menuName = "ScriptableObject/ItemDataSO", order = int.MaxValue)]
public class ItemDataSO : ScriptableObject
{
    [SerializeField, Header("���������Ʈ���� ������ ����ȭ �� ������Ʈ")]
    public List<ItemDataStruct> m_itmeDataList = new List<ItemDataStruct>();
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ItemDataStruct
{
    public string m_itemName;       //아이템 이름
    public string m_itemCategory;
    public int m_itemCategoryNum;
    public float m_effectNum;       //공격력, 방어력
    public int m_itemPrice;         //가격
    public string m_itemTooltip;    //설명

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
    [SerializeField, Header("스프레드시트에서 읽혀져 직력화 된 오브젝트")]
    public List<ItemDataStruct> m_itmeDataList = new List<ItemDataStruct>();
}

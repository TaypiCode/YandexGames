using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemPack : ShopItem
{
    [SerializeField] private GameObject _itemPrefub;
    [SerializeField] private Transform _contentItemsSpawn;
    [SerializeField] private int[] _rewardCount;
    private void Start()
    {
        CreateItemList();
    }
    public override void Reward()
    {
        //pack reward
    }
    public void CreateItemList()
    {
        //create pack items (optional)
    }
}

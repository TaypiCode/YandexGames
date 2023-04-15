using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemRemoveAds : ShopItem
{
    public override void Reward()
    {
        SetAvailable(false, "null");
    }
}

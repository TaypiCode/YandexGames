using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Promocode", menuName = "ScriptableObjects/Promocode", order = 1)]
public class PromocodeScriptable : ScriptableObject
{
    [ScriptableObjectId] public string itemId;
    [SerializeField] private RewardType _rewardType;
    [SerializeField] private string _code;

    public RewardType GetRewardType { get => _rewardType; }
    public string Code { get => _code; }

    public enum RewardType
    {
        Items
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData
{
    private static int _score;

    public static int Score { get => _score; set => _score = value; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMode : MonoBehaviour
{
    [SerializeField] private bool _testModeOn;
    private static bool _testModeStatic;

    public static bool Value { get => _testModeStatic;  }
    private void Awake()
    {
        _testModeStatic = _testModeOn;
        if (_testModeOn)
        {
            Debug.LogWarning("Test mode is ON");
        }
    }
}

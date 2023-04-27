using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _time = 0;
    private Action _action;
    private void Start()
    {
        StartCoroutine(UpdateTimer());
    }
    private IEnumerator UpdateTimer()
    {
        while (true)
        {
            if (_time > 0)
            {
                _time -= Time.deltaTime;
            }
            else
            {
                if (_action != null)
                {
                    _action?.Invoke();
                    _action = null;
                }
            }
            yield return new WaitForEndOfFrame();
        }
    }
    public void SetTimer(Action action, float time)
    {
        _time = time;
        _action = action;
    }
    public float GetTime()
    {
        return _time;
    }
}

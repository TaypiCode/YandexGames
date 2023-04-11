using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _time = 0;
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
            yield return new WaitForEndOfFrame();
        }
    }
    public void SetTimer(float time)
    {
        _time = time;
    }
    public float GetTime()
    {
        return _time;
    }
    public bool IsWorking()
    {
        if(_time > 0)
        {
            return true;
        }
        return false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEffect : MonoBehaviour
{
    [SerializeField] private Transform _object;
    [SerializeField] private float _animTime;
    [SerializeField] private bool _showOnStart = false;
    [SerializeField] private float _showOnStartDelay;
    private Timer _timer;
    private Coroutine _animCoroutine;
    private float _scaleStep;
    private void Awake()
    {
        CreateTimer();
    }
    private void Start()
    {
        if (_showOnStart)
        {
            Show(_showOnStartDelay);
        }
    }
    private IEnumerator AnimEffect()
    {
        while (true)
        {
            if (_timer.GetTime() > 0)
            {
                float scale = 1 - _timer.GetTime() * _scaleStep;
                _object.localScale = new Vector3(scale, scale, scale);
                yield return new WaitForEndOfFrame();
            }
            _object.localScale = Vector3.one;
            yield return null;
        }
    }
    private void StartAnimCoroutine()
    {
        _timer.SetTimer(null, _animTime);
        _animCoroutine = StartCoroutine(AnimEffect());
    }
    public void Show(float delay)
    {
        if (_animCoroutine != null)
        {
            StopCoroutine(_animCoroutine);
        }
        _object.localScale = Vector3.zero;
        _scaleStep = 1 / _animTime;
        CreateTimer();
        _timer.SetTimer(delegate { StartAnimCoroutine(); }, delay);
    }
    private void CreateTimer()
    {
        if (_timer == null)
        {
            _timer = gameObject.AddComponent<Timer>();
        }
    }
}

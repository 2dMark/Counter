using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField, Min(.1f)] private float _timeInterval = .5f;
    [SerializeField, Min(.1f)] private float _summand = 1f;

    public event Action<float> CountChanged;

    private WaitForSeconds _timer;
    private Coroutine _coroutine;
    private float _count;
    private bool _isWork = false;

    public bool IsWork => _isWork;

    private void Awake()
    {
        _timer = new(_timeInterval);
    }

    public void StartCounting()
    {
        _isWork = true;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Counting());
    }

    public void StopCounting() => _isWork = false;

    private IEnumerator Counting()
    {
        while (_isWork)
        {
            _count += _summand;
            CountChanged?.Invoke(_count);

            yield return _timer;
        }

        yield return null;
    }
}
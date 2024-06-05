using TMPro;
using UnityEngine;

public class CounterViewer : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _counter.CountChanged += RefreshCount;
    }

    private void OnDisable()
    {
        _counter.CountChanged -= RefreshCount;
    }

    private void RefreshCount(float count) => _text.text = count.ToString();
}
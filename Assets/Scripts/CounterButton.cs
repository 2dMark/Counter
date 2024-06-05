using UnityEngine;
using UnityEngine.UI;

public class CounterButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Counter _counter;

    public void ChangeStatus()
    {
        if (_counter.IsWork)
            _counter.StopCounting();
        else
            _counter.StartCounting();
    }
}
using UnityEngine;
using TMPro;

public class IncrementText : MonoBehaviour
{
    public SO_Event _finishedEvent;
    [SerializeField]
    private int _max;
    private TextMeshProUGUI _text;

    private void Start() => _text = GetComponent<TextMeshProUGUI>();

    public void Increment()
    {
        int.TryParse(_text.text, out int value);
        _text.text = $"{++value}";
        if(value >= _max)
        {
            _finishedEvent.Raise();
        }
    }
}

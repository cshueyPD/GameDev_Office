using UnityEngine;
using TMPro;

public class IncrementText : MonoBehaviour
{
    [SerializeField]
    private GameObject _object;
    [SerializeField]
    private int _max;
    private TextMeshProUGUI _text;

    private void Start() => _text = GetComponent<TextMeshProUGUI>();

    public void Increment()
    {
        int.TryParse(_text.text, out int value);
        _text.text = $"{++value}";
        if(value >= _max){
            if (_object != null)
            {
                _object.SetActive(true);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Stopwatch : MonoBehaviour
{
    private float _timer;
    private TextMeshProUGUI _text;
    private bool _running = true;

    private void Start() => _text = GetComponent<TextMeshProUGUI>();

    // Update is called once per frame
    void Update()
    {
        if(_running)
        {
            _timer += Time.deltaTime;
            TimeSpan timeSpan = TimeSpan.FromSeconds(_timer);
            _text.text = $"{timeSpan:mm\\:ss\\:ff}";
        }
    }

    public void StopTimer()
    {
        _running = false;
    }
}

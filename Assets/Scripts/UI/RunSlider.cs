using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class RunSlider : MonoBehaviour
{
    [SerializeField, Tooltip("Foreground image of the slider")]
    private Image _foregroundImage;
    [SerializeField, Tooltip("Background image of the slider")]
    private Image _backgroundImage;
    [SerializeField, Tooltip("Rate at which sprint drains")]
    private float _drainRate = 0.2f;
    [SerializeField, Tooltip("Rate at which sprint recharges")]
    private float _rechargeRate = 0.1f;
    public SO_EventBool sprintEvent;

    private float _maxValue = 1.0f;
    private float _currentValue;
    private float _minValue = 0.0f;

    private bool _isSprinting = false;

    public void OnSprint(InputValue value)
    {
        if (value.isPressed && _currentValue > _minValue)
        {
            _isSprinting = true;
            sprintEvent.Raise(_isSprinting);
            // Debug.Log("SPRINTING");
        }
        else if (!value.isPressed && _isSprinting)
        {
            _isSprinting = false;
            sprintEvent.Raise(_isSprinting);
        }
        // Debug.Log($"Sprint: {value.isPressed}, IsSprinting: {_isSprinting}");
    }

    private void Start() {
        _currentValue = _maxValue;
    }

    private void Update() {
        if(_isSprinting)
        {
            _currentValue -= _drainRate * Time.deltaTime;
            if(_currentValue <= _minValue)
            {
                _isSprinting = false;
                sprintEvent.Raise(_isSprinting);
            }
        }
        else
        {
            _currentValue += _rechargeRate * Time.deltaTime;
        }

        _currentValue = Mathf.Clamp(_currentValue, _minValue, _maxValue);
        _foregroundImage.transform.localScale = new Vector3(_currentValue, 1.0f, 1.0f);
    }
}

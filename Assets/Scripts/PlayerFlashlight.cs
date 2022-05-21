using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlashlight : MonoBehaviour
{
    [SerializeField] private float _minLightIntensity = 0.0005f;
    [SerializeField] private float _maxLightIntensity = 1.5f;
    [SerializeField] private float _minLightRange = 15f;
    [SerializeField] private float _maxLightRange = 100f;

    private Light _light;
    private float _currIntensity;
    private float _currRange;

    private void Start()
    {
        _light = GetComponent<Light>();
        _currIntensity = _maxLightIntensity;
        _currRange = _maxLightRange;
    }

    private void Update()
    {
        _currIntensity -= 0.0005f;
        _currRange -= 0.05f;
        _light.intensity = Mathf.Clamp(_currIntensity, _minLightIntensity, _maxLightIntensity);
        _light.range = Mathf.Clamp(_currRange, _minLightRange, _maxLightRange);
    }

    public void IncreasePower()
    {
        _currIntensity += 0.3f;
        _currRange += 30f;
        _currIntensity = Mathf.Clamp(_currIntensity, _minLightIntensity, _maxLightIntensity);
        _currRange = Mathf.Clamp(_currRange, _minLightRange, _maxLightRange);
    }
}

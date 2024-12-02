using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class S_SliderLife : MonoBehaviour
{
    [SerializeField] Slider _slider;
    [SerializeField] RSO_EntityLife _entityLifeData;
    [SerializeField] RSE_EventChannel OnEntityLifeChange;
    [SerializeField] TextMeshProUGUI _textlife;



    private void Awake()
    {
        _slider.maxValue = _entityLifeData.entityLife;
        _slider.minValue = 0;
        UpdateSliderBar();
    }
    void Start()
    {
        OnEntityLifeChange.RegisterListener(UpdateSliderBar);
    }

    void Update()
    {
        
    }

    public void UpdateSliderBar()
    {
        _slider.value = _entityLifeData.entityLife;
        _textlife.text = _entityLifeData.entityLife.ToString();

    }

    private void OnDestroy()
    {
        OnEntityLifeChange.UnregisterListener(UpdateSliderBar);
    }
}

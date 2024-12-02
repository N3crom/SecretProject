using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class S_PlayerLifeManager : MonoBehaviour
{

    [SerializeField] RSO_EntityLife _playerLifeData;
    [SerializeField] RSE_EventChannel OnPlayerDeathEvent;
    [SerializeField] RSE_EventChannel OnPlayerLifeChange;
    [SerializeField] RSE_IntEvent OnPlayerHit;


    private float _maxLife;

    private void Awake()
    {
        _maxLife = _playerLifeData.entityLife;
    }
    public void AddLife(float ammount)
    {
        if (_playerLifeData.entityLife + ammount > _maxLife)
        {
            _playerLifeData.entityLife = _maxLife;
        }
        else
        {
            _playerLifeData.entityLife += ammount;
        }

        OnPlayerLifeChange.RaiseEvent();
    }

    public void RemoveLife(float ammount)
    {

        _playerLifeData.entityLife -= ammount;

        if (_playerLifeData.entityLife <= 0)
        {
            _playerLifeData.entityLife = 0;
            OnPlayerDeathEvent.RaiseEvent();
        }

        OnPlayerLifeChange.RaiseEvent();

    }

    private void Start()
    {
        OnPlayerHit.RegisterListener(AddLife);
    }

    private void OnDestroy()
    {
        OnPlayerHit.UnregisterListener(AddLife);
        _playerLifeData.entityLife = _maxLife;
    }
}

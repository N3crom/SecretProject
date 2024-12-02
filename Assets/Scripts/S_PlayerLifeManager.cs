using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class S_PlayerLifeManager : MonoBehaviour
{

    [SerializeField] RSO_PlayerLife _playerLifeData;
    [SerializeField] RSE_EventChannel OnPlayerDeathEvent;
    [SerializeField] RSE_EventChannel OnPlayerLifeChange;

    private float _maxLife;

    private void Awake()
    {
        _maxLife = _playerLifeData.playerLife;
    }
    public void AddLife(float ammount)
    {
        if (_playerLifeData.playerLife + ammount > _maxLife)
        {
            _playerLifeData.playerLife = _maxLife;
        }
        else
        {
            _playerLifeData.playerLife += ammount;
        }

        OnPlayerLifeChange.RaiseEvent();
    }

    public void RemoveLife(float ammount)
    {

        _playerLifeData.playerLife -= ammount;

        if (_playerLifeData.playerLife <= 0)
        {
            _playerLifeData.playerLife = 0;
            OnPlayerDeathEvent.RaiseEvent();
        }

        OnPlayerLifeChange.RaiseEvent();

    }
}

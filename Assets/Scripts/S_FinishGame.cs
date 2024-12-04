using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_FinishGame : MonoBehaviour
{
    [SerializeField] private RSE_EventChannel eventGameWin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            eventGameWin.RaiseEvent();
        }
        
    }
}

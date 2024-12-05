using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Player : MonoBehaviour
{
    [SerializeField] private RSE_EventChannel eventGameWin;
    private Vector3 playerPositionInitial;

    void Start()
    {
        playerPositionInitial = transform.position;
    }
    private void Update()
    {
    }
    void ReturnToPosition()
    {
        transform.position = playerPositionInitial;
    }

    private void OnEnable()
    {
        eventGameWin.RegisterListener(ReturnToPosition);
    }
    private void OnDisable()
    {
        eventGameWin.UnregisterListener(ReturnToPosition);
    }
}

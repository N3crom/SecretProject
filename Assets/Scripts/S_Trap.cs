using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Trap : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private RSE_FloatEvent eventTrapTrigger;
    [SerializeField] private RSE_EventChannel eventGameWin;
    [Header("ScriptableObject")]
    [SerializeField] private SSO_TrapDammage sso_TrapDammage;
    [Header("References")]
    [SerializeField] private GameObject spikes;
    [SerializeField] private Collider spikeCollider;
    [Header("Values")]
    [SerializeField] private float delayTrap;
    [SerializeField] private float openingTime;
    [SerializeField] private Vector3 spikePos;


    void Start()
    {
        spikeCollider.enabled = false;
        StartCoroutine(Trap(delayTrap, openingTime));
    }

    IEnumerator Trap(float delay, float time)
    {
        yield return new WaitForSeconds(time);
        OpenTrap();
        yield return new WaitForSeconds(time);
        CloseTrap();
        yield return new WaitForSeconds(delay);
        StartCoroutine(Trap(delay, time));
    }

    void OpenTrap()
    {
        spikeCollider.enabled = true;
        spikes.transform.position += spikePos;
    }

    void CloseTrap()
    {
        spikeCollider.enabled = false;
        spikes.transform.position -= spikePos;
    }
    
    void DestroyTrap()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit");
            eventTrapTrigger.RaiseEvent(sso_TrapDammage.dammage);
        }
    }

    private void OnEnable()
    {
        eventGameWin.RegisterListener(DestroyTrap);
    }
    private void OnDisable()
    {
        eventGameWin.UnregisterListener(DestroyTrap);
    }

}

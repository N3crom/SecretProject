using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Trap : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject spikes;
    [SerializeField] private Collider spikeCollider;
    [Header("Values")]
    [SerializeField] private float delayTrap;
    [SerializeField] private float openingTime;
    [SerializeField] private Vector3 spikePosOpen;
    [SerializeField] private Vector3 spikePosClose;

    void Start()
    {
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
        spikes.transform.position = spikePosOpen;
        Debug.Log("Open");
    }

    void CloseTrap()
    {
        spikeCollider.enabled = false;
        spikes.transform.position = spikePosClose;
        Debug.Log("Close");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit");
        }
    }
}

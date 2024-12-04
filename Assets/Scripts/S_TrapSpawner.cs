using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class S_TrapSpawner : MonoBehaviour
{
    [SerializeField] private RSE_EventChannel eventGameWin;
    [SerializeField] private GameObject trapPrefabs;
    [SerializeField] private List<GameObject> trapPosition;
    [SerializeField] private int maxTrapSpawn;

    private List<Vector3> posTrap = new List<Vector3>();
    private List<GameObject> trap = new List<GameObject>();

    void Start()
    {
        InitializedTrapPosition();
    }

    void InitializedTrapPosition()
    {
        posTrap.Clear();

        for (int i = 0; i < trapPosition.Count; i++)
        {
            posTrap.Add(trapPosition[i].transform.position);
        }
        ChoosePosition();
    }

    void ChoosePosition()
    {
        for (int i = 0; i < maxTrapSpawn; i++)
        {
            int index = Random.Range(0, posTrap.Count);
            SpawnTrap(posTrap[index]);
            posTrap.Remove(posTrap[index]);
        }
    }

    void SpawnTrap(Vector3 pos)
    {
        Instantiate(trapPrefabs,pos, Quaternion.identity);
    }

    private void OnEnable()
    {
        eventGameWin.RegisterListener(InitializedTrapPosition);
    }
    private void OnDisable()
    {
        eventGameWin.UnregisterListener(InitializedTrapPosition);
    }
}

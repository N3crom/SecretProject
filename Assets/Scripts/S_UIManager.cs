using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S_UIManager : MonoBehaviour
{
    [SerializeField] RSO_EntityLife _entityLifeData;
    [SerializeField] RSE_EventChannel OnPlayerDeathEvent;
    [SerializeField] GameObject _gameOverPanel;


    void Start()
    {
        _gameOverPanel.SetActive(false);

        OnPlayerDeathEvent.RegisterListener(DisplayGameOverPanel);
    }

    void Update()
    {
        
    }

    public void UpdateUI()
    {
    }


    public void DisplayGameOverPanel()
    {
        StartCoroutine(WaitToDisplay());
    }

    private IEnumerator WaitToDisplay()
    {
        yield return new WaitForSeconds(1);
        _gameOverPanel.SetActive(true);
        
    }

    private void OnDestroy()
    {
        OnPlayerDeathEvent.UnregisterListener(DisplayGameOverPanel);

        
    }

    public void ReloadScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}

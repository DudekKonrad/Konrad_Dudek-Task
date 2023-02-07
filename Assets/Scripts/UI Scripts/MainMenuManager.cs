using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour 
{
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _settingsPanel;

    private GameObject _activePanel;

    private void Start()
    {
        _activePanel = _mainMenuPanel;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !_mainMenuPanel.activeSelf)
        {
            SetPanelActive(_mainMenuPanel);
        }
    }
    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void OnSettingsButtonClicked()
    {
        SetPanelActive(_settingsPanel);
    }

    public void OnBackButtonClicked()
    {
        SetPanelActive(_mainMenuPanel);
    }

    private void SetPanelActive(GameObject panel)
    {
        _activePanel.SetActive(false);
        panel.SetActive(true);
        _activePanel = panel;
        var firstButton = _activePanel.GetComponentInChildren<Button>();
        firstButton.Select();
    }
}

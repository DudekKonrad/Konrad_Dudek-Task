using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenuEsc : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}

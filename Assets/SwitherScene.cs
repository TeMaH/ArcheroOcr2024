using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Для работы с кнопками

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private Button switchSceneButton;
    [SerializeField] private string targetScene;

    private void Awake()
    {
        if (switchSceneButton == null)
        {
            Debug.LogError("Кнопка не привязана!");
            return;
        }

        if (string.IsNullOrEmpty(targetScene))
        {
            Debug.LogError("Имя целевой сцены не указано!");
            return;
        }

        switchSceneButton.onClick.AddListener(SwitchScene);
    }

 
    private void SwitchScene()
    {
        SceneManager.LoadScene(targetScene);
    }

    private void OnDestroy()
    {
        if (switchSceneButton != null)
        {
            switchSceneButton.onClick.RemoveListener(SwitchScene);
        }
    }
}


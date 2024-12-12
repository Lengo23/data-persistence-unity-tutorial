using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    [SerializeField] TMP_InputField playerNameField;
    [SerializeField] TMP_Text HighScoreText;

    void Start()
    {
       playerNameField.text = GameManager.Instance.PlayerName;
       HighScoreText.text = $"Best Score : {GameManager.Instance.HighScore} {GameManager.Instance.BestPlayerName}";

    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        GameManager.Instance.PlayerName = playerNameField.text;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}

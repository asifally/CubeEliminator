using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Menu : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI easyHighScoreText;
    [SerializeField] TextMeshProUGUI mediumHighScoreText;
    [SerializeField] TextMeshProUGUI hardHighScoreText;

    private void Start() {
        easyHighScoreText.SetText(DataManager.Instance.EasyHighScore.ToString());
        mediumHighScoreText.SetText(DataManager.Instance.MediumHighScore.ToString());
        hardHighScoreText.SetText(DataManager.Instance.HardHighScore.ToString());
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    
}

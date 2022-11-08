using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public int Difficulty = 1;
    public int EasyHighScore;
    public int MediumHighScore;
    public int HardHighScore;

    private string path;

    private void Awake() {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
#if UNITY_EDITOR
        path = Application.persistentDataPath + "/savefile.json";
        
#else
        path = "/idbfs/cube-eliminator/ladsf4894klaf/savefile.json";
#endif
        LoadHighScores();
    }

    public void SetHighScore(int score)
    {
        if (Difficulty == 1)
        {
            if (score > EasyHighScore)
            {
                EasyHighScore = score;
            }
        }
        if (Difficulty == 2)
        {
            if (score > MediumHighScore)
            {
                MediumHighScore = score;
            }
        }
        if (Difficulty == 3)
        {
            if (score > HardHighScore)
            {
                HardHighScore = score;
            }
        }
    }

    // TODO: Create LoadHighScores()

    // TODO: Create SaveHighScore()
    public void SaveHighScores()
    {
        SaveData data = new SaveData();
        data.EasyHighScore = EasyHighScore;
        data.MediumHighScore = MediumHighScore;
        data.HardHighScore = HardHighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(path, json);
    }


    public void LoadHighScores()
    {
        if (!File.Exists(path))
        {
            File.Create(path);
        }

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            EasyHighScore = data.EasyHighScore;
            MediumHighScore = data.MediumHighScore;
            HardHighScore = data.HardHighScore;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int EasyHighScore;
        public int MediumHighScore;
        public int HardHighScore;
    }
}

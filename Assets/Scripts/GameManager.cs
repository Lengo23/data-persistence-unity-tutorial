using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public int HighScore;
    public string BestPlayerName;
    public string PlayerName;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadData();

    }

    [System.Serializable]
    class SaveScoreData
    {
        public int HighScore;
        public string BestPlayerName;
        public string PlayerName;
    }

    public void SaveData()
    {
        SaveScoreData data = new SaveScoreData();
        data.HighScore = HighScore;
        data.BestPlayerName = BestPlayerName;
        data.PlayerName = PlayerName;

        string json = JsonUtility.ToJson(data);

        System.IO.File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (System.IO.File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            SaveScoreData data = JsonUtility.FromJson<SaveScoreData>(json);

            HighScore = data.HighScore;
            BestPlayerName = data.BestPlayerName;
            PlayerName = data.PlayerName;
        }
    }
}

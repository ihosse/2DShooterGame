using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int Score;
    public int HighScore;

    void Awake()
    {
        PlayerInfo[] objs = FindObjectsOfType<PlayerInfo>();

        if (objs.Length > 1)
        {
            DestroyImmediate(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
}

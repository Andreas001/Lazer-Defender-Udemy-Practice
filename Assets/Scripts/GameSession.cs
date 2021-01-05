using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField]
    int score = 0;

    private void Awake() {
        SetUpSingleton();
    }

    void Start()
    {
        
    }

    private void SetUpSingleton() {
        int numberOfGameSessions = FindObjectsOfType<GameSession>().Length;

        if(numberOfGameSessions > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore() {
        return score;
    }

    public void AddToScore(int score) {
        this.score += score;
    }

    public void ResetGame() {
        Destroy(gameObject);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    #region Singleton
    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject o = new GameObject("GameManager");
                _instance = o.AddComponent<GameManager>();
            }
            return _instance;
        }
    }
    #endregion
    public Player player;
    public int level=1;
    public SpriteRenderer[] background;
    public Sprite[] levelSprites;
    public UnityEvent OnBoosStart;
    public UnityEvent OnGameOver;
    public void Boss()
    {
        OnBoosStart?.Invoke();
    }

    private void Awake()
    {
        _instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        OnGameOver?.Invoke();
    }
    public void NextLevel()
    {
        level++;
        foreach (var item in background)
        {
            item.color = Color.white;
            item.sprite = levelSprites[level-2];
        }
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddLevelReward()
    {
        player.stats.Buy(-level*100);
    }
}

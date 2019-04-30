using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private void Awake()
    {
        _instance = this;
        player = FindObjectOfType<Player>();

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
        Debug.Log("GameOver!");
    }
}

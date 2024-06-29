using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject BossBlock;
    public GameObject gameOverUI;

    public static GameManager Instance
    {
        get => instance;
    }
    private static GameManager instance;
    private int coin;
    //
    public UnityEvent<int> coinEvent;
    public UnityEvent<int> coinEventUpdate;

    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        if (coinEvent == null)
        {
            coinEvent = new UnityEvent<int>();
        }
        if (coinEventUpdate == null)
        {
            coinEventUpdate = new UnityEvent<int>();
        }
    }
    private void Start()
    {
        this.coin = DataManager.DataCoin;
        coinEvent.AddListener(AddCoin);
        BossBlock.SetActive(false);
    }
    public void AddCoin(int coin)
    {
        this.coin += coin;
        DataManager.DataCoin = this.coin;
        coinEventUpdate?.Invoke(this.coin);
    }
    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }
}
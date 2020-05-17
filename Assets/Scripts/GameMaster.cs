using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gameMaster;

    private static int _maxLives = 3;
    private static int _remainingLives = _maxLives;
    public static int RemainingLives
    {
        get { return _remainingLives; }
    }

    //public Image[] hearts;
    //public Sprite heartSprite;
    //public static int numOfHearts = _maxLives;

    [SerializeField]
    private GameObject gameOverUI;

    void Start()
    {
        if (gameMaster == null)
        {
            gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        }
    }

    //void Update()
    //{
    //    for(int i=0;i<hearts.Length;i++)
    //    {
    //        if(i<numOfHearts)
    //        {
    //            hearts[i].enabled = true;
    //        }
    //        else
    //        {
    //            hearts[i].enabled = false;
    //        }
    //    }
    //}

    public void EndGame(Player player)
    {
        Debug.Log("GAME OVER");
        Destroy(player.gameObject);

        gameOverUI.SetActive(true);
        _remainingLives = _maxLives;
        //numOfHearts = 3;
    }

    //public Transform playerPrefab;
    //public Transform respawnPoint;

    //public void RespawnPlayer()
    //{
    //    Instantiate(playerPrefab, respawnPoint.position, respawnPoint.rotation);
    //}

    public static void killPlayer(Player player)
    {

        _remainingLives--;
        //numOfHearts--;
        if (_remainingLives <= 0)
        {
            gameMaster.EndGame(player);
        }
        //gameMaster.RespawnPlayer();
    }

    
}

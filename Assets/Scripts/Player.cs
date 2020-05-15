using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public class PlayerStats
    {
        public int maxHealth = 3;
        private int _currentHealth;
        public int currentHealth
        {
            get { return _currentHealth; }
            set { _currentHealth = Mathf.Clamp(value, 0, maxHealth); }
        }

        public void init()
        {
            _currentHealth = maxHealth;
        }
    }

    public PlayerStats playerStats = new PlayerStats();

    [SerializeField]
    private StatusIndicator statusIndicator;

    void Start()
    {
        playerStats.init();

        if(statusIndicator==null)
        {
            Debug.LogError("No status referenced on player.");
        }
        else
        {
            statusIndicator.setHealth(playerStats.currentHealth, playerStats.maxHealth);
        }
    }

    public void damagePlayer(int damage)
    {
        playerStats.currentHealth -= damage;

        if(playerStats.currentHealth<=0)
        {
            GameMaster.killPlayer(this);
        }

        statusIndicator.setHealth(playerStats.currentHealth, playerStats.maxHealth);
    }
}

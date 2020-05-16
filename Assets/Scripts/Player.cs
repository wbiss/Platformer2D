using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //public HealthBar healthBar;

    [System.Serializable]
    public class PlayerStats
    {
        public HealthBar healthBar;

        public int maxHealth = 3;
        private int _currentHealth;
        public int currentHealth
        {
            get { return _currentHealth; }
            set { _currentHealth = Mathf.Clamp(value, 0, maxHealth); }
        }

        public void Init()
        {
            _currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }
    }

    public PlayerStats playerStats = new PlayerStats();

    [SerializeField]
    private StatusIndicator statusIndicator;

    void Start()
    {
        playerStats.Init();

        if(statusIndicator==null)
        {
            Debug.LogError("No status referenced on player.");
        }
        else
        {
            statusIndicator.SetHealth(playerStats.currentHealth, playerStats.maxHealth);
        }
    }


    public void DamagePlayer(int damage)
    {
        playerStats.currentHealth -= damage;
        playerStats.healthBar.SetHealth(playerStats.currentHealth+1);

        if (playerStats.currentHealth<=0)
        {
            GameMaster.killPlayer(this);
        }

        statusIndicator.SetHealth(playerStats.currentHealth, playerStats.maxHealth);
    }
}

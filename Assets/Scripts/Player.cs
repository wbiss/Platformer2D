using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Rigidbody2D playerBody;
    //public float jumpVelocity = 10;

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
        playerStats.healthBar.SetHealth(playerStats.currentHealth);
        playerStats.currentHealth -= damage;

        if (playerStats.currentHealth<=0)
        {
            GameMaster.killPlayer(this);
        }

        statusIndicator.SetHealth(playerStats.currentHealth, playerStats.maxHealth);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyPatrol _enemyPatrol = collision.collider.GetComponent<EnemyPatrol>();
        if (_enemyPatrol != null)
        {
            foreach (ContactPoint2D point in collision.contacts)
            {
                if (point.normal.y >= 0.9f)
                {
                    //Vector2 velocity = playerBody.velocity;
                    //velocity = jumpVelocity*Vector2.up;
                    //playerBody.velocity = velocity;
                    _enemyPatrol.KillEnemy();
                }
                else
                {
                    DamagePlayer(_enemyPatrol.enemyStats.damage);
                }
            }
        }
        EnemyFly _enemyFly = collision.collider.GetComponent<EnemyFly>();
        if (_enemyFly != null)
        {
            foreach (ContactPoint2D point in collision.contacts)
            {
                if (point.normal.y >= 0.9f)
                {
                    //Vector2 velocity = playerBody.velocity;
                    //velocity = jumpVelocity*Vector2.up;
                    //playerBody.velocity = velocity;
                    _enemyFly.KillEnemy();
                }
                else
                {
                    DamagePlayer(_enemyFly.enemyStats.damage);
                }
            }
        }
       
    }
}

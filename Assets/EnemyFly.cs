using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : MonoBehaviour
{
    public Animator animator;

    Vector3 origin;
    Transform _trans;

    [System.Serializable]
    public class EnemyStats
    {
        public int maxHealth = 1;
        private int _currentHealth;
        public int currentHealth
        {
            get { return _currentHealth; }
            set { _currentHealth = Mathf.Clamp(value, 0, maxHealth); }
        }

        public int damage = 1;

        public void Init()
        {
            _currentHealth = maxHealth;
        }
    }

    private bool shouldMove = true;
    public float speed;

    public EnemyStats enemyStats = new EnemyStats();

    [Header("Optional: ")]
    [SerializeField]
    private StatusIndicator statusIndicator;

    // Start is called before the first frame update
    void Start()
    {
        enemyStats.Init();
        _trans = GetComponent<Transform>();
        origin = _trans.position;
        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(enemyStats.currentHealth, enemyStats.maxHealth);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldMove)
        {
            _trans.position = new Vector3(origin.x, origin.y + speed*Mathf.PingPong(Time.time, 1), origin.z);
        }
        
    }

    public void KillEnemy()
    {
        animator.SetBool("IsDead", true);
        shouldMove = false;
        Destroy(this.gameObject, 0.2f);
    }
}

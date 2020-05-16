using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
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


    public float speed;
    private bool movingLeft = true;
    public Transform edgeDetection;

    public EnemyStats enemyStats = new EnemyStats();

    [Header("Optional: ")]
    [SerializeField]
    private StatusIndicator statusIndicator;

    // Start is called before the first frame update
    void Start()
    {
        enemyStats.Init();

        if(statusIndicator!=null)
        {
            statusIndicator.SetHealth(enemyStats.currentHealth, enemyStats.maxHealth);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        RaycastHit2D edgeInfo = Physics2D.Raycast(edgeDetection.position,Vector2.down,2.0f);
        if(edgeInfo.collider==false)
        {
            if(movingLeft==true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingLeft = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D _colInfo)
    {
        Player _player = _colInfo.collider.GetComponent<Player>();

        if(_player!=null)
        {
            _player.DamagePlayer(enemyStats.damage);
        }
    }
}

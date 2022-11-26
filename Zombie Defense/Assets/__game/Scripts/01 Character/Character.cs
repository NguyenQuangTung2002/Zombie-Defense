using System.Linq;
using UnityEngine;

public class Character : MonoBehaviour,CharData, Damageable
{
    public static Character Instance;

    #region Data
    
    public int lvHealth { get; set; }
    public int lvDamage { get; set; }
    public int lvSpeed { get; set; }
    public int indexDrone { get; set; }
    public int indexSkin { get; set; }
    public int indexWeapon { get; set; }
    
    #endregion
    
    public Rigidbody rb;
    public Animator animator;

    private int maxHealth;
    public int currentHealth;
    public float speed;
   
    public Weapon currentWeapon;
    private Enemy closestEnemy;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private BoardLVChar boardLv;

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        lvSpeed = 0;
        lvHealth = 0;

    }

    void Init()
    {
        Debug.Log(boardLv);
        
        speed = boardLv.entities[lvSpeed].speed;
        maxHealth = boardLv.entities[lvHealth].health;
        currentHealth = maxHealth;
        /*speed = 10f;
        maxHealth = 100;
        currentHealth = 100;*/
    }

    private void Start()
    {
        Init();
    }

    public void Move(Vector3 movement)
    {
        rb.velocity = movement * speed;
    }

    public void Look(Vector3 movement)
    {
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(
            transform.forward, movement.normalized, 20f * Time.deltaTime, 0f));
    }

    public void GetEnemy(Damageable target)
    {
        if (target != null)
        {
            closestEnemy = (Enemy)target;
        }
    }

    public void Attack()
    {

        if (closestEnemy == null) return;
        currentWeapon.Attack(closestEnemy);
    }
    
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            CharController.Instance.ChangeState(CharState.Dead);
            healthBar.UpdateHealThBar(0);
        }
        else
        {
            healthBar.UpdateHealThBar((float) currentHealth / (float) maxHealth);
        }
    }
    
    public Transform GetTransform()
    {
        return transform;
    }

    #region Effect

    public void PlayAttackEffect(string key)
    {
        if(currentWeapon.effectAttack.ContainsKey(key))
        {
            var effect = currentWeapon.effectAttack[key];
            
            if(!effect.gameObject.activeSelf) effect.gameObject.SetActive(true);
            currentWeapon.effectAttack[key].Play();
        }

        if (closestEnemy != null) Attack();
    }

    #endregion
}
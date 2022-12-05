using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, Damageable
{
    public AttackRadius attackRadius;

    private int maxHealth;
    private int currentHealth;
    public float speed;
    public int damage = 3;

    public NavMeshAgent Nav;
    private Damageable targetToDamage;
    private Animator animator;


    [SerializeField] private HealthBar healthBar;

    void Awake()
    {
        Nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        attackRadius.OnAttack += GetTarget;
    }

    private void Start()
    {
        Nav.speed = speed;
        currentHealth = 100;
        maxHealth = 100;
        GetComponentInChildren<AttackRadius>().timeLoadDelay = 1.3f;
    }
    

    public void Init()
    {
        currentHealth = maxHealth;
        healthBar.UpdateHealThBar(1);
    }

    private void OnEnable()
    {
        animator.SetBool("IsFindPlayer", true);
    }

    void Update()
    {
        switch (CharController.Instance.stateController.currentCharState)
        {
            case CharState.Dead:
                Nav.isStopped = true;
                animator.SetTrigger("IsWin");
                break;
            case CharState.Revive:
                Nav.SetDestination(Character.Instance.transform.position);
                animator.SetTrigger("IsIdle");
                break;
            default:
                Move();
                break;

        }
    }

    void Move()
    {
        Nav.SetDestination(Character.Instance.transform.position);
    }

    public void GetTarget(Damageable target)
    {
        if (target != null)
        {
            animator.SetBool("IsAttack", true);
            targetToDamage = target;
        }
        else
        {
            animator.SetBool("IsAttack", false);
            targetToDamage = null;
        }
    }

    public void AttackEvent()
    {
        if (targetToDamage != null && CharController.Instance.stateController.currentCharState != CharState.Dead)
        {
            targetToDamage.TakeDamage(damage);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            healthBar.UpdateHealThBar(0);
            gameObject.SetActive(false);

            EnemyManager.Instance.numDeadEnemy++;
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
}
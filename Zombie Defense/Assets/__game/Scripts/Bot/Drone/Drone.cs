using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class Drone : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public AttackRadius attackRadius;
    private Character owner;
    private Damageable targetToDamage;
    public Weapon currentWeapon;
    private int id = -1;
    public float radiusBehindOwner = 2f;
    private Transform transPlayer;
    private float speed = 7f;

    private Vector3 offsetLastPosition;
    private Vector3 currentWeaponRotation;
    private float offsetTimeDelay = 3f;
    private float offsetTimeCounter = 0f;
    

    public int Id { get => id; set => id = value; }
    public Animator Animator { get => animator; }
    private Vector3 target;

    private void Awake()
    {
        attackRadius.OnAttack += AutoAttack;
        //gameObject.SetActive(false);
    }

    private void Start()
    {
        transPlayer = Character.Instance.transform;
        transform.position = transPlayer.position+ GetOffsetPositionTowardOwner();
        owner = Character.Instance;
        gameObject.SetActive(true);
        currentWeapon = GetComponentInChildren<Weapon>();
    }

    public void Init()
    {
        transPlayer = Character.Instance.transform;
        transform.position = transPlayer.position+ GetOffsetPositionTowardOwner();
        owner = Character.Instance;
        gameObject.SetActive(true);
        currentWeapon = GetComponentInChildren<Weapon>();
        //animator.SetTrigger(CharacterAction.Action.ToAnimatorHashedKey());
    }
    
    private void FixedUpdate()
    {
        if (!owner)
            return;

        /*if (GameManager.Instance.IsLevelLoading)
            return;*/
        
        FollowTarget();
        RotateWeapon();

        //float distance = Vector3.Distance(transPlayer.position, transform.position);

    }

    private void FollowTarget()
    {

        if (Vector3.Distance(transPlayer.position, transform.position) > 4 || targetToDamage == null)
        {

            target = GetOffsetPositionTowardOwner() + transPlayer.position;
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            transform.LookAt(transform.position + transPlayer.forward);
        }
        else if(targetToDamage != null)
        {
            transform.LookAt(target -transform.position);
            target = GetOffsetPositionTowardOwner() + targetToDamage.GetTransform().position;
        }
    }

    private Vector3 GetOffsetPositionTowardOwner()
    {
        if (offsetTimeCounter > 0)
        {
            offsetTimeCounter -= Time.deltaTime;
            return offsetLastPosition;
        };
        offsetTimeCounter = offsetTimeDelay;

        Vector3 behindOwnerDirection = -transPlayer.forward;
        float angleOffsetTowardOwner = VectorUlti.GetAngleFromVector(behindOwnerDirection) + Random.Range(-90, 90);
        Vector3 directionTowardOwner = VectorUlti.GetVectorFromAngle(angleOffsetTowardOwner).Set(y: 0).normalized;
        offsetLastPosition = (directionTowardOwner * radiusBehindOwner);

        return offsetLastPosition;
    }



    void RotateWeapon()
    {
        if (targetToDamage == null)
        {
            currentWeapon.transform.localRotation = Quaternion.identity;
        }
        else
        {
            Vector3 vectorTarget = targetToDamage.GetTransform().position - currentWeapon.transform.position;
            vectorTarget.y += 1f;
        
            currentWeapon.transform.rotation =  Quaternion.LookRotation(Vector3.RotateTowards(
                currentWeapon.transform.forward, vectorTarget.normalized, 
                10f * Time.deltaTime, 0f));
        }
    }
    
    void AutoAttack(Damageable target)
    {
        if (target != null)
        {
            targetToDamage = target;
            
            if (targetToDamage.GetTransform().gameObject.activeSelf)
            {
                currentWeapon.Attack(targetToDamage);
            }
        }
        else
        {
            targetToDamage = null;
        }
    }

    
    public void ChangeWeapon(Weapon weapon)
    {
        currentWeapon = weapon;
    }
    
}

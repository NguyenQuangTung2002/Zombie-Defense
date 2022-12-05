using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    private Transform defaultTransform;
    public int damage { get; set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        if (Vector3.Distance(Character.Instance.transform.position, transform.position) > 20)
        {
            gameObject.SetActive(false);
        }
    }

    public void Move(float speed,Vector3 vecterVel)
    {
        rb.velocity = vecterVel * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}

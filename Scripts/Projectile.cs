using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    protected float moveSpeed;

    protected Character attacker;
    protected Character defender;
    protected Rigidbody2D rb;

    protected void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    protected void Update()
    {
        if(defender)
        {
            Move();
        }
        else
        {
            gameObject.SetActive(false);
        }
        
    }

    protected void Move()
    {
        Vector2 movement = defender.transform.position - transform.position;
        movement = movement.normalized;
        rb.velocity = movement * moveSpeed;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == defender.GetComponent<Collider2D>())
        {
            gameObject.SetActive(false);
            Batler.CalculateAttackResult(attacker, defender);
        }
    }

    public void SetInfoForBatler(Character newAttacker, Character newDefender)
    {
        attacker = newAttacker;
        defender = newDefender;
    }
}

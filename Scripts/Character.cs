using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField]
    protected float maxHealth,
        attackDamage,
        defence,
        moveSpeed,
        attackSpeed,
        attackRange,
        attackAnimationDuration;
    [SerializeField]
    protected GameObject healthBar;
    [SerializeField]
    protected Image bar;

    protected float currentHealth;
    protected float attackReloadTime;
    protected Rigidbody2D rb;
    protected Animator animator;
    protected Vector2 movement;
    protected Character enemy;
    protected Transform enemyTransform;
    protected Coroutine waitForAnimationEnd;

    protected virtual void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        currentHealth = maxHealth;
    }
    protected void Update()
    {
        attackReloadTime -= Time.deltaTime;
        bar.fillAmount = this.currentHealth / this.maxHealth;
        enemyTransform = EnemyFinder.FindEnemy(this);

        if (enemyTransform != null)
        {
            enemy = enemyTransform.GetComponent<Character>();

            if (Vector2.Distance(enemyTransform.position, transform.position) > attackRange)
            {
                animator.SetBool("Attacking", false);
                Move();
            }
            else if (attackReloadTime <= 0)
            {
                rb.velocity = new Vector2(0, 0);
                animator.SetBool("Moving", false);
                PlayAttackAnimation();
                attackReloadTime = 1 / attackSpeed;
            }
            else
            {
                Idle();
            }
        }
        else
        {
            if (waitForAnimationEnd != null)
            {
                StopCoroutine(waitForAnimationEnd);
            }
            
            Idle();
        }
    }

    protected void Move()
    {
        animator.SetBool("Moving", true);
        movement = enemyTransform.position - transform.position;
        movement = movement.normalized;
        rb.velocity = movement * moveSpeed;
        Quaternion rot = transform.rotation;

        if (movement.x > 0)
        {  
            rot.y = 180;
        }
        else
        {
            rot.y = 0;
        }

        transform.rotation = rot;
    }

    protected void Idle()
    {
        rb.velocity = new Vector2(0, 0);
        animator.SetBool("Moving", false);
        animator.SetBool("Attacking", false);
    }

    public void TakeDamage(float damage)
    {
        this.currentHealth -= damage;
    }

    public void Die()
    {
        this.gameObject.AddComponent<DeadCharacter>();
        Destroy(healthBar);
        Destroy(this);
    }

    public void SetEnemy(Character newEnemy)
    {
        this.enemy = newEnemy;
    }

    public float GetHealth()
    {
        return this.currentHealth;
    }

    public float GetAttackDamage()
    {
        return this.attackDamage;
    }

    public float GetDefence()
    {
        return this.defence;
    }

    protected void PlayAttackAnimation()
    {
        animator.SetBool("Attacking", true);
        waitForAnimationEnd = StartCoroutine(WaitForAnimationEnd(attackAnimationDuration));
    }

    protected IEnumerator WaitForAnimationEnd(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        animator.SetBool("Attacking", false);
        Attack();
    }

    protected virtual void Attack()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ProjectileAttackCharacter : Character
{
    [SerializeField]
    protected GameObject 
        projectile,
        weapon;

    protected List<GameObject> projectilePool;

    protected override void Awake()
    {
        base.Awake();
        projectilePool = new List<GameObject>();
    }

    protected override void Attack()
    {
        bool isBulletExists = false;

        for (int i = 0; i < projectilePool.Count; i++)
        {
            if (!projectilePool[i].activeInHierarchy)
            {
                projectilePool[i].transform.position = weapon.transform.position;
                projectilePool[i].transform.rotation = weapon.transform.rotation;
                projectilePool[i].GetComponent<Projectile>().SetInfoForBatler(this, enemy);
                projectilePool[i].SetActive(true);
                isBulletExists = true;
                break;
            }
        }

        if (!isBulletExists)
        {
            projectilePool.Add(Instantiate(projectile, weapon.transform.position, weapon.transform.rotation));
            projectilePool[projectilePool.Count - 1].GetComponent<Projectile>().SetInfoForBatler(this, enemy);
        }
    }
}

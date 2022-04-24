using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public int currentLife;
    [SerializeField] public BossHealthBar healthBar;

    protected override void Start()
    {
        base.Start();
        healthBar = GameObject.Find("BossHealthBar").GetComponent<BossHealthBar>();
        currentLife = life;
        healthBar.setMaxHealth(life);
    }

    protected override void Hurt(int receivedDamage)
    {
        if (isHit == false)
        {
            currentLife -= receivedDamage;
            healthBar.setHealth(currentLife);
            if (life < 1)
            {
                score.UpdateScore(points);
                spawn.spawnedEnemies--;
                Destroy(this.gameObject);
            }
        }
    }
}

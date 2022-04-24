using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : Enemy
{
    public int currentLife;
    [SerializeField] public BossHealthBar healthBar;
    private Image fill;
    private Image doggo;
    private Image border;

    protected override void Start()
    {
        base.Start();
        healthBar = GameObject.Find("BossHealthBar").GetComponent<BossHealthBar>();
        currentLife = life;
        healthBar.setMaxHealth(life);
        doggo=GameObject.Find("Doggo").GetComponent<Image>();
        border = GameObject.Find("Border").GetComponent<Image>();
        fill = GameObject.Find("Fill").GetComponent<Image>();
        doggo.enabled = true;
        fill.enabled = true;
        border.enabled = true;
    }

    protected override void Hurt(int receivedDamage)
    {
        if (isHit == false)
        {
            currentLife -= receivedDamage;
            healthBar.setHealth(currentLife);
            if (currentLife < 1)
            {
                score.UpdateScore(points);
                spawn.spawnedEnemies--;
                Destroy(this.gameObject);
            }
        }
    }
}

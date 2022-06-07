using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Olympvs
{
    public class EnemyStats : CharacterStats
    {
        Animator animator;
        EnemyBossManager enemyBossManager;
        public bool isBoss; 

        private void Awake() 
        {
            animator = GetComponentInChildren<Animator>();
            enemyBossManager = GetComponent<EnemyBossManager>();
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
        }

        void Start() 
        {
            if (!isBoss)
            {

            }
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        public void TakeDamage(int damage)
        {
            if (isDead)
            {
                return;
            }
            currentHealth = currentHealth - damage;

            animator.Play("Damage_01");

            if (!isBoss)
            {

            }
            else if (isBoss && enemyBossManager != null)
            {
                enemyBossManager.UpdateBossHealthBar(currentHealth);
            }

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                isDead = true;
                HandleDead();
            }
        }

        public void HandleDead()
        {
            
            StartCoroutine(WaitDead());
            
        }

        IEnumerator WaitDead()
        {
            animator.Play("Dead_01");
            yield return new WaitForSecondsRealtime(5f);
            Destroy(gameObject);
        }
    }
}

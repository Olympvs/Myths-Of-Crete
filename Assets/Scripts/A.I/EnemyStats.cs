using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Olympvs
{
    public class EnemyStats : CharacterStats
    {
        Animator animator;
        EnemyBossManager enemyBossManager;
        public AudioSource audio;
        public AudioClip hit;
        public AudioSource deathAudio;
        public AudioClip death;
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
            audio.PlayOneShot(hit);

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
                deathAudio.PlayOneShot(death);
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
            if (isBoss)
            {
                SceneManager.LoadScene(6);
            }
        }
    }
}

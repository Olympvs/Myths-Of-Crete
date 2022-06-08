using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderControl : MonoBehaviour
{
    public ParticleSystem collisionParticleSystem;
    public GameObject gameObject;
    public AudioSource audioSource;
    public AudioClip audioThunder;
    public bool once = true;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && once)
        {
            var em = collisionParticleSystem.emission;
            var dur = collisionParticleSystem.duration;

            em.enabled = true;
            collisionParticleSystem.Play();
            audioSource.PlayOneShot(audioThunder);


            once = false;
            Destroy(gameObject);
            Invoke(nameof(DestroyObj), dur);
            StartCoroutine(StopParticleSystem(collisionParticleSystem, 1));
        }


    }

    IEnumerator StopParticleSystem(ParticleSystem collisionParticleSystem, float time)
    {
        yield return new WaitForSeconds(time);
        collisionParticleSystem.Stop();
    }

    void DestroyObj()
    {
        Destroy(gameObject);
    }
}

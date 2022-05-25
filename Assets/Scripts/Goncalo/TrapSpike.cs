using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Olympvs
{
    public class TrapSpike : MonoBehaviour
    {
    
    public List<PlayerStats> PlayerStatus = new List<PlayerStats>();
    public List<Spike> ListSpikes = new List<Spike>();

    Coroutine SpikeTriggerRoutine;

    bool SpikesReloaded;

    // Start is called before the first frame update
    public void Start()
    {
        SpikeTriggerRoutine = null;
        SpikesReloaded = true;
        PlayerStatus.Clear();
        ListSpikes.Clear();  

        Spike[] arr = this.gameObject.GetComponentsInChildren<Spike>();
        foreach(Spike s in arr)
        {
            ListSpikes.Add(s);
        }
    }

    private void Update()
    {
        if (PlayerStatus.Count != 0)
        {
            foreach (PlayerStats control in PlayerStatus)
            {
                if (SpikeTriggerRoutine == null && SpikesReloaded)
                {
                    SpikeTriggerRoutine = StartCoroutine(_TriggerSpikes());
                }
                
            }
        }
    }

    IEnumerator _TriggerSpikes()
    {
        Debug.Log("spikes triggered!");
        SpikesReloaded = false;

        foreach(Spike s in ListSpikes)
        {
            s.Shoot();
        }

        yield return new WaitForSeconds(1f);

        foreach (Spike s in ListSpikes)
        {
            s.Retract();
        }

        yield return new WaitForSeconds(1f);

        SpikeTriggerRoutine = null;
        SpikesReloaded = true;
    }

    public static bool isTrap(GameObject obj)
    {
        if (obj.transform.root.gameObject.GetComponent<TrapSpike>() == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerStats control = other.GetComponent<PlayerStats>();

        //int damage = 25;
        
        if (control != null)
        {
            if (!PlayerStatus.Contains(control))
            {
                PlayerStatus.Add(control);
                //control.TakeDamage(damage);
                //SceneManager.LoadScene(0); if player hits the trap dies and reloads the scene 
                
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerStats control = other.gameObject.transform.root.gameObject.GetComponent<PlayerStats>();

        if (control != null)
        {
            if (PlayerStatus.Contains(control))
            {
                PlayerStatus.Remove(control);
                //Add damage here when he exits the collision with the spikes
            }
        }
    }
    }
}


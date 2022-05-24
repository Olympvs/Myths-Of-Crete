using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public Transform cam;
    public float playerActivationDistance;
    bool active = false;

    private void Update()
    {
        RaycastHit hit;
        active = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, playerActivationDistance);

        if(Input.GetKeyDown(KeyCode.F) && active == true)
        {
            if(hit.transform.GetComponent<Animator>() != null)
            {
                hit.transform.GetComponent<Animator>().SetTrigger("Activation");
            }
        }
    }
}

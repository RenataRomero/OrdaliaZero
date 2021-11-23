using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : IntectativeObject
{

    // Update is called once per frame
    void Update()
    {
        if (isClose && Input.GetButton("Interact"))
        {
            foreach (GameObject objectListerner in objectsListeners)
            {
                AudioSource listenerAudio = objectListerner.GetComponent<AudioSource>();

                objectListerner.SetActive(false);

                if (listenerAudio != null)
                {
                    listenerAudio.Play();
                }
            }
        }
    }
}

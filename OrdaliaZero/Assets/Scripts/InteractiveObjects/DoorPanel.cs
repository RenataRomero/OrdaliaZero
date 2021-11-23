using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPanel : IntectativeObject
{
    // Update is called once per frame
    void Update()
    {
        if (isClose && Input.GetButton("Interact"))
        {
            foreach (GameObject objectListerner in objectsListeners)
            {
                Animator listenerAnimator = objectListerner.GetComponent<Animator>();
                AudioSource listenerAudio = objectListerner.GetComponent<AudioSource>();
                if (listenerAnimator != null)
                {
                    listenerAnimator.SetTrigger("Open");
                }

                if (listenerAudio != null)
                {
                    listenerAudio.Play();
                }
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class  IntectativeObject : MonoBehaviour
{
    [SerializeField]
    GameObject image;
    [HideInInspector]
    public bool isClose = false;
    [SerializeField]
    public GameObject[] objectsListeners;

    private void OnTriggerEnter(Collider other)
    {
         if (other.tag == "Player")
        {
            isClose = true;
            image.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isClose = false;
            image.SetActive(false);
        }
    }

}

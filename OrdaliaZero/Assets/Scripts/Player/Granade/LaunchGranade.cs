using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchGranade : MonoBehaviour
{
    //Variables;
    public Transform spawnPoint;
    public GameObject granade;

    [SerializeField]
    TMPro.TextMeshProUGUI currentGranadeText;
    int granadeCounter = 3;

    float range = 10f;
    // Start is called before the first frame update
    void Start()
    {
        currentGranadeText.text = granadeCounter.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q) && granadeCounter > 0)
        {
            Launch();
            granadeCounter--;
            currentGranadeText.text = granadeCounter.ToString();
        }
            

    }
    //Method

    private void Launch()
    {
        GameObject granadeInstance = Instantiate(granade, spawnPoint.position, spawnPoint.rotation);
        granadeInstance.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * range, ForceMode.Impulse);
    }
}

using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    private float sensitivity = 0.03f;

    private CinemachineComposer composer;
    [SerializeField]
    MenuPause pauseMenu;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        composer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineComposer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!pauseMenu.gameIsPaused) {
            float vertical = Input.GetAxis("Mouse Y") * sensitivity;

            composer.m_TrackedObjectOffset.y += vertical;
            composer.m_TrackedObjectOffset.y = Mathf.Clamp(composer.m_TrackedObjectOffset.y, -90, 90);
            Ray ray = Camera.main.ViewportPointToRay(composer.FollowTargetPosition);
            Debug.DrawLine(ray.origin, ray.direction, Color.blue);
        }
        
    }
}

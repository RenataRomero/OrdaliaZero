using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public event System.Action<Player> OnLocalPlayerJoined;

    private GameObject gameObject;
    private static GameManager m_Instance;
    private Player m_localPlayer;
    public Player LocalPlayer {
        get {
            return m_localPlayer;
        }
        set {
            m_localPlayer = value;
            if (OnLocalPlayerJoined != null) {
                OnLocalPlayerJoined(m_localPlayer);
            }
        }
    }
    public static GameManager Instance {
        get {
            if (m_Instance == null) {
                m_Instance = new GameManager();
                m_Instance.gameObject = new GameObject("_gameManager");
                m_Instance.gameObject.AddComponent<InputController>();
            }

            return m_Instance;
        }
    }

}

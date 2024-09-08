using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using Unity.Networking.Transport;

public class LobbyMenu : MonoBehaviour
{
    [SerializeField] private Button _hostButton;
    [SerializeField] private Button _clientButton;

    void Start()
    {
        _hostButton.onClick.AddListener(HostButtonClicked);
        _clientButton.onClick.AddListener(ClientButtonClicked);
    }

    private void HostButtonClicked() {
        NetworkManager.Singleton.StartHost();
        gameObject.SetActive(false);
    }

    private void ClientButtonClicked() {
        NetworkManager.Singleton.StartClient();
        gameObject.SetActive(false);
    }
}

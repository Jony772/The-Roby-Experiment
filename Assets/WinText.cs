using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class WinText : MonoBehaviour
{
    public string nameofWinner;
    public TextMeshProUGUI TextPro;

    void Start()
    {

    }
    [PunRPC]
    void Update()
    {
        nameofWinner = PlayerPrefs.GetString("username");
        TextPro.text = "The winner is: " + nameofWinner;
    }
}

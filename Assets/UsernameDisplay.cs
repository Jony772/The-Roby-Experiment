using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class UsernameDisplay : MonoBehaviourPunCallbacks
{
    [SerializeField] PhotonView playerPV;
    [SerializeField] TMP_Text text;
    string displayName;
    //[SerializeField] string name2;

    //public string nameofWinner;
    //public TextMeshProUGUI TextPro;
    //[PunRPC]
    void Start()
    {
        //name2 = PhotonNetwork.NickName;
        //if(!playerPV.IsMine)
            //return;
        //{  
        //name2 = PhotonNetwork.NickName;
 
        //text.text = displayName;
        //nameofWinner = PlayerPrefs.GetString("username");
       // text.text = name2;
        //TextPro.text = name2;
       // TextPro.text = nameofWinner;
       // }
    }

    void Update()
    {
        displayName = playerPV.Owner.NickName;
        //displayName = PlayerPrefs.GetString("username");
        text.text = displayName;
        //nameofWinner = PlayerPrefs.GetString("username");
        //TextPro.text = nameofWinner;
    }

}

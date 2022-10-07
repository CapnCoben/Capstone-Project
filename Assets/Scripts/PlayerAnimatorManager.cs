using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerAnimatorManager : MonoBehaviourPun
{
    private Animator animator;

    //#region MonoBehaviour Callbacks


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (!animator)
        {
            Debug.LogError("PlayerAnimatorManager is Missing Animator Component", this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }

        if (!animator)
        {
            return;
        }

        //Place User input here and animations

        
    }
}

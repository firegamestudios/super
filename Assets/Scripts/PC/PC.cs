using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using MalbersAnimations.Controller;
using MalbersAnimations;
using MalbersAnimations.Events;

namespace FireGameStudios
{
    public class PC : MonoBehaviour
    {
        //Malbers
        MAnimal animal;
        MalbersInput malbersInput;
        MEventListener eventListener;

        PhotonView photonView;

        //My Components
        Transform internalComponents;
        GameObject cameraTarget;

        private void Awake()
        {
            //Make sure we define PhotonView first
            photonView = GetComponent<PhotonView>();

            //Get the animal reference
            animal = GetComponent<MAnimal>();
            malbersInput = GetComponent<MalbersInput>();
            eventListener = GetComponent<MEventListener>();

            //First setups for the local player (Important to initialize before Start because of the Camera)
            if (photonView.IsMine)
            {
                //Make sure we start the local player as soon as possible so the camera can get it
                animal.isPlayer.Value = true;
                MAnimal.MainAnimal = animal;
            }
            else
            {

            }

            //Internal Components
            internalComponents = transform.GetChild(0);
            cameraTarget = internalComponents.Find("CM Main Target").gameObject;

        }

        // Start is called before the first frame update
        void Start()
        {

            // Check if the local player controls this character
            if (!photonView.IsMine)
            {
                print("Make sure we're runnning Start on remote");

                // Disable components if this character is controlled by another player
                if (animal != null)
                    animal.enabled = false;

                if (malbersInput != null)
                    Destroy(malbersInput);

                if (eventListener != null)
                    Destroy(eventListener);

                cameraTarget.SetActive(false);

                //Remove this animal as the Main Player (affects Camera controls)
                animal.isPlayer.Value = false;
            }
            //this is the local player - late setup here
            else
            {

            }
        }
        // Update is called once per frame
        void Update()
        {

        }
    } 
}

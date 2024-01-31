using UnityEngine;
using Photon.Pun;
using MalbersAnimations;
using MalbersAnimations.Controller;

public class SpawnManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    public Transform[] spawnPoints;

    public ThirdPersonFollowTarget followTarget;

    GameObject localPlayer;

    void Start()
    {
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        int randomPoint = Random.Range(0, spawnPoints.Length);
        
        //Spawn the player instance
        localPlayer = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoints[randomPoint].position, Quaternion.identity);
        MAnimal animal = localPlayer.GetComponent<MAnimal>();
        animal.isPlayer.Value = true;
        MAnimal.MainAnimal = animal;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [SerializeField]
    private GameObject shootingPrefab;
    [SerializeField]
    private float atkCooldown=0.3f;
    private float atkTimer;
    private AudioSource audioSource;
    private Camera mainCamera;
    private Vector3 spawnLocation;
    private ShootAnim shootAnim;
    private void Awake() {
        audioSource = GetComponent<AudioSource>();
        mainCamera = Camera.main;
        shootAnim = GetComponent<ShootAnim>();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && (Time.time > atkTimer))
        {
            Shoot();
            audioSource.Play();
            // ShootAnim.instance.audioSource.Play();
            ShootAnim.instance.PlaySound();
            atkTimer = Time.time + atkCooldown;
        }
    }
    void Shoot(){
        spawnLocation = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        spawnLocation.z=0f;
        Instantiate(shootingPrefab,spawnLocation,Quaternion.identity); 

    }
}

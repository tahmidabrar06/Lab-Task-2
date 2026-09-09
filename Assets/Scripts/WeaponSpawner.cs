using System;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    private Player playerScript;
    [SerializeField]
    private GameObject weapon, weaponModel;
    [SerializeField]
    private float respawnTime = 5;
    private float respawnTimer;
    private bool timerStart = false;
    
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timerStart == true)
        {
            respawnTimer += Time.deltaTime;
            if(respawnTimer >= respawnTime)
            {
                weaponModel.SetActive(true);
                timerStart = false;
                respawnTimer = 0;
            }
        }
        else
        {
            weaponModel.transform.Rotate(Vector3.up * 50 * Time.deltaTime,Space.World);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !timerStart)
        {
            playerScript.setWeapon(weapon);
            weaponModel.SetActive(false);
            timerStart = true;
        }
    }
}

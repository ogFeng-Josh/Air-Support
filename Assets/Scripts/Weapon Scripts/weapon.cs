using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class weapon : MonoBehaviour
{
    //Bullet direction 
    public Transform frontCannon;
    
    //Bullet fire Audio
    private AudioSource mAudioSrc;
    //SET UP ABOUT 3 AUDIO SOURCES INCASE!
    //Background, gun, and soundeffects!

    //Ammo refilled boolean
    private bool ammoRefilled = true;

    //Weapon switching delay to prevent fast toggling
    //bool switched = false;
    //Set scene instead of using boolean due to gameMaster taking input of weapon switching
    //Tasks reference 12 ^^^

    //minigun weapon members
    public GameObject minigunWeapon; //Takes HUD as a gameobject 
    public GameObject minigunBullets; //Takes Prefab of bullet
    private bool mingunChamber = true; //Chambered bullet for TBS (Time between shots)
    public AudioClip miniGun; //Audio clip for minigun (Reference tasks 11)

    //bofor weapon members
    public GameObject boforWeapon; //Takes HUD as a gameobject 
    public GameObject boforBullets; //Takes Prefab of bullet
    private bool boforChamber = true; //Chambered bullet for TBS (Time between shots)
    private int minigunAmmoCount = 130; //Ammo counter before reload sequence begins
    public AudioClip fortyMM; //Audio clip for minigun (Reference tasks 11)

    //howitzer weapon members
    public GameObject howitzerWeapon; //Takes HUD as a gameobject 
    public GameObject howitzerBullets; //Takes Prefab of bullet
    private bool howitzerChamber = true; //Chambered bullet for TBS (Time between shots)
    private int boforAmmoCount = 8; //Ammo counter before reload sequence begins
    public AudioClip oneFivemm; //Audio clip for minigun (Reference tasks 11)

    //Functions Definitions Below

    void Start()
    {
        mAudioSrc = GetComponent<AudioSource>();
    }

    //Update functions for definitions
    void Update()
    {

        //=====================================================================================================
        //Weapon Minigun
        if (Input.GetMouseButton(0) && mingunChamber == true && minigunWeapon.activeSelf == true && ammoRefilled == true)
        {
           
            if (minigunAmmoCount == 0) {
                Debug.Log("Minigun out of ammo!");
                ammoRefilled = false;
                StartCoroutine(decreasingMinigunAmmo());
            }
            else
            {
                minigunBullet();
                mingunChamber = false;
                StartCoroutine(delayMinigun());
            }

        }
        //=====================================================================================================
        //Weapon Bofor Cannon
        if (Input.GetMouseButton(0) && boforChamber == true && boforWeapon.activeSelf == true && ammoRefilled == true)
        {

            if (boforAmmoCount == 0)
            {
                Debug.Log("Bofor out of ammo!");
                ammoRefilled = false;
                StartCoroutine(decreasingBoforAmmo());
            }
            else
            {
                boforBullet();
                boforChamber = false;
                StartCoroutine(delayBofor());
            }

        }
        //=====================================================================================================
        //Weapon Howitzer
        if (Input.GetMouseButtonDown(0) && howitzerChamber == true  && howitzerWeapon.activeSelf == true)
        {

            howitzerBullet();
            mAudioSrc.PlayOneShot(oneFivemm);
            howitzerChamber = false;
            StartCoroutine(delayHowitzer());
            //StartCoroutine(weaponSwitch());
        }
        //=====================================================================================================
    }

    //===========================
    //Weapon time delay before next shot

    IEnumerator delayMinigun()
    {
        yield return new WaitForSeconds(0.05f);
        Debug.Log("Minigun chambered");
        mingunChamber = true;
        
    }


    IEnumerator delayBofor()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Bofor chambered");
        boforChamber = true;
    }

    IEnumerator delayHowitzer()
    {
        yield return new WaitForSeconds(5.0f);
        Debug.Log("Howitzer chambered");
        howitzerChamber = true;
    }

    //===========================

    //Weapon Ammo decrementing and reloading

    IEnumerator decreasingMinigunAmmo()
    {
        Debug.Log("Minigun Reloading...");
        yield return new WaitForSeconds(8);
        Debug.Log("Minigun reloaded");
        minigunAmmoCount = 130;
        ammoRefilled = true;
    }

    IEnumerator decreasingBoforAmmo()
    {
        Debug.Log("Bofor Reloading...");
        yield return new WaitForSeconds(4);
        Debug.Log("Bofor reloaded");
        boforAmmoCount = 8;
        ammoRefilled = true;
    }


    //===========================

    //Weapon bullet spawning for each shot

    void minigunBullet()
    {
        Instantiate(minigunBullets, frontCannon.position, transform.rotation);
        --minigunAmmoCount;
    }

    void boforBullet()
    {
        Instantiate(boforBullets, frontCannon.position, transform.rotation);
        --boforAmmoCount;
    }

    void howitzerBullet()
    {
        Instantiate(howitzerBullets, frontCannon.position, transform.rotation);
    }

    //===========================
}

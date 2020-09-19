using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameMaster : MonoBehaviour
{
  
    //Game HUDS Screen as Gameobjects
    public GameObject minigunHUD; //Minigun HUD
    public GameObject boforHUD; //Bofor HUD
    public GameObject howitzerHUD; //Howitzer HUD
    public GameObject sentraHUD; // E-3 Sentra HUD

    private bool switchedWeapon = true;

    //Camera Setups
    public GameObject gunCam;
    public GameObject survCam;

    //Audio Sources
    public GameObject backgroundAmbient; //C-130 Ambient sound
    public AudioClip switchtoSentra; //Switching to E-3 Sentra
    public AudioClip switchtoWeapon; //Switching between weapon camera

    AudioSource audioS; //Audio source

    public Camera cam;

    //Function definition below

    void Start()
    {
        gunCam.SetActive(false);
        e3Sentra(); //Player starts game on E-3 Sentra CCTV Monitor
        audioS = GetComponent<AudioSource>();
    }

    void Update()
    {

        //========================================================================
        //gunshipCam.enabled = true;
        //Input for Minigun HUD/Weapon
        if (Input.GetKeyDown(KeyCode.Alpha1) && switchedWeapon == true && minigunHUD.activeSelf == false|| Input.GetKeyDown(KeyCode.Keypad1) && switchedWeapon == true && minigunHUD.activeSelf == false)
        {
            survCam.SetActive(false);
            gunCam.SetActive(true);
            switchedWeapon = false;
            audioS.PlayOneShot(switchtoWeapon);
            minigunWeapon();
            StartCoroutine(switchingWeapon());
        }
        //Input for Bofor HUD/Weapon
        if (Input.GetKeyDown(KeyCode.Alpha2) && switchedWeapon == true && boforHUD.activeSelf == false || Input.GetKeyDown(KeyCode.Keypad2) && switchedWeapon == true && boforHUD.activeSelf == false)
        {
            survCam.SetActive(false);
            gunCam.SetActive(true);
            switchedWeapon = false;
            audioS.PlayOneShot(switchtoWeapon);
            boforWeapon();
            StartCoroutine(switchingWeapon());
        }
        //Input for Howitzer HUD/Weapon
        if (Input.GetKeyDown(KeyCode.Alpha3) && switchedWeapon == true && howitzerHUD.activeSelf == false || Input.GetKeyDown(KeyCode.Keypad3) && switchedWeapon == true && howitzerHUD.activeSelf == false)
        { 
            survCam.SetActive(false);
            gunCam.SetActive(true);
            switchedWeapon = false;
            audioS.PlayOneShot(switchtoWeapon);
            howitzerWeapon();
            StartCoroutine(switchingWeapon());
        }

        //Input for E-3 Sentra CCTV Monitor/Marker
        if (Input.GetKeyDown(KeyCode.Alpha5) && switchedWeapon == true && sentraHUD.activeSelf == false || Input.GetKeyDown(KeyCode.Keypad5) && switchedWeapon == true && sentraHUD.activeSelf == false)
        {
            gunCam.SetActive(false);
            survCam.SetActive(true);
            switchedWeapon = false;
            audioS.PlayOneShot(switchtoSentra);
            e3Sentra();
            StartCoroutine(switchingWeapon());
        }
        //========================================================================

    }

    //Delay to prevent switch spamming
    IEnumerator switchingWeapon()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Camera aligned!");
        switchedWeapon = true;
    }

    //==================================================

    //Minigun HUD scene definition
    void minigunWeapon()
    {

        Debug.Log("Minigun Selected");
        
        audioS.PlayOneShot(switchtoWeapon);
        cam.fieldOfView = 10;
        boforHUD.SetActive(false);
        howitzerHUD.SetActive(false);
        sentraHUD.SetActive(false);
        minigunHUD.SetActive(true);

    }

    //Bofor HUD scene definition
    void boforWeapon()
    {
        Debug.Log("Bofor Selected");

        audioS.PlayOneShot(switchtoWeapon);
        cam.fieldOfView = 30;
        minigunHUD.SetActive(false);
        howitzerHUD.SetActive(false);
        sentraHUD.SetActive(false);
        boforHUD.SetActive(true);
       
    }

    //Howitzer HUD scene definition
    void howitzerWeapon()
    {
        Debug.Log("Howitzer Selected");
        cam.fieldOfView = 55;
        audioS.PlayOneShot(switchtoWeapon);
        minigunHUD.SetActive(false);
        boforHUD.SetActive(false);
        sentraHUD.SetActive(false);
        howitzerHUD.SetActive(true);

    }

    //E-3 Sentra HUD scene definition
    void e3Sentra()
    {
        Debug.Log("E-3 Cam Enabled");
        cam.fieldOfView = 70;
        minigunHUD.SetActive(false);
        boforHUD.SetActive(false);
        howitzerHUD.SetActive(false);
        sentraHUD.SetActive(true);

    }

}

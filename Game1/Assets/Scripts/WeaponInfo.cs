using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class WeaponInfo : MonoBehaviour
{
    public GameObject Weapon;
    public GameObject Player;
    public GameObject Bullet;
    public GameObject weaponImage;
    public Sprite currentWeapon;
    public TextMeshProUGUI total_text;
    public TextMeshProUGUI weapon_name;
    [HideInInspector]

    // Start is called before the first frame update
    void Start()
    {
        Weapon = Player.GetComponent<playerController>().currentWeapon;
        Bullet = Weapon.GetComponent<Weapon>().bullet;
        currentWeapon = Weapon.GetComponent<SpriteRenderer>().sprite;
        weaponImage.GetComponent<Image>().sprite = currentWeapon;
    }

    void Update ()
    {
        if (Weapon == null)
        {
            Weapon = Player.transform.GetChild(0).gameObject;
        }
        else 
        {
            updateWeaponInfo();
        }
    }

    public void updateWeaponInfo()
    {
        if (Weapon.GetComponent<Weapon>().getWeaponName() == "rocket launcher")
        {
            rocketLauncherOutput();
        } else if (Weapon.GetComponent<Weapon>().getWeaponName() == "flamethrower") {
            flamethrowerOutput();
        } else {
            defaultOutput();
        }
    }

    private void defaultOutput ()
    {
        currentWeapon = Weapon.GetComponent<SpriteRenderer>().sprite; 
        weaponImage.GetComponent<Image>().sprite = currentWeapon;
        weapon_name.text = Weapon.GetComponent<Weapon>().getWeaponName();
        total_text.text = "Ammo Left: " + Weapon.GetComponent<Weapon>().totalAmmo.ToString() + "\n" +
                          "Left In Mag: " + Weapon.GetComponent<Weapon>().roundsInMag.ToString() + "\n" +
                          "Reload: " + Weapon.GetComponent<Weapon>().reloadTime.ToString() + "\n" +
                          "Fire Rate: " + Weapon.GetComponent<Weapon>().shotsPerSecond.ToString() + "\n" + 
                          "Damage: " + Bullet.GetComponent<Bullet>().damage.ToString();
    }

    private void flamethrowerOutput ()
    {
        currentWeapon = Weapon.GetComponent<SpriteRenderer>().sprite; 
        weaponImage.GetComponent<Image>().sprite = currentWeapon;
        weapon_name.text = Weapon.GetComponent<Weapon>().getWeaponName();
        total_text.text = "Ammo Left: " + Weapon.GetComponent<Weapon>().totalAmmo.ToString() + "\n" +
                          "Left In Mag: " + Weapon.GetComponent<Weapon>().roundsInMag.ToString() + "\n" +
                          "Reload: " + Weapon.GetComponent<Weapon>().reloadTime.ToString() + "\n" +
                          "Fire Rate: " + Weapon.GetComponent<Weapon>().shotsPerSecond.ToString() + "\n" + 
                          "D.P.S. : " + Weapon.GetComponent<Flamethrower>().damage.ToString();
    } 

    private void rocketLauncherOutput()
    {
        currentWeapon = Weapon.GetComponent<SpriteRenderer>().sprite; 
        weaponImage.GetComponent<Image>().sprite = currentWeapon;
        weapon_name.text = Weapon.GetComponent<Weapon>().getWeaponName();
        total_text.text = "Ammo Left: " + Weapon.GetComponent<Weapon>().totalAmmo.ToString() + "\n" +
                          "Left In Mag: " + Weapon.GetComponent<Weapon>().roundsInMag.ToString() + "\n" +
                          "Reload: " + Weapon.GetComponent<Weapon>().reloadTime.ToString() + "\n" +
                          "Fire Rate: " + Weapon.GetComponent<Weapon>().shotsPerSecond.ToString() + "\n" + 
                          "Damage: " + Weapon.GetComponent<RocketLauncher>().damage.ToString();
    }
}

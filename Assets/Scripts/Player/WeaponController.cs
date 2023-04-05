using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponController : MonoBehaviour
{
    private Vector3 mousePos;
    public GameObject projectile;
    public bool canShoot;
    private float timer, cooldown;
    //public Slider ammoSlider;
    public Transform projectileOrigin, projectileParent;
    public int ammo;
    //public TextMeshProUGUI ammoTxt;

    // contains code from https://www.youtube.com/watch?v=-bkmPm_Besk

    void Start()
    {
       // ammoSlider.value = ammo;
       // ammoTxt.text = ammo.ToString() + "/20";
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!canShoot)
        {
            timer += Time.deltaTime;

            if (timer > cooldown)
            {
                canShoot = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            canShoot = false;

            /*if (ammo > 0)
            {
                ammo--;
                //ammoSlider.value = ammo;
                //ammoTxt.text = ammo.ToString() + "/20";
                GameObject newProjectile = Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
                newProjectile.transform.parent = projectileParent;
            }*/
        }
    }
}

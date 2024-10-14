using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Gun : MonoBehaviour
{
    [SerializeField] private GunUI gunUI;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject flameLight;
    [SerializeField] private GameObject muzzel;
    [SerializeField] private GunSO gunSO;

    [SerializeField] private GameObject mainCam;


    public string gunName { get; private set; }               //총 이름
    public int ammo { get; private set; }                   //현재 총알 - - -
    public int ammoCapacity { get; private set; }              //총알 용량(/탄창)    o
    public int maxAmmo { get; private set; }                   //최대 총알     o
    public float reloadTime { get; private set; }           //재장전 시간    o
    public float fireRate { get; private set; }             //연사 속도     o
    public bool auto { get; private set; }                  //사격 모드     o
    public bool noAmmo { get; private set; }                  //사격 모드     o

    public float spreadAngle { get; private set; }            //탄 퍼짐 각도

    private GunSO.GunType _gunType = new GunSO.GunType();
    private void Start()
    {
        StartSetting();
        SettingGun();
        print(gunName);
    }
    private void StartSetting()
    {
        gunSO.r_nowAmmo = 30;
        gunSO.s_nowAmmo = 5;
        gunSO.p_nowAmmo = 17;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _gunType = GunSO.GunType.Rifle;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _gunType = GunSO.GunType.Shotgun;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _gunType = GunSO.GunType.Pistol;
        }
        SettingGun();
        gunUI.SetUIText(gunName, ammo, ammoCapacity);
    }
    private void SettingGun()
    {
        switch (_gunType)
        {
            case GunSO.GunType.Rifle:
                gunName = "M4A1";
                print(ammo = gunSO.r_nowAmmo);
                ammoCapacity = gunSO.r_maxAmmo;
                maxAmmo = gunSO.r_ammoCapacity;
                reloadTime = gunSO.r_reloadTime;
                fireRate = gunSO.r_fireRate;
                auto = gunSO.r_auto;
                spreadAngle = gunSO.r_spreadAngle;
                break;
            case GunSO.GunType.Shotgun:
                gunName = "M1014";
                print(ammo = gunSO.s_nowAmmo);
                ammoCapacity = gunSO.s_maxAmmo;
                maxAmmo = gunSO.s_ammoCapacity;
                reloadTime = gunSO.s_reloadTime;
                fireRate = gunSO.s_fireRate;
                auto = gunSO.s_auto;
                spreadAngle = gunSO.s_spreadAngle;
                break;
            case GunSO.GunType.Pistol:
                gunName = "G17";
                ammo = gunSO.p_nowAmmo;
                ammoCapacity = gunSO.p_maxAmmo;
                maxAmmo = gunSO.p_ammoCapacity;
                reloadTime = gunSO.p_reloadTime;
                fireRate = gunSO.p_fireRate;
                auto = gunSO.p_auto;
                spreadAngle = gunSO.p_spreadAngle;
                break;
        }
        noAmmo = ammoCheck(ammo);
    }
    private void LoadGun()
    {
        //총 sprite 설정하기
    }
    public void CheckAmmo()
    {
        if (!noAmmo)
        {
            SetAmmo();
        }
        else
        {
            print("you need to reload your gun.");
        }
    }
    private void SetAmmo()
    {
        Fire();
    }
    private void Fire()
    {
        StartCoroutine(FlameLight());
        StartCoroutine(ShakeCam());
        spawnBullet();
        gunUI.SetUIText(gunName, ammo, ammoCapacity);
        ammoMinus(_gunType);
        print(ammo);
    }
    private void ammoMinus(GunSO.GunType gunType)
    {
        ammo--;
        switch (gunType)
        {
            case GunSO.GunType.Rifle:
                gunSO.r_nowAmmo = ammo;
                break;
            case GunSO.GunType.Shotgun:
                gunSO.s_nowAmmo = ammo;
                break;
            case GunSO.GunType.Pistol:
                gunSO.p_nowAmmo = ammo;
                break;
        }
        noAmmo = ammoCheck(ammo);
    }
    private bool ammoCheck(int ammo)
    {
        if (ammo <= 0)
        {
            return true;
        }
        else
            return false;
    }
    private void spawnBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, muzzel.transform.position, transform.rotation, null);
    }
    private IEnumerator ShakeCam()
    {
        Vector3 camVector = mainCam.transform.position;
        mainCam.transform.position += new Vector3(Random.Range(0, 10), Random.Range(0, 10), -10);
        yield return new WaitForSeconds(0.1f);
        mainCam.transform.position += new Vector3(Random.Range(0, 10), Random.Range(0, 10), -10);
        yield return new WaitForSeconds(0.1f);
        mainCam.transform.position += new Vector3(Random.Range(0, 10), Random.Range(0, 10), -10);
        yield return new WaitForSeconds(0.1f);
        mainCam.transform.position = camVector;
    }
    private IEnumerator FlameLight()
    {
        if (!(Random.Range(1, 8) == 3))
        {
            flameLight.SetActive(true);
            yield return new WaitForSeconds(0.05f);
            flameLight.SetActive(false);
        }
    }
}

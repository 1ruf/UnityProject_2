using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New weaponDataSO", menuName = "SO/WeaponDataSO")]
public class GunSO : ScriptableObject
{
    public enum GunType
    {
        Rifle,
        Shotgun,
        Pistol
    }

    [Header("Rifle")] //M4A1
    [field: SerializeField]
    public int r_maxAmmo = 30; //탄창 당 장탄수
    public int r_nowAmmo = 30; //탄창 당 장탄수
    public int r_ammoCapacity = 30 * 5; //최대 총알수
    public float r_reloadTime = 2.5f; //재장전 시간
    public float r_fireRate = 0.05f; //사격 지연도
    public float r_spreadAngle = 1f;
    public bool r_auto = true;

    [Header("Shotgun")] //M1014
    [field: SerializeField]
    public int s_maxAmmo = 5;
    public int s_nowAmmo = 5;
    public int s_ammoCapacity = 5 * 5;
    public float s_reloadTime = 4f;
    public float s_fireRate = 0.5f;
    public float s_spreadAngle = 15f;
    public bool s_auto = false;

    [Header("Pistol")] //glock 17
    [field: SerializeField]
    public int p_maxAmmo = 17;
    public int p_nowAmmo = 17;
    public int p_ammoCapacity = 17 * 5;
    public float p_reloadTime = 2f;
    public float p_fireRate = 0.15f;
    public float p_spreadAngle = 2f;
    public bool p_auto = false;
}

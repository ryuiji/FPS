﻿using UnityEngine;
using System.Collections;

public enum CurrentFireMode
{
    Melee,
    Automatic,
    PumpAction,
    SemiAutomatic,
}
public abstract class GunAbstract : MonoBehaviour
{
    public string gunName;
    public float roundsPerMinute;
    public float reloadSpeed;
    public float clipSize;
    public float bulletsInClip;
    public float looseAmmo;
    public GameObject bullet;
    public Transform firePoint;
    public CurrentFireMode fireMode;
    public bool mayFire = true;
    public float fireRate;
    public Gunmanage gunManager;

    [Header("Sound Files")]
    public AudioSource audioSource;
    public AudioClip fire;
    public AudioClip reload;
    public AudioClip empty;


    public abstract void Shoot();

    public abstract IEnumerator Reload();

    public abstract void Aim();

    public abstract void PassDelegates();

    public abstract IEnumerator RateOfFire();

    public abstract void PullTrigger();



}

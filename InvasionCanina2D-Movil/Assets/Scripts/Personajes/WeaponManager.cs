using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    public Weapon currentWeapon;

    public Transform weaponHolder;

    private bool atake = false;
    private bool tirar = false;
    public bool HasRoomForWeapon => this.currentWeapon == null;

    private EntradaMovimiento entradaMovimiento;

    // UI
    private AmmoUI ammoUI;

    private void Awake()
    {
        entradaMovimiento = new EntradaMovimiento();
    }

    private void OnEnable()
    {
        entradaMovimiento.Enable();
    }

    private void OnDisable()
    {
        entradaMovimiento.Disable();
    }
    void Start()
    {
        this.ammoUI = FindObjectOfType<AmmoUI>();
        this.ammoUI.Display(false);

        Weapon[] weapons = this.GetComponentsInChildren<Weapon>();
        foreach (var w in weapons)
        {
            // ARREGLAME PLS
            this.PickUpWeapon(w,9999);
        }
        entradaMovimiento.Movimiento.Ataque.performed += contexto => Ataque(contexto);
        entradaMovimiento.Movimiento.Tirar.performed += contexto => Tirar(contexto);
    }


    private void Update()
    {

        if (atake)
        {
            if (this.currentWeapon != null)
            {
                this.currentWeapon.Active();
            }
            atake = false;
        }

        if (tirar)
        {
            if (this.currentWeapon != null)
            {
                this.currentWeapon.Throw();
                this.currentWeapon = null;
                this.ammoUI.Display(false);
            }
            tirar = false;
        }
    }

    private void Ataque(InputAction.CallbackContext contexto)
    {
        atake = true;
    }

    private void Tirar(InputAction.CallbackContext contexto)
    {
        tirar = true;
    }

    public void PickUpWeapon(Weapon weapon, int startingAmmo)
    {
        weapon.transform.position = this.weaponHolder.position;
        weapon.transform.rotation = this.weaponHolder.rotation;
        weapon.transform.SetParent(this.weaponHolder);

        this.currentWeapon = weapon;

        if (this.currentWeapon is GunWeapon)
        {
            GunWeapon gun = this.currentWeapon as GunWeapon;

            gun.ui = this.ammoUI;

            gun.currentAmmo = startingAmmo;

            this.ammoUI.Display(true);
        }
        else
        {
            this.ammoUI.Display(false);
        }
    }

    public bool TryToRecharge(GunType type, int amount)
    {
        if (this.currentWeapon is GunWeapon == false)
            return false;

        GunWeapon gun = this.currentWeapon as GunWeapon;
        if (gun.type != type)
            return false;

        if (gun.isAmmoAtMax)
            return false;

        gun.currentAmmo += amount;

        return true;
    }
}

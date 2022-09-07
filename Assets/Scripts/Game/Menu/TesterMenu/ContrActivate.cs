using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContrActivate : MonoBehaviour
{
    private bool menu_is_active = false;
    [SerializeField] private GameObject menu;
    public void ShowHideMenu()
    {
        menu_is_active = !menu_is_active;
        menu.SetActive(menu_is_active);
    }
}

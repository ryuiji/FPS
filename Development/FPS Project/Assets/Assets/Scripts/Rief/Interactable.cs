﻿using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour {

    public enum Interact {Door, FalseBottle, TrueBottle, DeskConversation, PistolAmmo, AKAmmo, ShotgunAmmo, Batteries
                          }
    public Interact interact;

}

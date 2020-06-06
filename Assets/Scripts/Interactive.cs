using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    public enum InteractiveType
    {
        Object,
        Container,
        NPC,
        Special
    }

    [TextArea(5, 10)]
    public string description = "Item needs description.";

    public InteractiveType thisInteractiveType;

    //private GameObject player;

    //private void Awake()
    //{
    //    player = GameObject.FindGameObjectWithTag("Player");
    //}
}
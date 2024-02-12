using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    [SerializeField] protected GameObject player;

    protected ColorHandler colorHandler;

    private int currentCycle = 0;
    //
    private void Start()
    {
        colorHandler = player.GetComponent<ColorHandler>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            currentCycle++;
        else if (Input.GetKeyDown(KeyCode.Mouse1))
            currentCycle--;

        if (currentCycle >= Enum.GetNames(typeof(ValidColor)).Length)
            currentCycle = 0;

        if (currentCycle < 0)
            currentCycle = Enum.GetNames(typeof(ValidColor)).Length-1;

        colorHandler.CurrentColor = (ValidColor)currentCycle;
    }
}

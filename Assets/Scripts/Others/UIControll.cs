﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControll : MonoBehaviour
{
    enum Objective{
        Door1
    }

    [Header("Door1 Script")]
    public DoorOne doorScript;
    
    void Start()
    {
        GameObject.Find("Door1Canvas").SetActive(false);
    }

    
    void Update()
    {
        
    }

    public void ActivateObjective(int objID){
        if(objID == 1){
            doorScript.ShowUI();
        }
    }
}
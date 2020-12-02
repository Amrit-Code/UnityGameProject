﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlassPennel : MonoBehaviour
{
    [Header("Glass Pannel UI")]
    public GameObject taskCanvas;
    [Header("Glass Pannels")]
    public GameObject glassPennel1;
    public GameObject glassPennel2;
    public GameObject gpannel;
    
    private GameObject player;
    private Interaction interact;
    private bool isNear = false;
    private List<GameObject> buttons;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        interact = player.GetComponent<Interaction>();

        buttons = new List<GameObject>();
        for(int i = 0; i < 9; i ++){
            buttons.Add(GameObject.Find("GButton"+i.ToString()));
        }

        System.Random rnd = new System.Random();
        foreach(GameObject button in buttons){
            int v = rnd.Next(100);
            if((v % 2) == 0){
                button.GetComponent<Image>().color = Color.blue;
            }else{
                button.GetComponent<Image>().color = Color.red;
            }
        }

    }

    
    void Update()
    {
        if(isNear){
            CheckLeft();
        }else{
            CheckIfNear();
        }
        
    }

    private void CheckIfNear(){
        
        float distance = (transform.position - player.transform.position).magnitude;
        if(distance < 3f){
            isNear = true;
            interact.NearObjective(3);
        }
        
    }

    private void CheckLeft(){
        float distance = (transform.position - player.transform.position).magnitude;
        if(distance > 3f){
            isNear = false;
            interact.ObjectiveLeft();
        }
    }

    public void ShowUI(){
        taskCanvas.SetActive(true);
        player.GetComponent<Movement>().enabled = false;
    }

    public void ButtonPressed(int id){
        if(id == 0){
            FlipColour(0); FlipColour(1); FlipColour(3);

        }else if(id == 1){
            FlipColour(0); FlipColour(1); FlipColour(2); FlipColour(4);

        }else if(id == 2){
            FlipColour(1); FlipColour(2); FlipColour(5);

        }else if(id == 3){
            FlipColour(0); FlipColour(3); FlipColour(4); FlipColour(6);

        }else if (id == 4){
            FlipColour(1); FlipColour(3); FlipColour(4); FlipColour(5); FlipColour(7);

        }else if(id == 5){
            FlipColour(2); FlipColour(4); FlipColour(5); FlipColour(8);

        }else if(id == 6){
            FlipColour(3); FlipColour(6); FlipColour(7);

        }else if(id == 7){
            FlipColour(4); FlipColour(6); FlipColour(7); FlipColour(8);

        }else if(id == 8){
            FlipColour(5); FlipColour(7); FlipColour(8);
        }

        CheckIfWon();
    }

    private void FlipColour(int id){
        if(buttons[id].GetComponent<Image>().color == Color.red){
            buttons[id].GetComponent<Image>().color = Color.blue;
        }else{
            buttons[id].GetComponent<Image>().color = Color.red;
        }
    }

    private void CheckIfWon(){
        bool won = true;
        foreach (GameObject button in buttons){
            if(button.GetComponent<Image>().color == Color.red){
                won = false;
                break;
            }
        }

        if(won){
            glassPennel1.SetActive(false);
            glassPennel2.SetActive(false);
            ExitScreen();
            interact.ObjectiveLeft();
            gpannel.SetActive(false);
        }
    }

    public void ExitScreen(){
        taskCanvas.SetActive(false);
        player.GetComponent<Movement>().enabled = true;
    }
}
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class waypoint : MonoBehaviour
{
    public Image img;
    public Transform target;
    public Text meter;
    public Text status;
    public int wdistance;

    private void Update(){

      
            
        float minX = img.GetPixelAdjustedRect().width/2;
        float maxX = Screen.width - minX;

        float minY = img.GetPixelAdjustedRect().height/2;
        float maxY = Screen.height - minY;

        Vector2 pos = Camera.main.WorldToScreenPoint(target.position);
        if (Vector3.Dot((target.position-transform.position),transform.forward) <0 )
        {
            if (pos.x < Screen.width / 2)
            {
                pos.x = maxX;
            }
            else{
                pos.x = minX;
            }
        }
        pos.x = Mathf.Clamp(pos.x,minX,maxX);
        pos.y = Mathf.Clamp(pos.y,minY,maxY);
        img.transform.position = pos;
        wdistance = ((int)Vector3.Distance(target.position,transform.position));
        meter.text = wdistance.ToString()+ "m";
        
        

        
        if (wdistance<=3)
        {
       
         status.text = ""+ToString()+"";
        
       
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   
}

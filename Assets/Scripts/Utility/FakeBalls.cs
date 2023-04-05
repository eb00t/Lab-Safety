using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBalls : MonoBehaviour
{
   public GameObject yellow, red;

   private void Start()
   {
   }

   void Update()
   {
      if (Input.GetKey(KeyCode.Mouse0))
      {
         yellow.SetActive(true);
      }
      
      if (Input.GetKey(KeyCode.Mouse1))
      {
         red.SetActive(true);
      }
   }}

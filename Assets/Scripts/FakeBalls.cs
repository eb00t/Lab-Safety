using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBalls : MonoBehaviour
{
   public GameObject balls;

   private void Start()
   {
   }

   void Update()
   {
      if (Input.GetKey(KeyCode.Mouse0))
      {
         balls.SetActive(true);
      }
   }}

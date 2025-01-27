﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml.Serialization;
using UnityEngine;

//class with functions for later use
public static class StaticClass 
{

    public static GameObject SpawnGameObject(GameObject objectToSpawn)
    {
        return GameObject.Instantiate(objectToSpawn);
    }

   public static bool IsNear(GameObject gameObjectA,GameObject gameObjectB,float nearDistanceX,float nearDistanceY)
    {
        bool isNear;
        //if distance between gameobjects is less than distance that is considered near
        //then the object is considered near
        if (gameObjectA.transform.position.x-nearDistanceX<gameObjectB.transform.position.x&&gameObjectA.transform.position.x+nearDistanceX>gameObjectB.transform.position.x)
        {
            isNear = true;
        }

        else
        {
            isNear = false;
        }

        return isNear;
    }

    public static bool IsInRange(Transform thisPositon,GameObject objectToCheck,float range)
    {
        bool isInRange;
        //if distance between gameobject and position is less than range
        //then the object is considered in range
        if ((thisPositon.position.x-range<objectToCheck.transform.position.x&&thisPositon.position.x+range>objectToCheck.transform.position.x)&& (thisPositon.position.y - range < objectToCheck.transform.position.y && thisPositon.position.y + range > objectToCheck.transform.position.y))
        {
            isInRange = true;
        }

        else
        {
            isInRange = false;
        }

        return isInRange;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsSwitch : MonoBehaviour
{
    public GameObject object01;
    public GameObject object02;
    public bool shotgun = false;



    void Start()
    {
        object01.SetActive(true);
        object02.SetActive(true);
        object02.layer = 7;
        SetLayerAllChildren(object02.transform, 7);
    }




    void Update()
    {
        if (Input.GetButtonDown("1") && object02.GetComponent<GunSystem>().canSwitch)
        {
            object01.layer = 6; //SetActive(true);
            object02.layer = 7; //.SetActive(false);
            SetLayerAllChildren(object01.transform, 6);
            SetLayerAllChildren(object02.transform, 7);
        }

        if (Input.GetButtonDown("2") && shotgun && object01.GetComponent<GunSystem>().canSwitch)
        {
            object01.layer = 7; //(false);
            object02.layer = 6; //SetActive(true);
            SetLayerAllChildren(object01.transform, 7);
            SetLayerAllChildren(object02.transform, 6);
        }
    }


    void SetLayerAllChildren(Transform root, int layer)
    {
        var children = root.GetComponentsInChildren<Transform>(includeInactive: true);
        foreach (var child in children)
        {
//            Debug.Log(child.name);
            child.gameObject.layer = layer;
        }
    }

}

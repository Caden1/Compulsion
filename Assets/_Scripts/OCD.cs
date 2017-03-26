using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OCD : MonoBehaviour{

    public int Power { get; private set; }
    public int Influence { get; set; }
    public GameObject Owner { get; private set; }

    public OCD()
    {
        Power = 1;
        Influence = 0;
        Owner = gameObject;
    }

    public OCD(int power)
    {
        Power = power;
        Influence = 0;
        Owner = gameObject;
    }
}

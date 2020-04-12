using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : MonoBehaviour
{
    public int unitSpeed;
    public int unitMaxEnergy;
    public int unitCurrentEnergy;
    public int unitAttack;
    public int unitDefense;


    // Start is called before the first frame update
    void Start()
    {
        unitCurrentEnergy = unitMaxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

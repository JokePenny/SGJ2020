using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CabbageData", menuName = "SGJ/CabbageData", order = 0)]
public class CabbageData : ObjectData
{
   [SerializeField] private Material materialObject;
    public Material MaterialObject
    {
        get{return materialObject;}
        protected set {materialObject = value;}
    } 

    [SerializeField] private Sprite spriteObject;
    public Sprite SpriteObject
    {
        get{return spriteObject;}
        protected set {spriteObject = value;}
    } 

    [SerializeField] private float speedEating;
    public float SpeedEating
    {
        get{return speedEating;}
        protected set {speedEating = value;}
    } 

    [SerializeField] private int health;
    public int Health
    {
        get{return health;}
        protected set {}
    } 
}

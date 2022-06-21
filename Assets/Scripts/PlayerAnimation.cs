using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Tooltip("Variable for the player animator")]
    public Animator anim;

    [HideInInspector]
    public int damageIndex;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        damageIndex = Animator.StringToHash("Damage");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

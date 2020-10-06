using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnToggle : MonoBehaviour
{
    [SerializeField] GameObject Object;
    private bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
    }

    public void toggle()
    {
        isActive = !isActive;
        Object.SetActive(isActive);
    }
}

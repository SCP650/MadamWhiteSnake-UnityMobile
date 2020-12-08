using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAddScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("KillMySelf", 1);
    }

    void KillMySelf()
    {
        Destroy(this.gameObject);
    }
}

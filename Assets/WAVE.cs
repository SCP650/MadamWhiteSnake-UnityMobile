using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WAVE : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
        // _animator.enabled = false;
       
       
    }

    // Update is called once per frame
    public void Xuli()
    {
        Debug.Log("start send waves");
        _animator.SetBool("xu",  !_animator.GetBool("xu"));
        // _animator.enabled = true;
        Debug.Log( "xuli ia " + _animator.GetBool("xu"));
        

        
        Qibo();

    }

    public void Qibo()
    {
        Debug.Log("start send waves");
        _animator.SetBool("qi", true);

    }

    public void EndSendWaves()
    {
        // _animator.SetBool("xuli", false);
        // _animator.SetBool("QIBO", false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursurVisibility : MonoBehaviour
{
    public bool cursurVisible;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = cursurVisible;
    }
}

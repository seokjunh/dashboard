using System.Collections;
using System.Collections.Generic;
using Firebase.Database;
using UnityEngine;

public class FirebaseDBManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    
}

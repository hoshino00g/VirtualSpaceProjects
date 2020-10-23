using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryUIController : MonoBehaviour
{
    public GameObject existRoom;
    public GameObject newRoom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnVisitExisting(){
        newRoom.SetActive(false);
        existRoom.SetActive(true);
    }

    public void OnCreateNew(){
        newRoom.SetActive(true);
        existRoom.SetActive(false);
    }
}

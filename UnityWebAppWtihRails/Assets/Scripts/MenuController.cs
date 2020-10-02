using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject FileUploadMenu;
    public GameObject UserCreateMenu;
    public GameObject MenuChangeBtnTxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMenuChange(){
        if(UserCreateMenu.activeSelf){
            FileUploadMenu.SetActive(true);
            MenuChangeBtnTxt.GetComponent<Text>().text = "作品投稿へ"
        }else{
            FileUploadMenu.SetActive(false);

        }
    }

}

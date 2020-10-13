using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            UserCreateMenu.SetActive(false);
            FileUploadMenu.SetActive(true);
            MenuChangeBtnTxt.GetComponent<Text>().text = "ユーザー作成へ";
        }else{
            UserCreateMenu.SetActive(true);
            FileUploadMenu.SetActive(false);
            MenuChangeBtnTxt.GetComponent<Text>().text = "作品投稿へ";
        }
    }

}

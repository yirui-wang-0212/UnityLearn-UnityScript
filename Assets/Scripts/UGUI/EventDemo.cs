using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventDemo : MonoBehaviour
{
    //事件注册的 4 种 方法：

    // 1. 通过编辑器方法
   public void Fun1(string input){
       
       print("Fun1: " + input);
   }

    //2. AddListener
    public void Fun2(){
    
        print("Fun2");
    }

    public void Fun3(string str){
    
        print("Fun3: " + str);
    }

    private void Start(){
        
        Button btn = this.transform.Find("AddListener/Button").GetComponent<Button>();
        // public delegate void UnityAction();
        // 需要传入一个 无返回值、无参数列表的方法
        btn.onClick.AddListener(Fun2);

        InputField input = this.transform.Find("AddListener/InputField").GetComponent<InputField>();
        // public delegatevoid UnityAction<T0>(T0 arg0);
        // 需要传入一个 无返回值，1个参数，参数类型为泛型，在这里是 string 的方法
        // input.onValueChange.AddListener(Fun3);
        input.onEndEdit.AddListener(Fun3);
    }
}

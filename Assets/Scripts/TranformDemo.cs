using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranformDemo : MonoBehaviour
{
   private void OnGUI(){
       
       if(GUILayout.Button("foreach -- transform")){
           // child 为每个子物体的变换组件（不包括自身，且只是子节点，不包含孙子等后代节点）
           foreach(Transform child in transform){
               print(child.name);
           }
       }
   }
}

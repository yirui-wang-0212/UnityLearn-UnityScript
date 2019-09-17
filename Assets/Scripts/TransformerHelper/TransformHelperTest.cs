using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformHelperTest : MonoBehaviour
{
    private void OnGUI(){
        if(GUILayout.Button("层级未知，查找子物体")){
            Transform childTF = TransformHelper.GetChild(this.transform, "TFHelper (5)");
            if(childTF != null){
                childTF.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            else print("没有这个子物体。");
        }
    }
}

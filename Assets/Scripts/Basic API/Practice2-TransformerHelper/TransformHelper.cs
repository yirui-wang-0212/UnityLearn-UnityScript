using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformHelper : MonoBehaviour
{
    // 在层级未知情况下查找子物体
    // 传入：父物体变换组件，子物体名称
    // 返回：
    public static Transform GetChild(Transform parentTF, string childName){
        // 在子物体中查找
        Transform childTF = parentTF.Find(childName);
        if(childTF != null) return childTF;

        // 将问题交由子物体
        int count = parentTF.childCount;
        // 遍历所有子物体，在子物体的子物体中查找
        for (int i = 0; i < count; i++){
            childTF = GetChild(parentTF.GetChild(i), childName);
            if(childTF != null) return childTF;
        }
        // 找不到
        return null;
    }
}

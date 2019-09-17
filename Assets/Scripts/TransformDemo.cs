using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tranform 类提供了查找（夫、根、子（索引、名称））变换组件、改变位置、角度、大小功能
public class TransformDemo : MonoBehaviour{
    public Transform tf;

    // ---------------------------------------查找变换组件-----------------------------------------
    private void OnGUI(){

        if(GUILayout.Button("foreach -- transform")){
            // child 为每个子物体的变换组件（不包括自身，且只是子节点，不包含孙子等后代节点）
            foreach(Transform child in transform){
                print(child.name);
            }
        }

        if(GUILayout.Button("root")){

            // 获取根物体变换组件（没有根的返回自己）
            Transform rootTF = this.transform.root;
        }

        if(GUILayout.Button("parent")){

            // 获取父物体变换组件
            Transform parentTF = this.transform.parent;
        }

        if(GUILayout.Button("SetParent")){

            // 设置为父物体，当前物体的位置视为世界坐标，所以在 Scene 中位置不移动
            // this.transform.SetParent(tf);
            // 设置为父物体，当前物体的位置视为 LocalPosition，在 Scene 中位置会移动
            this.transform.SetParent(tf, false);
        }

        if(GUILayout.Button("Find")){

            // 根据名称获取子物体（只能找儿子，不能找孙子）
            Transform childTF = this.transform.Find("子物体名称");
            // 确保父子关系一直不回改变时才写路径，否则不要写
            // 找孙子，写路径
            // Transform childTF = this.transform.Find("子物体名称/子物体名称");
            // 找重孙子，写路径
            // Transform childTF = this.transform.Find("子物体名称/子物体名称/子物体名称");
        }

        if(GUILayout.Button("GetChild")){

            int count = this.transform.childCount;
            // 根据索引获取子物体，孙子不行
            for (int i = 0; i < 0; i++){
                Transform childTF = this.transform.GetChild(i);
            }
        }

        // 使用 Find 和 GetChild 可以实现在层级未知情况下查找子物体：递归

        // ---------------------------------------改变位置、角度、大小------------------------------------------
        if(GUILayout.Button("pos / scale")){

            // 物体相对于世界坐标系远点的位置
            // this.transform.position
            // 物体相对于父物体轴心点的位置
            // this.transform.localPosition

            // 物体相对于父物体的缩放比例
            // this.transform.localScale
            // 理解为：物体相对于模型缩放比例（自身缩放比例 * 副物体缩放比例）
            // 如：父物体 localScale 为 3，当前物体 localScale 为 2，则 lossyScale 为 6
            // 只读
            // this.transform.lossyScale
        }
        
        if(GUILayout.Button("Translate")){

            // 向自身坐标系 z 轴 移动 1米
            // this.transform.Translate(0, 0, 1);
            // 向世界坐标系 z 轴 移动 1米
            this.transform.Translate(0, 0, 1, Space.World);
        }

        if(GUILayout.Button("Rotate")){

            // 沿自身坐标系 y 轴 旋转 10 度
            // this.transform.Rotate(0, 0, 1);
            // 沿世界坐标系 y 轴 旋转 10 度
            this.transform.Rotate(0, 10, 0, Space.World);
        }

        // RepeatButton：长按持续旋转
        if(GUILayout.RepeatButton("RotateAround")){

            // 绕原点、 y 轴 旋转 1度
            // this.transform.RotateAround(Vector3.zero, Vector3.up, 1);
            // 绕原点、 z 轴 旋转 1度
            this.transform.RotateAround(Vector3.zero, Vector3.up, 1);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour{

    // 门的状态：true 表示开门
    public bool doorState = false;
    // 动画片段名称
    public string animName = "Door";

    private Animation anim;

    private void Start(){

        anim = GetComponent<Animation>();
    }

    private void OnMouseDown(){
        
        // 如果开门状态
        if(doorState){
            
            // 如果此时动画没有正在播放
            // 即不是开门开到一半（门完全打开了）
            // 修改 time 为动画的长度，否则默认 time 为 0 
            // 从动画最后开始倒着播
            if(anim.isPlaying == false){
                // 从最后开始播
                anim[animName].time = anim[animName].length;
            }
            // 如果此时动画正在播放
            // 即开门开到一半
            // 不需要修改 time， 即从当前 time 开始倒着播

            // 关门操作，倒着播
            anim[animName].speed = -1;
        }
        // 如果关门状态
        else{
            // 开门操作
            // 正着播动画
            anim[animName].speed = 1;
        }
        // 播放动画
        anim.Play(animName);
        // 修改门的状态
        doorState = !doorState;
    }
}

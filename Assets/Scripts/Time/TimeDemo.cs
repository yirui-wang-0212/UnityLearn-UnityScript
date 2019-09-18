using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDemo : MonoBehaviour
{
    // public float t;

    public float speed = 100;

    public float seeDeltaTime;
    public float seeUnscaledDeltaTime;
    public float seeTime;
    public float seeUnscaledTime;
    public float seeRealtimeSinceStartup;

    


    // 渲染场景时执行，不受 TimeScale 影响
    // 但是如果使用 Time.deltaTime，Time.deltaTime 受 TimeScale 影响
    public void Update(){

        // t = Time.time;

        // 每渲染帧 执行 1 次，旋转 1 度
        // 1s 渲染？度数
        // 帧多 1s 旋转速度快
        // 帧少 1s 旋转速度慢
        // this.transform.Rotate(0, 1, 0);
        // 当旋转/移动速度（Time.deltaTime） * 每帧消耗时间，可以保证旋转/移动速度不受机器性能以及渲染影响
        // this.transform.Rotate(0, speed * Time.deltaTime, 0);

        // Time.deltaTime 受 TimeScale 影响
        // 以秒计算，完成最后一帧的时间（只读）
        seeDeltaTime = Time.deltaTime;
        // Time.unscaledDeltaTime 不受 TimeScale 影响
        seeUnscaledDeltaTime = Time.unscaledDeltaTime;
        
        // Time.time 受 TimeScale 影响
        // 以秒计算，游戏到现在的时间
        // 除去了编译器卡顿的时间
        seeTime = Time.time;
        // Time.unscaledTime 受 TimeScale 影响
        // 包含了编译器卡顿的时间
        seeUnscaledTime = Time.unscaledTime;
        // 实际游戏运行时间
        // 包含了编译器卡顿的时间
        seeRealtimeSinceStartup = Time.realtimeSinceStartup;


        // 游戏暂停，虽然在不受影响的 Update 里，但使用的 Time.deltaTime 受影响
        // this.transform.Rotate(0, speed * Time.deltaTime, 0);
        // 游戏暂停，个别物体不受影响，则可以在 Update 里使用 Time.unscaledDeltaTime 实现
        this.transform.Rotate(0, speed * Time.unscaledDeltaTime, 0);

    }

    // 固定 0.02s 执行一次，与渲染无关，受 TimeScale 影响
    // public void FixedUpdate(){

    //     this.transform.Rotate(0, speed, 0);
    // }

    private void OnGUI(){

        if(GUILayout.Button("暂停游戏")){

            // 时间的缩放，可以用于减慢运动效果
            // 默认为 1.0，和实时时间一样快，0 为暂停游戏（FixedUpdate 不再执行，Update 不受影响）
            // FixedUpdate 不受影响，Update 不受影响
            Time.timeScale = 0;
        }

        if(GUILayout.Button("继续游戏")){
            Time.timeScale = 1;
        }
    }
}

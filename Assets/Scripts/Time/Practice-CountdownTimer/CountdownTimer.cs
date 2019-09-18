using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 倒计时
// 从 02:00 开始，最后 10s 字体为红色，时间为 00:00 后停止计时。
public class CountdownTimer : MonoBehaviour
{
    // 需求：1s 修改 1次 Text 文本内容
    // 1. 查找组件引用
    // 2. 定义变量：秒 second
    // 3. 120 --> 02:00  119 --> 01:59
    // 4. 修改文本
    // 5. 如何每秒修改一次 重点：在 Update 每帧执行的方法中，个别语句实现指定间隔执行一次

    private Text txtTimer;
    public int second = 120;

    private void Start(){

        txtTimer = this.GetComponent<Text>();
    }

    private void Update(){

        Timer1();
    }

    // 方法一
    // 下次修改时间
    private float nextTime = 1;
    private void Timer1(){

        // 如果到了修改时间
        if(Time.time > nextTime){

            second--;
            // d2：2 位数，以 0 来填充
            txtTimer.text = string.Format("{0:d2}:{1:d2}", second / 60, second % 60);

            // 设置下次修改时间
            nextTime = Time.time + 1;
        }
    }

    private void Timer2(){

        // 如果到了修改时间
        if(Time.time > nextTime){

            second--;
            // d2：2 位数，以 0 来填充
            txtTimer.text = string.Format("{0:d2}:{1:d2}", second / 60, second % 60);

            // 设置下次修改时间
            nextTime = Time.time + 1;
        }
    }
}

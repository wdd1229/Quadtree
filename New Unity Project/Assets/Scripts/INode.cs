using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INode
{
    /// <summary>
    /// 轴对齐边框
    /// </summary>
    Bounds bound { get; set; }
    /// <summary>
    /// 初始化插入一个场景物体
    /// </summary>
    /// <param name="obj"></param>
    void InsertObj(ObjData obj);
    /// <summary>
    /// 当触发者（主角）移动时显示/隐藏物体
    /// </summary>
    /// <param name="camera"></param>
    void TriggerMove(Camera camera);

    /// <summary>
    /// 在Scene场景上画边框  
    /// </summary>
    void DrawBound();
}

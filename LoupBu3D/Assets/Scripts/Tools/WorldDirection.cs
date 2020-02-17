using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldDirection : Singleton<WorldDirection>
{
    private Vector3 up, down, forward, back, left, right;

    public Vector3 Up { get => up; private set => up = value; }
    public Vector3 Down { get => down; private set => down = value; }
    public Vector3 Forward { get => forward; private set => forward = value; }
    public Vector3 Left { get => left; private set => left = value; }
    public Vector3 Back { get => back; private set => back = value; }
    public Vector3 Right { get => right; private set => right = value; }

    private void Start()
    {
        Up = Vector3.up;
        Down = Vector3.down;
        Forward = Vector3.forward;
        Back = Vector3.back;
        Left = Vector3.left;
        Right = Vector3.right;
    }
}

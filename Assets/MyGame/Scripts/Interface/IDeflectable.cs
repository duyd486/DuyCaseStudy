using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDeflectable 
{
    public void Deflect(Vector2 direction);

    public float ReturnSpeed { get; set; }

    public bool IsDeflecting {  get; set; }
}

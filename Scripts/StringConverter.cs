using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringConverter
{
    public static string ConvertToFormat(float val)
    {
        return System.String.Format("{0:0.0}", System.Math.Round(val, 2));
    }
}

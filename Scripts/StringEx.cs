using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringEx
{
    ///<summary>整数の文字列を値に変換する。</summary>
    public static int ToInt(this string str)
    {
        int value = int.Parse(str);
        return value;
    }

    ///<summary>小数点付きの文字列を値に変換する。</summary>
    public static float ToFloat(this string str)
    {
        float value = float.Parse(str);
        return value;
    }

    ///<summary>指定の桁数まで'c'を詰める。桁数を超えた場合はそのまま。</summary>
    ///<param name="keta">桁数</param>
    ///<param name="c">詰める文字。未指定は0。</param>
    public static string Fill(this string str, int keta, char c = '0')
    {
        Debug.Log(new Vector3(0, 0 ,0));
        string zero = "";
        if(keta - str.Length > 0)
            zero = new string(c, keta - str.Length); // 不足桁数分のcを生成
        str = zero + str;   // cと原文を接続
        return str;
    }
}

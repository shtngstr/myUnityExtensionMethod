using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectEx
{
    ///<summary>ついでにDebug.Log()を行う。</summary>
    public static T Log<T>(this T tt, string prefix = "") where T : System.IEquatable<T> {
        Debug.Log(prefix + tt);
        return tt;
    }

    ///<summary>アタッチされているRigidbodyを取得を試み、返す。</summary>
    public static Rigidbody GetRigidbody(this GameObject gameobject, bool notificate = false) {
        Rigidbody rb = gameobject.GetComponent<Rigidbody>();
        if(notificate) if(rb == null) Debug.Log("Failured GetRigidbody()"); else Debug.Log("Succeed GetRigidbody()");
        return rb;
    }

    ///<summary>アタッチされているRigidbody2Dを取得を試み、返す。</summary>
    public static Rigidbody2D GetRigidbody2D(this GameObject gameobject, bool notificate = false) {
        Rigidbody2D rb2D = gameobject.GetComponent<Rigidbody2D>();
        if(notificate) if(rb2D == null) Debug.Log("Failured GetRigidbody2D()"); else Debug.Log("Succeed GetRigidbody2D()");
        return rb2D;
    }

    ///<summary>アタッチされている任意のColliderを取得を試み、返す。</summary>
    public static Collider GetCollider(this GameObject gameobject, bool notificate = false) {
        Collider c = gameobject.GetComponent<Collider>();
        if(notificate) if(c == null) Debug.Log("Failured GetCollider()"); else Debug.Log("Succeed GetColldier()");
        return c;
    }

    ///<summary>アタッチされている任意のCollider2Dを取得を試み、返す。</summary>
    public static Collider2D GetCollider2D(this GameObject gameobject, bool notificate = false) {
        Collider2D c2D = gameobject.GetComponent<Collider2D>();
        if(notificate) if(c2D == null) Debug.Log("Failured GetCollider2D()"); else Debug.Log("Succeed GetCollider2D()");
        return c2D;
    }
}

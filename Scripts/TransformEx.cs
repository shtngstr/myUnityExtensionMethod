using UnityEngine;

public static class TransformEx
{
    ///<summary>x座標のみ加算。</summary>
    public static Transform AddPosX(this Transform transform, float x)
    {
        Vector3 pos = transform.position;
        pos.x += x;
        transform.position = pos;
        return transform;
    }
    ///<summary>y座標のみ加算。</summary>
    public static Transform AddPosY(this Transform transform, float y)
    {
        Vector3 pos = transform.position;
        pos.y += y;
        transform.position = pos;
        return transform;
    }
    ///<summary>z座標のみ加算。</summary>
    public static Transform AddPosZ(this Transform transform, float z)
    {
        Vector3 pos = transform.position;
        pos.z += z;
        transform.position = pos;
        return transform;
    }
    ///<summary>x, z座標のみ加算。</summary>
    public static Transform AddPosXZ(this Transform transform, Vector2 v)
    {
        Vector3 pos = transform.position;
        pos += new Vector3(v.x, 0, v.y);
        transform.position = pos;
        return transform;
    }

    ///<summary>x座標のみ代入。/summary>
    public static Transform SetPosX(this Transform transform, float x)
    {
        Vector3 pos = transform.position;
        pos.x = x;
        transform.position = pos;
        return transform;
    }
    ///<summary>座標のみ代入。</summary>
    public static Transform SetPosY(this Transform transform, float y)
    {
        Vector3 pos = transform.position;
        pos.y = y;
        transform.position = pos;
        return transform;
    }
    ///<summary>z座標のみ代入</summary>
    public static Transform SetPosZ(this Transform transform, float z)
    {
        Vector3 pos = transform.position;
        pos.z = z;
        transform.position = pos;
        return transform;
    }
    ///<summary>x, z座標のみ代入</summary>
    public static Transform SetPosXZ(this Transform transform, Vector2 v)
    {
        Vector3 pos = new Vector3(v.x, transform.position.y, v.y);
        transform.position = pos;
        return transform;
    }

    ///<summary>x回転のみ代入</summary>
    public static Transform SetRotationX(this Transform transform, float x)
    {
        Quaternion rot = Quaternion.Euler(x, transform.rotation.y, transform.rotation.z);
        transform.rotation = rot;
        return transform;
    }
    ///<summary>y回転のみ代入</summary>
    public static Transform SetRotationY(this Transform transform, float y)
    {
        Quaternion rot = Quaternion.Euler(transform.rotation.x, y, transform.rotation.z);
        transform.rotation = rot;
        return transform;
    }
    ///<summary>z回転のみ代入</summary>
    public static Transform SetRotationZ(this Transform transform, float z)
    {
        Quaternion rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, z);
        transform.rotation = rot;
        return transform;
    }

    ///<summary>xスケールのみ代入</summary>
    public static Transform SetScaleX(this Transform transform, float x)
    {
        Vector3 scale = transform.localScale;
        scale.x = x;
        transform.localScale = scale;
        return transform;
    }
    ///<summary>yスケールのみ代入</summary>
    public static Transform SetScaleY(this Transform transform, float y)
    {
        Vector3 scale = transform.localScale;
        scale.y = y;
        transform.localScale = scale;
        return transform;
    }
    ///<summary>zスケールのみ代入</summary>
    public static Transform SetScaleZ(this Transform transform, float z)
    {
        Vector3 scale = transform.localScale;
        scale.z = z;
        transform.localScale = scale;
        return transform;
    }

    ///<summary>Z方向が、対象のGameObjectに向く。</summary>
    public static void LookAt(this Transform transform, GameObject go) {
        transform.LookAt(go.transform);
    }

    ///<summary>1つの軸を固定して、対象のVector3に向く。<para>3D移動でよく使うY軸回転は「axis=Vector3.up」</para></summary>
    public static void LookAtAxis(this Transform transform, Vector3 targetPos, Vector3 axis) {
        //指定した軸は変更しないように積で0にする
        Vector3 diff = Vector3.Scale((targetPos - transform.position), Vector3.one - axis);
        //FromToRotaion(向かせたい軸Vec3, 向かせる方向Vec3)
        transform.rotation = Quaternion.FromToRotation(Vector3.forward, diff);
    }

    ///<summary>Y方向が、対象のGameObjectに向く。transform.LookAtの2D版。</summary>
    public static void LookAt2D(this Transform transform, GameObject targetObject) {
        transform.LookAt2D(targetObject.transform.position);
    }

    ///<summary>Y方向が、対象のTransformに向く。transform.LookAtの2D版。</summary>
    public static void LookAt2D(this Transform transform, Transform targetTransform) {
        transform.LookAt2D(targetTransform.position);
    }

    ///<summary>Y方向が、対象のVector3に向く。transform.LookAtの2D版。</summary>
    public static void LookAt2D(this Transform transform, Vector3 targetPos) {
        Vector3 diff = (targetPos - transform.position);
        diff.z = 0;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, diff);
    }

    ///<summary>タグを変更する。</summary>
    public static void SetTag(this Transform transform, string newtag) {
        transform.tag = newtag;
    }

    ///<summary>親を変更する。</summary>
    public static void SetParent(this Transform transform, Transform targetParent) {
        transform.parent = targetParent;
    }

    ///<summary>親オブジェクトを再帰的にnameで探す。最も近い親を返す。存在しなければnullを返す。
    ///<para>親になっているものしか探せない。</para></summary>
    public static Transform FindParent(this Transform transform, string name) {
        if(transform.parent == null) return null;
        if(transform.parent.name.Equals(name)) return transform.parent;
        else return transform.parent.FindParent(name);
    }

    //--------------動作未確認-------------------
    ///<summary>GameObjectを球で検出し、指定したタグのGameObjectがある場合に最短距離にあるGameObjectを返す。</summary>
    public static GameObject GetClosestObjectSphereWithTag(this Transform transform, float searchRadius, string tag) {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, searchRadius, Vector3.zero, 0.01f);

        if(hits.Length <= 0) return null;

        float minDistance = searchRadius;
        GameObject closestObj = null;

        foreach(RaycastHit hit in hits) {
            if(hit.transform.CompareTag(tag) == false) continue;

            if(hit.distance < minDistance) {
                minDistance = hit.distance;
                closestObj = hit.transform.gameObject;
            }
        }

        return closestObj;
    }
}

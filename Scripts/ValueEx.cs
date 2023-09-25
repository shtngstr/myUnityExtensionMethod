public static class ValueEx
{
    ///<summary>範囲に応じた0と1の間に正規化した値を返す。</summary>
    // n : min-maxの範囲にあり、min-maxで正規化したい値
    public static float Normalize01(this float n, float min, float max)
    {
        //min-maxの範囲から外れた値の時は0,1で返す
        if(n <= min) return 0;
        else if(n >= max) return 1;
        return ((n - min) / (max - min));   
    }
}

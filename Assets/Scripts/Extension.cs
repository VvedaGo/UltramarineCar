using UnityEngine;

public static class Extension
{
    public static Enums.SideTile GetInvertSide(this Enums.SideTile currentSide )
    {
        if (currentSide == Enums.SideTile.Down)
            return Enums.SideTile.Up;
        if (currentSide == Enums.SideTile.Up)
            return Enums.SideTile.Down;
        if (currentSide == Enums.SideTile.Left)
            return Enums.SideTile.Right;
        if (currentSide == Enums.SideTile.Right)
            return Enums.SideTile.Left;
        return Enums.SideTile.Down;
    }
    public static Enums.SideTile GetNextSideAfterRotate(this Enums.SideTile currentSide )
    {
        if (currentSide == Enums.SideTile.Down)
            return Enums.SideTile.Left;
        if (currentSide == Enums.SideTile.Up)
            return Enums.SideTile.Right;
        if (currentSide == Enums.SideTile.Left)
            return Enums.SideTile.Up;
        if (currentSide == Enums.SideTile.Right)
            return Enums.SideTile.Down;
        return Enums.SideTile.Down;
    }
    public static Enums.NumberOfWay GetInvertNumberOfWay(this Enums.NumberOfWay currentNumber )
    {
        if (currentNumber == Enums.NumberOfWay.First)
            return Enums.NumberOfWay.Third;
        if (currentNumber == Enums.NumberOfWay.Third)
            return Enums.NumberOfWay.First;
        
        return Enums.NumberOfWay.Second;
    }

    public static Vector3 DirectionBySide(this Enums.SideTile side)
    {
        switch (side)
        {
            case Enums.SideTile.Down:
                return new Vector3(0,0,-1);
            case Enums.SideTile.Left:
                return new Vector3(-1,0,0);
            case Enums.SideTile.Up:
                return new Vector3(0,0,1);
            case Enums.SideTile.Right:
                return new Vector3(1,0,0);
            default:
                return new Vector3(0,0,0);
        }
    }
}
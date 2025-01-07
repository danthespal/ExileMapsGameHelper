using System;
using System.Globalization;
using System.Numerics;
using GameOffsets.Natives;
using SharpDX;

namespace GameOffsets.Natives;

public struct Vector2i : IEquatable<Vector2i>
{
    public int X;

    public int Y;

    public static Vector2i Zero { get; } = new Vector2i(0, 0);

    public static Vector2i One { get; } = new Vector2i(1, 1);

    public Vector2i(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int Length()
    {
        return (int)Math.Sqrt(LengthSqr());
    }

    public int LengthSqr()
    {
        return X * X + Y * Y;
    }

    public void Normalize()
    {
        int num = Length();
        Divide(ref this, num, out this);
    }

    public int Distance(Vector2i v)
    {
        return Distance(ref this, ref v);
    }

    public float DistanceF(Vector2i v)
    {
        return DistanceF(ref this, ref v);
    }

    public int Distance(ref Vector2i v)
    {
        return Distance(ref this, ref v);
    }

    public int DistanceSqr(Vector2i v)
    {
        return DistanceSqr(ref this, ref v);
    }

    public int DistanceSqr(ref Vector2i v)
    {
        return DistanceSqr(ref this, ref v);
    }

    public SharpDX.Vector3 ToVector3()
    {
        return new SharpDX.Vector3(X, Y, 0f);
    }

    public SharpDX.Vector2 ToVector2()
    {
        return new SharpDX.Vector2(X, Y);
    }

    public System.Numerics.Vector2 ToVector2Num()
    {
        return new System.Numerics.Vector2(X, Y);
    }

    public bool Equals(Vector2i other)
    {
        return Equals(ref this, ref other);
    }

    public bool Equals(ref Vector2i other)
    {
        return Equals(ref this, ref other);
    }

    public static bool Equals(ref Vector2i v1, ref Vector2i v2)
    {
        if (v1.X == v2.X)
        {
            return v1.Y == v2.Y;
        }
        return false;
    }

    public static bool operator ==(Vector2i ls, Vector2i rs)
    {
        return Equals(ref ls, ref rs);
    }

    public static bool operator !=(Vector2i ls, Vector2i rs)
    {
        return !Equals(ref ls, ref rs);
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }
        try
        {
            return Equals((Vector2i)obj);
        }
        catch (InvalidCastException)
        {
            return false;
        }
    }

    public override int GetHashCode()
    {
        return (X.GetHashCode() * 397) ^ Y.GetHashCode();
    }

    public override string ToString()
    {
        return string.Format(CultureInfo.InvariantCulture, "{{{0}, {1}}}", X, Y);
    }

    public static Vector2i operator +(Vector2i ls, Vector2i rs)
    {
        Add(ref ls, ref rs, out var result);
        return result;
    }

    public static Vector2i operator -(Vector2i ls, Vector2i rs)
    {
        Subtract(ref ls, ref rs, out var result);
        return result;
    }

    public static Vector2i operator -(Vector2i v)
    {
        v.X = -v.X;
        v.Y = -v.Y;
        return v;
    }

    public static Vector2i operator *(Vector2i ls, Vector2i rs)
    {
        Multiply(ref ls, ref rs, out var result);
        return result;
    }

    public static Vector2i operator *(Vector2i ls, int rs)
    {
        Multiply(ref ls, rs, out var result);
        return result;
    }

    public static Vector2i operator *(Vector2i ls, float rs)
    {
        return new Vector2i((int)((float)ls.X * rs), (int)((float)ls.Y * rs));
    }

    public static Vector2i operator /(Vector2i ls, Vector2i rs)
    {
        Multiply(ref ls, ref rs, out var result);
        return result;
    }

    public static Vector2i operator /(Vector2i ls, int rs)
    {
        Divide(ref ls, rs, out var result);
        return result;
    }

    public static implicit operator System.Numerics.Vector2(Vector2i vector)
    {
        return vector.ToVector2Num();
    }

    public static void Add(ref Vector2i v1, ref Vector2i v2, out Vector2i result)
    {
        result = new Vector2i
        {
            X = v1.X + v2.X,
            Y = v1.Y + v2.Y
        };
    }

    public static void Subtract(ref Vector2i v1, ref Vector2i v2, out Vector2i result)
    {
        result = new Vector2i
        {
            X = v1.X - v2.X,
            Y = v1.Y - v2.Y
        };
    }

    public static void Multiply(ref Vector2i v1, ref Vector2i v2, out Vector2i result)
    {
        result = new Vector2i
        {
            X = v1.X * v2.X,
            Y = v1.Y * v2.Y
        };
    }

    public static Vector2i Multiply(Vector2i v1, Vector2i v2)
    {
        Vector2i result = default(Vector2i);
        result.X = v1.X * v2.X;
        result.Y = v1.Y * v2.Y;
        return result;
    }

    public static void Multiply(ref Vector2i v1, float scalar, out Vector2i result)
    {
        result = new Vector2i
        {
            X = (int)((float)v1.X * scalar),
            Y = (int)((float)v1.Y * scalar)
        };
    }

    public static void Divide(ref Vector2i v1, ref Vector2i v2, out Vector2i result)
    {
        result = new Vector2i
        {
            X = v1.X / v2.X,
            Y = v1.Y / v2.Y
        };
    }

    public static void Divide(ref Vector2i v1, float divisor, out Vector2i result)
    {
        Multiply(ref v1, 1f / divisor, out result);
    }

    public static int Distance(ref Vector2i v1, ref Vector2i v2)
    {
        return (int)Math.Sqrt(DistanceSqr(ref v1, ref v2));
    }

    public static float DistanceF(ref Vector2i v1, ref Vector2i v2)
    {
        return (float)Math.Sqrt(DistanceSqr(ref v1, ref v2));
    }

    public static int DistanceSqr(ref Vector2i v1, ref Vector2i v2)
    {
        int num = v1.X - v2.X;
        int num2 = v1.Y - v2.Y;
        return num * num + num2 * num2;
    }

    public static void GetDirection(ref Vector2i from, ref Vector2i to, out Vector2i dir)
    {
        Subtract(ref to, ref from, out dir);
        dir.Normalize();
    }

    public static Vector2i Min(Vector2i v1, Vector2i v2)
    {
        Min(ref v1, ref v2, out var result);
        return result;
    }

    public static void Min(ref Vector2i v1, ref Vector2i v2, out Vector2i result)
    {
        result = default(Vector2i);
        result.X = Math.Min(v1.X, v2.X);
        result.Y = Math.Min(v1.Y, v2.Y);
    }

    public static Vector2i Max(Vector2i v1, Vector2i v2)
    {
        Max(ref v1, ref v2, out var result);
        return result;
    }

    public static void Max(ref Vector2i v1, ref Vector2i v2, out Vector2i result)
    {
        result = new Vector2i
        {
            X = Math.Max(v1.X, v2.X),
            Y = Math.Max(v1.Y, v2.Y)
        };
    }

    public static int Dot(Vector2i v1, Vector2i v2)
    {
        return v1.X * v2.X + v1.Y * v2.Y;
    }
}
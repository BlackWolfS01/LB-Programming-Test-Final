
using System;
public struct Vector3
{
    public float X;
    public float Y;
    public float Z;

    public Vector3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    // Length of Object
    // Check for collision with Objects
    public float Length()
    {
        return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
    }
    
    // Distance between Source object and Other object
    public float Dist(Vector3 other)
    {
        float dx = X - other.X;
        float dy = Y - other.Y;
        float dz = Z - other.Z;
        return (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);
    }

    public float Dist(Vector3 o1, Vector3 o2)
    {
        float dx = o1.X - o2.X;
        float dy = o1.Y - o2.Y;
        float dz = o1.Z - o2.Z;
        return (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);
    }

    public float[] getVectorAsArray()
    {
        float[] v = { this.X, this.Y, this.Z };
        return v;
    }

    public void Normalize()
    {
        float length = Length();
        if (length != 0.0f)
        {
            X /= length;
            Y /= length;
            Z /= length;
        }
    }

    public override string ToString()
    {
        return String.Format("x:{0:0.000}, y:{1:0.000}, z:{2:0.000}", X, Y, Z);
    }

    public static Vector3 operator +(Vector3 left, Vector3 right)
    {
        left.X += right.X;
        left.Y += right.Y;
        left.Z += right.Z;
        return left;
    }

    public static Vector3 operator *(Vector3 left, float scalar)
    {
        left.X *= scalar;
        left.Y *= scalar;
        left.Z *= scalar;
        return left;
    }

    public static bool operator ==(Vector3 left, Vector3 right)
    {
        return left.X == right.X && left.Y == right.Y && left.Z == right.Z;
    }

    public static bool operator !=(Vector3 left, Vector3 right)
    {
        return (left.X != right.X) || (left.Y != right.Y) || (left.Z != right.Z);
    }

    public static Vector3 RndVector(ref Random rnd)
    {
        Vector3 rndVec = new Vector3((float)((rnd.NextDouble() - 0.5) * 2),
                                     (float)((rnd.NextDouble() - 0.5) * 2),
                                     (float)((rnd.NextDouble() - 0.5) * 2));
        return rndVec;
    }

    public static Vector3 RndNormalVector(ref Random rnd)
    {
        Vector3 rndVec = new Vector3((float)((rnd.NextDouble() - 0.5) * 2),
                                     (float)((rnd.NextDouble() - 0.5) * 2),
                                     (float)((rnd.NextDouble() - 0.5) * 2));
        rndVec.Normalize();
        return rndVec;
    }


    public static Vector3 ZeroVector = new Vector3(0.0f, 0.0f, 0.0f);
}


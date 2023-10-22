using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public int numLatitudeSegments = 16;  // Number of latitude segments.
    public int numLongitudeSegments = 32; // Number of longitude segments.
    public float radius = 1.0f;           // Radius of the sphere.

    void OnDrawGizmos()
    {
        GL.PushMatrix();
        GL.MultMatrix(transform.localToWorldMatrix);
        GL.Begin(GL.LINES);

        // Set the color of the sphere.
        GL.Color(Color.cyan);

        // Calculate the angle increment for both latitude and longitude.
        float latitudeIncrement = 180.0f / numLatitudeSegments;
        float longitudeIncrement = 360.0f / numLongitudeSegments;

        // Create the vertices for the sphere.
        for (int lat = 0; lat <= numLatitudeSegments; lat++)
        {
            float angle1 = lat * latitudeIncrement - 90.0f;
            float angle2 = (lat + 1) * latitudeIncrement - 90.0f;

            for (int lon = 0; lon <= numLongitudeSegments; lon++)
            {
                float angle3 = lon * longitudeIncrement;
                float angle4 = (lon + 1) * longitudeIncrement;

                Vector3 p1 = GetPointOnSphere(radius, angle1, angle3);
                Vector3 p2 = GetPointOnSphere(radius, angle1, angle4);
                Vector3 p3 = GetPointOnSphere(radius, angle2, angle3);
                Vector3 p4 = GetPointOnSphere(radius, angle2, angle4);

                // Draw the lines for the sphere.
                GL.Vertex(p1);
                GL.Vertex(p2);

                GL.Vertex(p1);
                GL.Vertex(p3);

                if (lat < numLatitudeSegments)
                {
                    GL.Vertex(p3);
                    GL.Vertex(p4);
                }
            }
        }

        GL.End();
        GL.PopMatrix();
    }

    Vector3 GetPointOnSphere(float radius, float latitude, float longitude)
    {
        float latRad = Mathf.Deg2Rad * latitude;
        float lonRad = Mathf.Deg2Rad * longitude;

        float x = radius * Mathf.Sin(latRad) * Mathf.Cos(lonRad);
        float y = radius * Mathf.Cos(latRad);
        float z = radius * Mathf.Sin(latRad) * Mathf.Sin(lonRad);

        return new Vector3(x, y, z);
    }
}

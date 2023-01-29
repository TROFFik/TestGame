using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]
public class PlaneCreator : MonoBehaviour
{
    private Mesh _mesh;

    private Vector3[] _vertices;
    private int[] _triangels;

    private int _xSize;
    private int _ySize;

    public void StartCreate(int xSize, int ySize)
    {
        _xSize = xSize;
        _ySize = ySize;

        _mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = _mesh;

        CreateMesh();
        UpdateMesh();
    }

    private void CreateMesh()
    {
        _vertices = new Vector3[4];

        for (int i = 0, y = 0; y <= 1; y++)
        {
            for (int x = 0; x <= 1; x++)
            {
                _vertices[i] = new Vector3(_xSize * x, 0, _ySize * y);
                i++;
            }
        }
        
        _triangels = new int[6];

        for (int i = 2; i >= 0; i--)
        {
            _triangels[2 - i] = i;
        }

        for (int i = 3; i <= 5; i++)
        {
            _triangels[i] = i - 2;
        }
    }

    private void UpdateMesh()
    {
        _mesh.Clear();
        _mesh.vertices = _vertices;
        _mesh.triangles = _triangels;
        _mesh.RecalculateNormals();

        gameObject.GetComponent<MeshCollider>().sharedMesh = _mesh;
    }
}

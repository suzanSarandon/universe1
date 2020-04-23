// using UnityEngine;
// public class Planet : MonoBehaviour 
//  {
//      public Circle circle;
//      public Line line;
 
//      private float RotateSpeed = 5f;
     
//      private float Radius;
     
 
//      private Vector2 _centre;
//      private float _angle;
 
//      private void Start()
//      {
//          _centre = transform.position;
//          Radius = circle.radius;
         
//      }
 
//      private void Update()
//      {
 
//          _angle += RotateSpeed * Time.deltaTime;
 
//          var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
//          transform.position = _centre + offset;
//      }
  
  
 
//  }

using UnityEngine;

public class Planet : MonoBehaviour
{ 
    public Circle circle;
    private LineRenderer lineRenderer;
    public int vertexCount = 40;
  public float lineWidth = 0.2f;
  public float radius;
    
   
    public Vector2 Velocity = new Vector2(1, 0);

    [Range(0, 5)] 
    public float RotateSpeed = 1f;
    [Range(0, 5)]
    public float RotateRadiusX = 1f;
    [Range(0, 5)]
    public float RotateRadiusY = 1f;

    public bool Clockwise = true;

    private Vector2 _centre;
    private float _angle;

    private void Start()
    {
        _centre = transform.position;
        float radius = circle.radius;
    }

    private void Update()
    {
        _centre += Velocity * Time.deltaTime;

        _angle += (Clockwise ? RotateSpeed : -RotateSpeed) * Time.deltaTime;

        var x = Mathf.Sin(_angle) * RotateRadiusX;
        var y = Mathf.Cos(_angle) * RotateRadiusY;

        transform.position = _centre + new Vector2(x, y);
    }

      private void SetupPlanet()
  {
      lineRenderer.widthMultiplier = lineWidth;
     

      float deltaTheta = (2f * Mathf.PI) / vertexCount;
      float theta = 0f;

      lineRenderer.positionCount = vertexCount;
      for (int i = 0; i<lineRenderer.positionCount; i++)
      {
          Vector3 pos = new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta), 0f);
          lineRenderer.SetPosition(i,pos);
          theta += deltaTheta;
      }
  }
}
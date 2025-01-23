using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Uimanger : MonoBehaviour
{
   public Light DLight;
   
   public Material material;

   public Vector3 originalPosition;
   public GameObject PlaceHolder;
   public GameObject PlaceHolderObject;
   public GameObject ball;
   public GameObject Stars;
   public GameObject Prism;
   public GameObject Moon;
   public GameObject Board;
   public GameObject Cube;
   public GameObject Earth;
   public GameObject Cheese;
   public Slider slider;
   public Slider slider1;
   public Slider slider2;
   public Slider slider3;
   public Slider slider4;
   public GameObject Cube1;

   public GameObject Cylinder;
   public GameObject Sphere;

   public GameObject Quad;

   public float movementSpeed = 0.5f;


   private GameObject selectedLight;

   public GameObject[] LightTypes = new GameObject[2];

   List<GameObject> Lights = new List<GameObject>();

   LightmapData[] lightmaps_data;
   public GameObject objectholder;

   private GameObject selectedObject;

   public GameObject[] ObjectTypes = new GameObject[5];


  List<GameObject> ObjectsHolder = new List<GameObject>();

   #region Colors Setters

   public void SetRedColor()
   {
        DLight.color = Color.red;
     
   }
    
    public void SetGreenColor()
   {
        DLight.color = Color.green;
   }

   public void SetYellowColor()
   {
        DLight.color = Color.yellow;
   }
    
    public void SetBlueColor()
   {
        DLight.color = Color.blue;
   }
    
    public void SetWhiteColor()
   {
        DLight.color = Color.white;
   }
    
    public void SetorangeColor()
   {
        DLight.color = new Color(1f, 0.5f, 0f, 1f);
   }

     #endregion

   #region Object Changers

    public void ChangeStars()
    {
     Destroy(PlaceHolderObject);
     PlaceHolderObject = Instantiate(Stars, new Vector3(0,1,0), Quaternion.identity, PlaceHolder.transform);
    }

    public void ChangePrism()
    {
     Destroy(PlaceHolderObject);
     PlaceHolderObject = Instantiate(Prism, new Vector3(0,1,0), Quaternion.identity, PlaceHolder.transform);
    }
     public void ChangeMoon()
    {
     Destroy(PlaceHolderObject);
     PlaceHolderObject = Instantiate(Moon, new Vector3(0,1,0), Quaternion.identity, PlaceHolder.transform);
    }
     public void ChangeBoard()
    {
      Destroy(PlaceHolderObject);
      PlaceHolderObject = Instantiate(Board, new Vector3(0,1,0), Quaternion.identity, PlaceHolder.transform);
    }
     public void ChangeCube()
    {
      Destroy(PlaceHolderObject);
      PlaceHolderObject = Instantiate(Cube, new Vector3(0,1,0), Quaternion.identity, PlaceHolder.transform);
    }
     public void ChangeEarth()
    {
      Destroy(PlaceHolderObject);
      PlaceHolderObject = Instantiate(Earth, new Vector3(0,1,0), Quaternion.identity, PlaceHolder.transform);
    }
     public void ChangeCheese()
    {
      Destroy(PlaceHolderObject);
      PlaceHolderObject = Instantiate(Cheese, new Vector3(0,1,0), Quaternion.identity, PlaceHolder.transform);
    }
     public void ChangeQuad()
     {
     ReplacePlaceholder(0);
     }

     public void ChangeCubes()
     {
     ReplacePlaceholder(1);
     }

     public void ChangeSphere()
     {
     ReplacePlaceholder(2);
     }

     public void ChangeCylinder()
     {
     ReplacePlaceholder(3);
     }

     private void ReplacePlaceholder(int index)
{
    if (ObjectsHolder == null)
    {
        Debug.LogError("objectsHolder is null. Please assign it in the Inspector.");
        return;
    }

    if (ObjectsHolder.Count <= index)
    {
        Debug.LogError($"Index {index} is out of range. objectsHolder contains {ObjectsHolder.Count} elements.");
        return;
    }

    if (PlaceHolderObject != null)
        Destroy(PlaceHolderObject);

    PlaceHolderObject = Instantiate(ObjectsHolder[index], new Vector3(0, 1, 0), Quaternion.identity, PlaceHolder.transform);
    Debug.Log($"Successfully replaced placeholder with: {ObjectsHolder[index].name}");
}



    #endregion

    void Start()
    {
          lightmaps_data = LightmapSettings.lightmaps;
          originalPosition = PlaceHolder.transform.position;
          ObjectsHolder = new List<GameObject> { Cube1,Quad,Cylinder,Sphere };
    }
    

    public void SetLight(int lightType)
    {
          switch (lightType)
          {
               case 0:
                    selectedLight = LightTypes[0];
                    break;
               case 1:
                    selectedLight = LightTypes[1];
                    break;
               case 2:
                    selectedLight = LightTypes[2];
                    break;
               case 3: 
                    selectedLight = LightTypes[3];
                    break;

               default:
                    Debug.LogWarning("Light Types are not properly assigned");
                    break;
          }
    }
   
    public void SetObject(int objectType)
{
    switch (objectType)
    {
        case 0:
            selectedObject = ObjectTypes[0];
            break;
        case 1:
            selectedObject = ObjectTypes[1];
            break;
        case 2:
            selectedObject = ObjectTypes[2];
            break;
        case 3:
            selectedObject = ObjectTypes[3];
            break;
        default:
            Debug.LogWarning("Object Types are not properly assigned or out of range.");
            break;
    }
}

    public void AddLight()
    {
          GameObject temp = Instantiate(selectedLight);
          Lights.Add(temp);
    }

    public void RemoveLight()
    {
          GameObject temp = Lights[0];
          Lights.Remove(temp);
          Destroy(temp);
    }
    public void AddObject()
     {
          GameObject temp = Instantiate(selectedObject);
          ObjectsHolder.Add(temp);
     }

     public void RemoveObject()
     {
     if (ObjectsHolder.Count > 0)
     {
          GameObject temp = ObjectsHolder[0];
          ObjectsHolder.Remove(temp);
          Destroy(temp);
     }
     }
     

     public void SetRotation(float value)
     {
          PlaceHolder.transform.rotation = Quaternion.Euler(0,value,0);
     }
     public void SetRotationxaxis(float value)
     {
          PlaceHolder.transform.rotation = Quaternion.Euler(value, 0, 0);
     }
     public void  Reset() 
     {
          slider.value = 1;
          slider1.value= 0;
          slider2.value= 0;
          slider3.value= 0;
          slider4.value= 0;

          PlaceHolder.transform.SetPositionAndRotation(originalPosition, Quaternion.identity);
     }

     public void SetMovement(float xvalue)
     {
     Vector3 newPosition = PlaceHolder.transform.position;
     newPosition.x = xvalue * movementSpeed * Time.deltaTime;
     PlaceHolder.transform.position = newPosition;
     }

     public void SetMovemennty(float yvalue)
     {
          PlaceHolder.transform.position = new Vector3( PlaceHolderObject.transform.position.x , yvalue,PlaceHolderObject.transform.position.z) * movementSpeed * Time.deltaTime;
     }
    

    public void ToggleLighting(bool toggle)
    {
          if(toggle)
               enableLightmaps();
          else
               disableLightmaps();
    }

    public void disableLightmaps()
    {
          LightmapSettings.lightmaps = new LightmapData[]{};
    } 
    public void enableLightmaps()
    {
          LightmapSettings.lightmaps = lightmaps_data;
    }


} 



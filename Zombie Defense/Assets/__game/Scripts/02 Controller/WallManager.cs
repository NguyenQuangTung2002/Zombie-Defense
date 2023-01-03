using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    public List<GameObject> rooms;
    public List<GameObject> wallRoom;
    public List<GameObject> allWalls;
    public GameObject objectBetween;
    public static WallManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        foreach (var item in rooms)
        {
            for (int i = 0; i < item.transform.childCount; i++) allWalls.Add(item.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < objectBetween.transform.childCount; i++) allWalls.Add(objectBetween.transform.GetChild(i).gameObject);
        
    }

    public void SetStateCommonWall(GameObject room)
    {
        GetWallsOfRoom(room);

        foreach (var wall in wallRoom)
        {
            int countWall = 0;
            GameObject betweenTwoRoom =null;
            List<GameObject> wallToSetFalse = new List<GameObject>();
            
            wallToSetFalse.Add(wall);
            
            foreach (var otherwall in allWalls)
            {
                Vector3 positionWall = new Vector3(wall.transform.position.x, 0, wall.transform.position.z);
                Vector3 positionOtherwall = new Vector3(otherwall.transform.position.x, 0, otherwall.transform.position.z);
                
                // while other room is active
                if (wall.transform != otherwall.transform
                    && positionWall ==positionOtherwall && otherwall.activeInHierarchy)
                {
                    wallToSetFalse.Add(otherwall);
                    countWall++;
                    if (otherwall.layer > wall.layer)
                    {
                        wall.SetActive(false);
                    } else if (otherwall.layer < wall.layer)
                    {
                        otherwall.SetActive(false);
                    }
                    else if(otherwall.layer == 18 && wall.layer==18)
                    {
                        wall.SetActive(false);
                        otherwall.SetActive(false);
                    }
                }
                
                // while other room is not active
                if (wall.transform != otherwall.transform
                    && positionWall == positionOtherwall && !otherwall.activeInHierarchy)
                {
                    if (otherwall.layer == 20)
                    {
                        countWall++;
                        betweenTwoRoom = otherwall;
                    }
                    else
                    {
                        wallToSetFalse.Add(otherwall);
                    }
                }
            }
            
            if (countWall == 2)
            {
                foreach (var item in wallToSetFalse)
                {
                    item.SetActive(false);
                }
                betweenTwoRoom.gameObject.SetActive(true);
            }
            
        }
    }

    private void GetWallsOfRoom(GameObject room)
    {
        wallRoom.Clear();
        
        foreach (var item in rooms)
        {
            if (item.GetInstanceID() == room.GetInstanceID())
                for (int i = 0; i < item.transform.childCount; i++)
                    wallRoom.Add(item.transform.GetChild(i).gameObject);
        }
    }
}
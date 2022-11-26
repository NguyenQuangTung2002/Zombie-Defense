using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;
[CreateAssetMenu(fileName = "Prefab brush", menuName = "Brush/Prefab brush")]
[CustomGridBrush(false,true,false,"Prefab brush")]
public class PrefabBrush : GameObjectBrush
{
  
    public override void Erase(GridLayout gridLayout, GameObject brushTarget, Vector3Int position)
    {
        if (brushTarget.layer == 31)
        {
            return;
        }

        Transform erased =
            GetObjectIncell(gridLayout, brushTarget.transform, position, cells[0]);
        
        if (erased != null)
        {
            Undo.DestroyObjectImmediate(erased.gameObject);
        }
        else
        {
            Debug.Log("0 erased object");
        }
  
    }

    private static Transform GetObjectIncell(GridLayout grid, Transform parent, Vector3Int position,BrushCell cell)
    {
        int childCount = parent.childCount;
        Vector3 min = grid.LocalToWorld(grid.CellToLocalInterpolated(position));
        Vector3 max = grid.LocalToWorld(grid.CellToLocalInterpolated(position + Vector3Int.one));
        Vector3 cellCenter = (max + min) * 0.5f;
        for (int i = 0; i < childCount; i++)
        {
            Transform child = parent.GetChild(i);
            if ( MathExtra.Round(cellCenter + cell.offset) == MathExtra.Round(child.position))
            {
                return child;
            }
        }
        return null;
    }
    
   
}

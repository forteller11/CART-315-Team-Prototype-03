using System;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

namespace Behaviors
{
    [Serializable]
    public class BoxCollider2DClass
    {
        public Vector2 OffsetToCenter = new Vector2(0f,0f);
        public Vector2 SizeRelative = new Vector2(1f,1f);

        //TODO collision check with objects using tags

        public void DebugDraw(Vector3 parentPosition, Vector3 parentScale)
        {
            DebugDraw(parentPosition.ToVector2XY(), parentScale.ToVector2XY());
        }

        public void DebugDraw(Vector2 parentPosition, Vector2 parentScale)
        {
            var centerGlobal = parentPosition + OffsetToCenter;

            var halfSizeGlobal = parentScale * (SizeRelative / 2f);
            var x1 = centerGlobal.x - halfSizeGlobal.x;
            var x2 = centerGlobal.x + halfSizeGlobal.x;
            var y1 = centerGlobal.y - halfSizeGlobal.y;
            var y2 = centerGlobal.y + halfSizeGlobal.y;
            
            var pointLeftDown = new Vector2(x1, y1);
            var pointLeftUp = new Vector2(x1, y2);
            var pointRightDown = new Vector2(x2, y1);
            var pointRightUp = new Vector2(x2, y2);
                
            Debug.DrawLine(pointLeftDown, pointLeftUp);
            Debug.DrawLine(pointLeftUp, pointRightUp);
            Debug.DrawLine(pointRightUp, pointRightDown);
            Debug.DrawLine(pointRightDown, pointLeftDown);
        }
        //TODO debug drawer
        
    }
}
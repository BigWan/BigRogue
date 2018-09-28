﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BigRogue.PathFinding {

    /// <summary>
    /// 寻路网格(寻路只在这部分网格内进行)
    /// </summary>
    public class NodeMesh {

        /// <summary>
        /// 寻路的结点
        /// </summary>
        private Dictionary<Vector2Int,PathNode> nodeDict;


        public NodeMesh(Dictionary<Vector2Int, PathNode> nodeDict) {
            this.nodeDict = nodeDict;
        }

        public NodeMesh() {
            nodeDict = new Dictionary<Vector2Int, PathNode>();
        }

        /// <summary>
        /// 是否存在某个节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool Exists(PathNode node) {
            return nodeDict.ContainsValue(node);
        }



        /// <summary>
        /// 添加节点
        /// </summary>
        public void AddNode(Vector2Int key,PathNode value) {
            nodeDict.Add(key, value);
        }

        public PathNode GetNode(Vector2Int coordinate) {
            return nodeDict[coordinate];
        }
        /// <summary>
        /// 获取邻居结点
        /// </summary>
        /// <param name="point"></param>
        /// <param name="allowDiagonal">是否包括斜边</param>
        /// <returns></returns>
        public List<PathNode> GetNeighbour(PathNode point, bool allowDiagonal = true) {

            List<PathNode> temp = new List<PathNode>();
                      

            Vector2Int center = point.coordinate2D;

            List<Vector2Int> neighbourCoordinates = center.GetNeightbours(allowDiagonal);

            foreach (var item in neighbourCoordinates) {
                if (nodeDict.ContainsKey(item))
                    temp.Add(nodeDict[item]);
            }

            return temp;
        }




    }

}

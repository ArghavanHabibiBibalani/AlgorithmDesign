﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using AlgorithmsLib;

namespace AlgorithmsLib
{
    public class GraphAlgorithms
    {
        public static int[] _number;
        public static int[] _rank;
        public static int Kruskal(int NumberOfVertices, int NumberOfEdges, int[,] edges  )
        {
            Tuple<int, int, int>[] _saveEdges = new Tuple<int, int, int>[NumberOfEdges];
            
            for ( int i = 0; i < NumberOfEdges; i++ )///////////////////////////////////
            {
                int u = edges[i, 0];
                int v = edges[i, 1];
                int w = edges[i, 2];
                _saveEdges[i] = new Tuple<int, int, int>(w, u, v );
            }

            Array.Sort(_saveEdges);

            int answer = 0;
            _number = new int[NumberOfVertices + 1];
            _rank = new int[NumberOfVertices + 1];

            for(int i = 0; i < NumberOfVertices + 1;i++ )
            {
                _number[i] = i;
                _rank[i] = 1;
            }

            for(int i = 1; i <= NumberOfEdges; i++ )
            {
                int w = _saveEdges[i - 1].Item1;
                int u = _saveEdges[i - 1].Item2;
                int v = _saveEdges[i - 1].Item3;

                bool _flag = Union(u, v);
                if (_flag == false) 
                {
                    answer += w;
                }
            }
            return answer;
        }
        public static bool Union(int a, int b)
        {
            int _a = Find(a);
            int _b = Find(b);

            if(_a == _b == true) { return true; }
            else
            {
                if (_rank[_a] > _rank[_b])
                {
                    _number[_b] = _a;
                }
                else if (_rank[_a] < _rank[_b])
                {
                    _number[_a] = _b;
                }
                else {
                    _number[_a] = _b;
                    _rank[_b] ++;
                }
                return false;
            }
        }
        public static int Find(int x)
        {
            if (_number[x] == x == true)
            {
                return x;
            }

            int _temp = Find(_number[x]);
            _number[x] = _temp;
            return _temp;
        }
    }
}
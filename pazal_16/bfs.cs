using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pazal_16
{
    class bfs
    {
        string[,] data;
        int number_of_child;
        int length;
        bfs father;
        bfs child1, child2, child3, child4;
        bool node_is_result;
        public bfs()
        {
            data = new string[4, 4];
            number_of_child = 0;
            //child1 = new Ids();
            //child2 = new Ids();
            //child3 = new Ids();
            //child4 = new Ids();
            length = 0;
            node_is_result = false;
        }
        public bfs(string[,] data1, int number, int len ,bfs father1, bool result)
        {
            data = new string[4, 4];
            data = data1;
            number_of_child = number;
            length = len;
            father = father1;
            node_is_result = result;
        }
        public int search_whitespace(int l)
        {
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    if (data[i, j] == " ")
                        return (i + 1) * 10 + (j + 1);
                }
            }
            return 0;
        }
        bool is_result()
        {
            string[,] result = new string[4, 4];
            result[0, 0] = "1";
            result[0, 1] = "2";
            result[0, 2] = "3";
            result[0, 3] = "4";
            result[1, 0] = "12";
            result[1, 1] = "13";
            result[1, 2] = "14";
            result[1, 3] = "5";
            result[2, 0] = "11";
            result[2, 1] = " ";
            result[2, 2] = "15";
            result[2, 3] = "6";
            result[3, 0] = "10";
            result[3, 1] = "9";
            result[3, 2] = "8";
            result[3, 3] = "7";
            if (data == result)
            {
                return true;
            }
            return false;
        }
        public bfs bfs_tree()
        {
            bfs result=this;
            Queue <bfs> Queue1=new Queue<bfs>();
            bool flag=true;
            while(flag)
            {
                if(result.is_result())
                {
                    flag = false;
                    result.node_is_result = true;
                    return result;
                }
                else
                {
                    int space = result.search_whitespace(4);
                    if (space == 11 || space == 14 || space == 41 || space == 44)
                    {
                        result.number_of_child = 2;
                        string[,] data_change1, data_change2 = new string[4, 4];
                        data_change1 = result.data;
                        data_change2 = result.data;
                        if (space == 11)
                        {
                            data_change1[0, 0] = data_change1[1, 0];
                            data_change1[1, 0] = " ";
                            data_change2[0, 0] = data_change1[0, 1];
                            data_change2[0, 1] = " ";
                        }
                        if (space == 14)
                        {
                            data_change1[0, 3] = data_change1[0, 2];
                            data_change1[0, 2] = " ";
                            data_change2[0, 3] = data_change1[1, 3];
                            data_change2[1, 3] = " ";
                        }
                        if (space == 41)
                        {
                            data_change1[3, 0] = data_change1[3, 1];
                            data_change1[3, 1] = " ";
                            data_change2[3, 0] = data_change1[2, 0];
                            data_change2[2, 0] = " ";
                        }
                        if (space == 44)
                        {
                            data_change1[3, 3] = data_change1[3, 2];
                            data_change1[3, 2] = " ";
                            data_change2[3, 3] = data_change1[2, 3];
                            data_change2[2, 3] = " ";
                        }
                        result.child1 = new bfs(data_change1, 0, result.length + 1, result, false);
                        Queue1.Enqueue(result.child1);
                        result.child2 = new bfs(data_change2, 0, result.length + 1, result, false);
                        Queue1.Enqueue(result.child2);
                    }
                    if (space == 12 || space == 13 || space == 21 || space == 24 || space == 31 || space == 34 || space == 42 || space == 43)
                    {
                        result.number_of_child = 3;
                        string[,] data_change1, data_change2, data_change3 = new string[4, 4];
                        data_change1 = result.data;
                        data_change2 = result.data;
                        data_change3 = result.data;
                        if (space == 12)
                        {
                            data_change1[0, 1] = data_change1[0, 0];
                            data_change1[0, 0] = " ";
                            data_change2[0, 1] = data_change1[1, 1];
                            data_change2[1, 1] = " ";
                            data_change3[0, 1] = data_change3[0, 2];
                            data_change3[0, 2] = " ";
                        }
                        if (space == 13)
                        {
                            data_change1[0, 2] = data_change1[0, 1];
                            data_change1[0, 1] = " ";
                            data_change2[0, 2] = data_change1[1, 2];
                            data_change2[1, 2] = " ";
                            data_change3[0, 2] = data_change3[0, 3];
                            data_change3[0, 3] = " ";
                        }
                        if (space == 21)
                        {
                            data_change1[1, 0] = data_change1[2, 0];
                            data_change1[2, 0] = " ";
                            data_change2[1, 0] = data_change1[1, 1];
                            data_change2[1, 1] = " ";
                            data_change3[0, 1] = data_change3[0, 0];
                            data_change3[0, 0] = " ";
                        }
                        if (space == 24)
                        {
                            data_change1[1, 3] = data_change1[1, 2];
                            data_change1[1, 2] = " ";
                            data_change2[1, 3] = data_change1[2, 3];
                            data_change2[2, 3] = " ";
                            data_change3[1, 3] = data_change3[0, 3];
                            data_change3[0, 3] = " ";
                        }
                        if (space == 31)
                        {
                            data_change1[2, 0] = data_change1[3, 0];
                            data_change1[3, 0] = " ";
                            data_change2[2, 0] = data_change1[2, 1];
                            data_change2[2, 1] = " ";
                            data_change3[2, 0] = data_change3[1, 0];
                            data_change3[1, 0] = " ";
                        }
                        if (space == 34)
                        {
                            data_change1[2, 3] = data_change1[2, 2];
                            data_change1[2, 2] = " ";
                            data_change2[2, 3] = data_change1[3, 3];
                            data_change2[3, 3] = " ";
                            data_change3[2, 3] = data_change3[1, 3];
                            data_change3[1, 3] = " ";
                        }
                        if (space == 42)
                        {
                            data_change1[3, 1] = data_change1[3, 0];
                            data_change1[3, 0] = " ";
                            data_change2[3, 1] = data_change1[3, 2];
                            data_change2[3, 2] = " ";
                            data_change3[3, 1] = data_change3[2, 1];
                            data_change3[2, 1] = " ";
                        }
                        if (space == 43)
                        {
                            data_change1[3, 2] = data_change1[3, 1];
                            data_change1[3, 1] = " ";
                            data_change2[3, 2] = data_change1[3, 3];
                            data_change2[3, 3] = " ";
                            data_change3[3, 2] = data_change3[2, 2];
                            data_change3[2, 2] = " ";
                        }
                        result.child1 = new bfs(data_change1, 0, result.length + 1, result, false);
                        Queue1.Enqueue(result.child1);
                        result.child2 = new bfs(data_change2, 0, result.length + 1, result, false);
                        Queue1.Enqueue(result.child2);
                        result.child3 = new bfs(data_change3, 0, result.length + 1, result, false);
                        Queue1.Enqueue(result.child3);
                    }
                    if (space == 22 || space == 23 || space == 32 || space == 33)
                    {
                        result.number_of_child = 4;
                        string[,] data_change1, data_change2, data_change3, data_change4 = new string[4, 4];
                        data_change1 = result.data;
                        data_change2 = result.data;
                        data_change3 = result.data;
                        data_change4 = result.data;
                        if (space == 22)
                        {
                            data_change1[1, 1] = data_change1[1, 0];
                            data_change1[1, 0] = " ";
                            data_change2[1, 1] = data_change1[2, 1];
                            data_change2[2, 1] = " ";
                            data_change3[1, 1] = data_change3[1, 2];
                            data_change3[1, 2] = " ";
                            data_change4[1, 1] = data_change4[0, 1];
                            data_change4[0, 1] = " ";
                        }
                        if (space == 23)
                        {
                            data_change1[1, 2] = data_change1[1, 1];
                            data_change1[1, 1] = " ";
                            data_change2[1, 2] = data_change1[2, 2];
                            data_change2[2, 2] = " ";
                            data_change3[1, 2] = data_change3[1, 3];
                            data_change3[1, 3] = " ";
                            data_change4[1, 2] = data_change4[0, 2];
                            data_change4[0, 2] = " ";
                        }
                        if (space == 32)
                        {
                            data_change1[2, 1] = data_change1[2, 0];
                            data_change1[2, 0] = " ";
                            data_change2[2, 1] = data_change1[3, 1];
                            data_change2[3, 1] = " ";
                            data_change3[2, 1] = data_change3[2, 2];
                            data_change3[2, 2] = " ";
                            data_change4[2, 1] = data_change4[1, 1];
                            data_change4[1, 1] = " ";
                        }
                        if (space == 33)
                        {
                            data_change1[2, 2] = data_change1[2, 1];
                            data_change1[2, 1] = " ";
                            data_change2[2, 2] = data_change1[3, 2];
                            data_change2[3, 2] = " ";
                            data_change3[2, 2] = data_change3[2, 3];
                            data_change3[2, 3] = " ";
                            data_change4[2, 2] = data_change4[1, 2];
                            data_change4[1, 2] = " ";
                        }
                        result.child1 = new bfs(data_change1, 0, result.length + 1, result, false);
                        Queue1.Enqueue(result.child1);
                        result.child2 = new bfs(data_change2, 0, result.length + 1, result, false);
                        Queue1.Enqueue(result.child2);
                        result.child3 = new bfs(data_change3, 0, result.length + 1, result, false);
                        Queue1.Enqueue(result.child3);
                        result.child4 = new bfs(data_change4, 0, result.length + 1, result, false);
                        Queue1.Enqueue(result.child4);
                    }
                }
                result = Queue1.Dequeue();
            }
        }
    }
}

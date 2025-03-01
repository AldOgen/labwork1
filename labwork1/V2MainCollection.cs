﻿using System.Collections;
using System.Collections.Generic;

namespace labwork1
{
    public class V2MainCollection : IEnumerable
    {
        List<V2Data> ListData = new List<V2Data>();
        public int Count { get; set; } = 0;

        public void Add(V2Data item)
        {
            ListData.Add(item);
            ++Count;
        }

        public bool Remove(string id, double w)
        {
            int removedCount = ListData.RemoveAll(elem => elem.Description == id &&
                                                  elem.Freq_field == w);
            Count -= removedCount;
            return removedCount > 0;
        }

        public void AddDefaults()
        {
            for (int i = 0; i < 3; ++i) {
                V2DataOnGrid v2_data_on_grid = new V2DataOnGrid(0.0, "Default info", new double[] { 0.01, 0.01 }, new int[] { 5, 5 });
                v2_data_on_grid.InitRandom(-10.0f, 10.0f);
                ListData.Add(v2_data_on_grid);
                V2DataCollection v2_data_collection = new V2DataCollection(0.0, "Default info");
                v2_data_collection.InitRandom(5, 10.0f, 10.0f, -10.0f, 10.0f);
                ListData.Add(v2_data_collection);
            }
        }

        public override string ToString()
        {
            string str = "";

            foreach (V2Data dataElem in ListData) {
                str += $"{dataElem}\n\n";
            }

            return str;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)ListData).GetEnumerator();
        }
    }
}

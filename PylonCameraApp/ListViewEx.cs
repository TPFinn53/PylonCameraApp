using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace PylonCameraApp
{
    public class ListViewData
    {
        public int Index;
        public int Count;
    }
    public class ListViewEx : ListView
    {
        private List<ListViewData> list = new List<ListViewData>();
 
        public ListViewData this[int i] { get { return list[i]; } }

        public int Count { get { return list.Count; } }

        public void Add(Object o)
        {
            ListViewData data = (ListViewData)o;
            list.Add(data);
        }
        public void ClearAll()
        {
            list.Clear();
            Items.Clear();
        }
        public void ShowShortList()
        {
            Items.Clear();
            ListViewData[] l = list.FindAll(i => (i.Count > 0)).ToArray();
            ListViewItem[] items = new ListViewItem[l.Length];
            for (int i = 0; i < l.Length;i++)
            {
                items[i] = new ListViewItem(new string[] { l[i].Index.ToString(), l[i].Count.ToString() });
            }
            Items.AddRange(items);
        }

        public void ShowLongList()
        {
            Items.Clear();
            ListViewItem[] items = new ListViewItem[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                items[i] = new ListViewItem(new string[] { list[i].Index.ToString(), list[i].Count.ToString() });
            }
            Items.AddRange(items);
        }
    }
}

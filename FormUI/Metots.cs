using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI
{
    public static class Metots
    {
        public static void GetUsers(string url, List<string> list)
        {
            List<string> result = new List<string>();
            HtmlWeb web = new HtmlWeb();
            int i = 1;

            
                HtmlNode[] nodes;
                do
                {

                    int index = url.IndexOf('=') + 1;
                    string temp1 = url.Substring(0, index), tem2 = url.Substring(index + 1);
                    url = temp1 + i + tem2;
                    HtmlAgilityPack.HtmlDocument document = web.Load(url);
                    nodes = document.DocumentNode.SelectNodes("//a[@href]").Where(x => x.Attributes.Contains("data-octo-click")).ToArray();
                    foreach (HtmlNode item in nodes)
                    {

                        result.Add(@"https://github.com" + item.Attributes["href"].Value);
                    }
                    i++;
                }
                while (nodes.Count()!=0);
            
            
                foreach (var item in result.Distinct())
                {
                    list.Add(item);
                
                }
        }
        public static void GetFollowers(List<string> following, List<string> followers,ListBox listBox)
        {

            var result = following.Except(followers);
            AddToListBox(result,listBox);
            
        }
        public static void GetFollowing(List<string> following, List<string> followers, ListBox listBox)
        {

            var result = followers.Except(following);
            AddToListBox(result, listBox);

        }
        public static void AddToListBox(IEnumerable<string> result,ListBox listBox)
        {
            if (result.Count()==0)
            {
                listBox.Items.Add("Empty");
            }
            else
            {
                foreach (var item in result)
                {
                    listBox.Items.Add(item);
                }
            }
        }
    }
}

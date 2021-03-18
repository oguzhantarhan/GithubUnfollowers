using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            label2.Text = "Unfollowers:";
            string userName = textBox1.Text;
            string followersUrl = @"https://github.com/" + userName + @"?page=1&tab=followers";
            string followingUrl = @"https://github.com/" + userName + @"?page=1&tab=following";
            List<string> followers = new List<string>();
            List<string> following = new List<string>();
            Metots.GetUsers(followersUrl, followers);
            Metots.GetUsers(followingUrl, following);
            Metots.GetFollowers(following, followers,listBox1);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem!=null && listBox1.SelectedItem.ToString() !="Empty")
            {
                Process.Start(listBox1.SelectedItem.ToString());
                listBox1.SelectedItem = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            label2.Text = "Unfollowing:";
            string userName = textBox1.Text;
            string followersUrl = @"https://github.com/" + userName + @"?tab=followers";
            string followingUrl = @"https://github.com/" + userName + @"?tab=following";
            List<string> followers = new List<string>();
            List<string> following = new List<string>();
            Metots.GetUsers(followersUrl, followers);
            Metots.GetUsers(followingUrl, following);
            Metots.GetFollowing(following, followers, listBox1);
        }
    }
}

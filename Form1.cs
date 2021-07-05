using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VkNet;
using VkNet.Model;
using VkNet.Model.RequestParams;
using System.IO;
      //07cf15fc88748b2489ad21776fa4b4a384e01eaaab9420031dd84017ae8f22b431c0ca8783f2b2936671a

namespace sdfg
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }
        public static string getAuthForGroup()
        {
            string fileName = @"роп.txt";
            string token = "";
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    token = sr.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return token;
        }
        public static string getAuthForUser()
        {
            string fileName = @"роп.txt";
            string token = "";
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    sr.ReadLine();
                    token = sr.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return token;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            var api_group = new VkApi();
            api_group.Authorize(new ApiAuthParams
            {
                AccessToken = "9b9f96763cb2e007b127a1861281a71099ea99906c66fecfa3af58a08aeb0cc32df70e63b46b782a146b4"
            });
            if (radioButton1.Checked)
            {
                var getFollowers = api_group.Groups.GetMembers(new GroupsGetMembersParams()
                {
                    GroupId = textBox2.Text,
                    Fields = VkNet.Enums.Filters.UsersFields.All,
                    Count = 5
                });

                foreach (User user in getFollowers)
                {
                    byte[] bytes = Encoding.Default.GetBytes(user.FirstName + " " + user.LastName + " ");
                    textBox3.Text += Encoding.UTF8.GetString(bytes);
                    if (checkBox1.Checked && user.Status != null)
                    {
                        byte[] bytes1 = Encoding.Default.GetBytes(user.Status);
                        textBox3.Text += Encoding.UTF8.GetString(bytes1);
                        textBox3.Text += " ";
                    }
                    if (checkBox2.Checked && user.Online != null)
                    {
                        if (Convert.ToBoolean(user.Online))
                            textBox3.Text += "онлайн ";
                        else
                            textBox3.Text += "не онлайн ";
                    }

                    if (checkBox3.Checked && user.BirthDate != null)
                    {
                        byte[] bytes1 = Encoding.Default.GetBytes(user.BirthDate);
                        textBox3.Text += " ";
                        textBox3.Text += Encoding.UTF8.GetString(bytes1);
                    }
                    textBox3.Text += Environment.NewLine;
                }
            }
            if (radioButton2.Checked)
            {
                var users = api_group.Friends.Get(new VkNet.Model.RequestParams.FriendsGetParams
                {
                    UserId = Convert.ToInt32(textBox1.Text),
                    Count = 5,
                    Fields = VkNet.Enums.Filters.ProfileFields.All,
                });
                foreach (var user in users)
                {
                    byte[] bytes = Encoding.Default.GetBytes(user.FirstName + " " + user.LastName + " ");
                    textBox3.Text += Encoding.UTF8.GetString(bytes);
                    if (checkBox1.Checked && user.Status != null)
                    {
                        byte[] bytes1 = Encoding.Default.GetBytes(user.Status);
                        textBox3.Text += Encoding.UTF8.GetString(bytes1);
                        textBox3.Text += " ";
                    }
                    if (checkBox2.Checked && user.Online != null)
                    {
                        if (Convert.ToBoolean(user.Online))
                            textBox3.Text += "онлайн ";
                        else
                            textBox3.Text += "не онлайн ";
                    }

                    if (checkBox3.Checked && user.BirthDate != null)
                    {
                        byte[] bytes1 = Encoding.Default.GetBytes(user.BirthDate);
                        textBox3.Text += " ";
                        textBox3.Text += Encoding.UTF8.GetString(bytes1);
                    }
                    textBox3.Text += Environment.NewLine;
                
            }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

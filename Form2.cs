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
using System.Globalization;

namespace sdfg
{
    public partial class Form2 : Form
    {
        public Form2()
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
        private void Form2_Load(object sender, EventArgs e)
        {
            int count = 0;
            int sum = 0;
            var api_group = new VkApi();
            api_group.Authorize(new ApiAuthParams
            {
                AccessToken = getAuthForGroup()
            });
            var users = api_group.Friends.Get(new VkNet.Model.RequestParams.FriendsGetParams
            {
                UserId = Convert.ToInt32(157808008),
                Fields = VkNet.Enums.Filters.ProfileFields.All,
            });
            DateTime today = DateTime.Now;
            foreach (var item in users)
            {
                string[] tokens = item.BirthDate.Split('.');
                if (tokens.Length == 2)
                {
                    DateTime dt = DateTime.ParseExact(item.BirthDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    count++;
                    sum += Convert.ToInt32(today - dt);
                }
            }
            MessageBox.Show(Convert.ToString(sum / count));
        }
    }
}

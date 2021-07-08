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

namespace sdfg
{
    public partial class API : Form
    {
        public API()
        {
            InitializeComponent();
        }

        private void API_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            long postId = 0;
            var api_group = new VkApi();
            var api = new VkApi();
            api_group.Authorize(new ApiAuthParams
            {
                AccessToken = "6fbf2f2cc67693ac29d54fa6dc4b088c98fe6374e884622b2d60f1f1abafef0eea5a5f82772222decaf31"
            });
            api.Authorize(new ApiAuthParams
            {
                AccessToken = "3426266c8ccecd7db73989eefd5b07b4b076cff689ec23f7734167b3235eeecbc5e496ae722300a8e1f60"
            });

            var postList = api.Wall.Get(new WallGetParams
            {
                OwnerId = Convert.ToInt32(textBox1.Text),
                Count = 1
            });
            foreach (var item in postList.WallPosts)
            {

                var post = api_group.Wall.Post(new WallPostParams
                {
                    OwnerId = -203845470,
                    Message = Encoding.UTF8.GetString(Encoding.Default.GetBytes(item.Text)),
                });
                label4.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(item.Text));
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

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
            long postId = 0;
            var api_group = new VkApi();
            var api = new VkApi();
            api_group.Authorize(new ApiAuthParams
            {
                AccessToken = "6fbf2f2cc67693ac29d54fa6dc4b088c98fe6374e884622b2d60f1f1abafef0eea5a5f82772222decaf31"
            });
            api.Authorize(new ApiAuthParams
            {
                AccessToken = "9004100f2f62f4eb4e12b5e59aa77a76c07e0aad724512fd261082a5d608d05586a63210e69090b2ec1b7"
            });

            var postList = api.Wall.Get(new WallGetParams
            {
                OwnerId = 157808008,
                Count = 1
            }) ;
            foreach (var item in postList.WallPosts)
            {
                
                var post = api_group.Wall.Post(new WallPostParams
                {
                    OwnerId = -203845470,
                    Message = Encoding.UTF8.GetString(Encoding.Default.GetBytes(item.Text)),
                }) ;
            }
            

        }
    }
}

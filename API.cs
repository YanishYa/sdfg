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
            api_group.Authorize(new ApiAuthParams
            {
                AccessToken = "5fa3ac6c82a5b3f41691a583e1434885cba0fa004248c31d8bdaad1983c98cd75e21113db10e2f51ab460"
            });
            var postList = api_group.Wall.Get(new WallGetParams
            {
                OwnerId = -157808008,
                Count = 1
            }) ;
            foreach (var item in postList.WallPosts)
            {
                postId = Convert.ToInt64(item.Id);
                //var repost = api_group.Wall.Repost(object: item.Id.ToString);
            }
            

        }
    }
}

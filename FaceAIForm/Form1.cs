using Baidu.Aip.Face;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceAIForm
{
    public partial class Form1 : Form
    {
        public string APP_ID { get; set; }
        public string API_KEY { get; set; }
        public string SECRET_KEY { get; set; }
        public Face client { get; set; }
        public string Url { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Title = "请选择文件夹";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Url = dialog.FileName;
                pictureBox1.Load(Url);
            }
        }
        public PersonFace DetectDemo()
        {
            var image = File.ReadAllBytes(Url);
            // 调用人脸检测，可能会抛出网络等异常，请使用try/catch捕获
            var result = client.Detect(image);
            Console.WriteLine(result);
            // 如果有可选参数
            var options = new Dictionary<string, object> { { "max_face_num", 2 }, { "face_fields", "age,beauty,expression,faceshape,gender,glasses,landmark,race,qualities" } };
            // 带参数调用人脸检测
            result = client.Detect(image, options);

            return JsonConvert.DeserializeObject<PersonFace>(result.ToString());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var s = DetectDemo();
            var resultlst = new List<string>();
            s.result.ToList().ForEach(m =>
            {
                var props = m.GetType().GetProperties();
                var result = props.Select(n =>
                {
                    var chname = (DescriptionAttribute)Attribute.GetCustomAttribute(n, typeof(DescriptionAttribute));
                    var value = n.GetValue(m, null);
                    return $"{chname.Description}:{value}";
                });
                resultlst.AddRange(result);
            });
            


            richTextBox1.Text = string.Join("\r\n", resultlst);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            APP_ID = "10865107";
            API_KEY = "kjeLMRpVsWWzCEyYlNGRNXwr";
            SECRET_KEY = "VyimkxRUadQgaSLWXvUUFw8V7evQ8Ww7 ";
            client = new Face(API_KEY, SECRET_KEY);
        }
    }
}

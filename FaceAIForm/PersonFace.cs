using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceAIForm
{

    public class PersonFace
    {
        public PersonFace()
        {
            result = new List<Result>();
        }
        [Description("人脸数目")]
        public decimal result_num { get; set; }
        //人脸属性对象的集合
        [Description("人脸属性对象的集合")]
        public List<Result> result { get; set; }
        [Description("日志id")]
        public long log_id { get; set; }
    }

    public class Result
    {
        public Result()
        {
            landmark = new List<Landmark>();
            landmark72 = new List<Landmark72>();
            faceshape = new List<FaceShape>();
        }
        [Description("人脸在图片中的位置")]
        public Location location { get; set; }
        [Description("人脸置信度，范围0-1")]
        public decimal face_probability { get; set; }
        [Description("人脸框相对于竖直方向的顺时针旋转角，[-180,180]")]
        public decimal rotation_angle { get; set; }
        [Description("三维旋转之左右旋转角[-90(左), 90(右)]")]
        public decimal yaw { get; set; }
        [Description("三维旋转之俯仰角度[-90(上), 90(下)]")]
        public decimal pitch { get; set; }
        [Description("平面内旋转角[-180(逆时针), 180(顺时针)]")]
        public decimal roll { get; set; }
        [Description("4个关键点位置，左眼中心、右眼中心、鼻尖、嘴中心。face_fields包含landmark时返回]")]
        public List<Landmark> landmark { get; set; }
        [Description("72个特征点位置，示例图 。face_fields包含landmark时返回")]
        public List<Landmark72> landmark72 { get; set; }
        [Description("年龄")]
        public decimal age { get; set; }
        [Description("颜值")]
        public decimal beauty { get; set; }
        [Description("表情，0，不笑；1，微笑；2，大笑。face_fields包含expression时返回")]
        public decimal expression { get; set; }
        [Description("表情置信度，范围0~1。face_fields包含expression时返回")]
        public decimal expression_probablity { get; set; }
        [Description("male、female。face_fields包含gender时返回")]
        public string gender { get; set; }
        [Description("性别置信度，范围0~1。face_fields包含gender时返回")]
        public decimal gender_probability { get; set; }
        [Description("是否带眼镜，0-无眼镜，1-普通眼镜，2-墨镜。face_fields包含glasses时返回")]
        public decimal glasses { get; set; }
        [Description("眼镜置信度，范围0~1。face_fields包含glasses时返回")]
        public decimal glasses_probability { get; set; }
        [Description("yellow、white、black、arabs。face_fields包含race时返回")]
        public string race { get; set; }
        [Description("人种置信度，范围0~1。face_fields包含race时返回")]
        public decimal race_probability { get; set; }
        [Description("人脸质量信息。face_fields包含qualities时返回")]
        public Qualities qualities { get; set; }
        [Description("脸型置信度。face_fields包含faceshape时返回")]
        public List<FaceShape> faceshape { get; set; }
    }
    public class FaceShape
    {
        [Description("脸型：square/triangle/oval/heart/round")]
        public string type { get; set; }
        [Description("置信度：0~1")]
        public decimal probability { get; set; }
    }
    public class Location
    {
        [Description("人脸区域离左边界的距离")]
        public decimal left { get; set; }
        [Description("人脸区域离上边界的距离")]
        public decimal top { get; set; }
        [Description("人脸区域的宽度")]
        public decimal width { get; set; }
        [Description("人脸区域的高度")]
        public decimal height { get; set; }
    }

    public class Qualities
    {
        [Description("人脸各部分遮挡的概率,[0, 1],0表示完整，1表示不完整")]
        public Occlusion occlusion { get; set; }
        [Description("人脸模糊程度，[0, 1]。0表示清晰，1表示模糊")]
        public decimal blur { get; set; }
        [Description("取值范围在[0,255],表示脸部区域的光照程度")]
        public decimal illumination { get; set; }
        [Description("人脸完整度，[0, 1]。0表示完整，1表示不完整")]
        public decimal completeness { get; set; }
        [Description("真实人脸/卡通人脸置信度")]
        public Type type { get; set; }
    }

    public class Occlusion
    {
        [Description("左眼")]
        public decimal left_eye { get; set; }
        [Description("右眼")]
        public decimal right_eye { get; set; }
        [Description("鼻子")]
        public decimal nose { get; set; }
        [Description("嘴")]
        public decimal mouth { get; set; }
        [Description("左脸颊")]
        public decimal left_cheek { get; set; }
        [Description("右脸颊")]
        public decimal right_cheek { get; set; }
        [Description("下巴")]
        public decimal chin { get; set; }
    }

    public class Type
    {
        [Description("真实人脸置信度，[0, 1]")]
        public decimal human { get; set; }
        [Description("卡通人脸置信度，[0, 1]")]
        public decimal cartoon { get; set; }
    }

    public class Landmark
    {
        [Description("x坐标")]
        public decimal x { get; set; }
        [Description("y坐标")]
        public decimal y { get; set; }
    }

    public class Landmark72
    {
        [Description("x坐标")]
        public decimal x { get; set; }
        [Description("y坐标")]
        public decimal y { get; set; }
    }

}

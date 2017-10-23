using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BaiDu.Entities
{
    /// <summary>
    /// 人脸识别信息结果集实体
    /// </summary>
    public class FaceDetectInfo
    {
        #region 属性
        /// <summary>
        /// 人脸数目
        /// </summary>
        [JsonProperty(PropertyName = "result_num")]
        public int ResultNum { set; get; }

        /// <summary>
        /// 人脸属性对象的集合
        /// </summary>
        [JsonProperty(PropertyName = "result")]
        public FaceDetectResultInfo[] Result { set; get; }

        /// <summary>
        /// 日志id
        /// </summary>
        [JsonProperty(PropertyName = "log_id")]
        public long LogId { set; get; }
        #endregion

        #region 独立使用类  定义为内部类
        /// <summary>
        /// 人脸识别信息结果
        /// </summary>
        public class FaceDetectResultInfo
        {
            /// <summary>
            /// 年龄。face_fields包含age时返回
            /// </summary>
            [JsonProperty(PropertyName = "age")]
            public decimal Age { set; get; }

            /// <summary>
            /// 美丑打分，范围0-1，越大表示越美。face_fields包含beauty时返回
            /// </summary>
            [JsonProperty(PropertyName = "beauty")]
            public decimal Beauty { set; get; }

            /// <summary>
            /// 人脸在图片中的位置
            /// </summary>
            [JsonProperty(PropertyName = "location")]
            public Location Location { set; get; }


            /// <summary>
            /// 人脸置信度，范围0-1
            /// </summary>
            [JsonProperty(PropertyName = "face_probability")]
            public decimal FaceProbability { set; get; }

            /// <summary>
            /// 人脸框相对于竖直方向的顺时针旋转角，[-180,180]
            /// </summary>
            [JsonProperty(PropertyName = "rotation_angle")]
            public decimal RotationAngle { set; get; }

            /// <summary>
            /// 三维旋转之左右旋转角[-90(左), 90(右)]
            /// </summary>
            [JsonProperty(PropertyName = "yaw")]
            public decimal Yaw { set; get; }

            /// <summary>
            /// 三维旋转之俯仰角度[-90(上), 90(下)]
            /// </summary>
            [JsonProperty(PropertyName = "pitch")]
            public decimal Pitch { set; get; }

            /// <summary>
            /// 平面内旋转角[-180(逆时针), 180(顺时针)]
            /// </summary>
            [JsonProperty(PropertyName = "roll")]
            public decimal Roll { set; get; }

            /// <summary>
            /// 表情，0，不笑；1，微笑；2，大笑。face_fields包含expression时返回
            /// </summary>
            [JsonProperty(PropertyName = "expression")]
            public decimal Expression { set; get; }

            /// <summary>
            /// 表情置信度，范围0~1。face_fields包含expression时返回
            /// </summary>
            [JsonProperty(PropertyName = "expression_probability")]
            public decimal ExpressionProbability { set; get; }

            /// <summary>
            /// 脸型置信度。face_fields包含faceshape时返回
            /// </summary>
            [JsonProperty(PropertyName = "faceshape")]
            public FaceShape[] Faceshape { set; get; }

            /// <summary>
            /// 性别，male、female。face_fields包含gender时返回
            /// </summary>
            [JsonProperty(PropertyName = "gender")]
            public string Gender { set; get; }

            /// <summary>
            /// 性别置信度，范围0~1。face_fields包含gender时返回
            /// </summary>
            [JsonProperty(PropertyName = "gender_probability")]
            public decimal GenderProbability { set; get; }

            /// <summary>
            /// 是否带眼镜，0-无眼镜，1-普通眼镜，2-墨镜。face_fields包含glasses时返回
            /// </summary>
            [JsonProperty(PropertyName = "glasses")]
            public decimal Glasses { set; get; }

            /// <summary>
            /// 眼镜置信度，范围0~1。face_fields包含glasses时返回
            /// </summary>
            [JsonProperty(PropertyName = "glasses_probability")]
            public decimal GlassesProbability { set; get; }

            /// <summary>
            /// 4个关键点位置，左眼中心、右眼中心、鼻尖、嘴中心。face_fields包含landmark时返回
            /// </summary>
            [JsonProperty(PropertyName = "landmark")]
            public LandMark[] Landmark { set; get; }

            /// <summary>
            /// 72个特征点位置，示例图 。face_fields包含landmark时返回
            /// </summary>
            [JsonProperty(PropertyName = "landmark72")]
            public LandMark[] Landmark72 { set; get; }

            /// <summary>
            /// 人种，yellow、white、black、arabs。face_fields包含race时返回
            /// </summary>
            [JsonProperty(PropertyName = "race")]
            public string Race { set; get; }

            /// <summary>
            /// 人种置信度，范围0~1。face_fields包含race时返回
            /// </summary>
            [JsonProperty(PropertyName = "race_probability")]
            public decimal RaceProbability { set; get; }

            /// <summary>
            /// 人脸质量信息。face_fields包含qualities时返回
            /// </summary>
            [JsonProperty(PropertyName = "qualities")]
            public Qualities Qualities { set; get; }
        }


        /// <summary>
        /// 人脸在图片中的位置
        /// </summary>
        public class Location
        {
            /// <summary>
            /// 人脸区域离左边界的距离
            /// </summary>
            [JsonProperty(PropertyName = "left")]
            public decimal Left { set; get; }

            /// <summary>
            /// 人脸区域离上边界的距离
            /// </summary>
            [JsonProperty(PropertyName = "top")]
            public decimal Top { set; get; }

            /// <summary>
            /// 人脸区域的宽度
            /// </summary>
            [JsonProperty(PropertyName = "width")]
            public decimal Width { set; get; }

            /// <summary>
            /// 人脸区域的高度
            /// </summary>
            [JsonProperty(PropertyName = "height")]
            public decimal Height { set; get; }
        }

        /// <summary>
        /// 特征点信息
        /// </summary>
        public class LandMark
        {
            /// <summary>
            /// x坐标
            /// </summary>
            [JsonProperty(PropertyName = "x")]
            public decimal X { set; get; }
            /// <summary>
            /// y坐标
            /// </summary>
            [JsonProperty(PropertyName = "y")]
            public decimal Y { set; get; }
        }

        /// <summary>
        /// 脸型置信度
        /// </summary>
        public class FaceShape
        {
            /// <summary>
            /// 脸型：square/triangle/oval/heart/round
            /// </summary>
            [JsonProperty(PropertyName = "type")]
            public string Type { set; get; }
            /// <summary>
            /// 置信度：0~1
            /// </summary>
            [JsonProperty(PropertyName = "probability")]
            public decimal probability { set; get; }
        }

        /// <summary>
        /// 人脸质量信息
        /// </summary>
        public class Qualities
        {
            /// <summary>
            /// 人脸各部分遮挡的概率， [0, 1] 
            /// </summary>
            [JsonProperty(PropertyName = "occlusion")]
            public QualitiesOcclusion Occlusion { set; get; }

            /// <summary>
            /// 人脸模糊程度，[0, 1]。0表示清晰，1表示模糊
            /// </summary>
            [JsonProperty(PropertyName = "blur")]
            public decimal Blur { set; get; }

            /// <summary>
            /// 脸部区域的光照程度，取值范围在[0,255]
            /// </summary>
            [JsonProperty(PropertyName = "illumination")]
            public decimal Illumination { set; get; }

            /// <summary>
            /// 人脸完整度，[0, 1]。0表示完整，1表示不完整
            /// </summary>
            [JsonProperty(PropertyName = "completeness")]
            public decimal Completeness { set; get; }

            /// <summary>
            /// 真实人脸/卡通人脸置信度
            /// </summary>
            [JsonProperty(PropertyName = "type")]
            public QualitiesType Type { set; get; }
        }
        /// <summary>
        /// 人脸各部分遮挡的概率， [0, 1] 
        /// </summary>

        public class QualitiesOcclusion
        {
            /// <summary>
            /// 左眼
            /// </summary>
            [JsonProperty(PropertyName = "left_eye")]
            public decimal LeftEye { set; get; }

            /// <summary>
            /// 右眼
            /// </summary>
            [JsonProperty(PropertyName = "right_eye")]
            public decimal RightEye { set; get; }

            /// <summary>
            /// 鼻子
            /// </summary>
            [JsonProperty(PropertyName = "nose")]
            public decimal Nose { set; get; }

            /// <summary>
            /// 嘴
            /// </summary>
            [JsonProperty(PropertyName = "mouth")]
            public decimal Mouth { set; get; }

            /// <summary>
            /// 左脸颊
            /// </summary>
            [JsonProperty(PropertyName = "left_cheek")]
            public decimal LeftCheek { set; get; }

            /// <summary>
            /// 右脸颊
            /// </summary>
            [JsonProperty(PropertyName = "right_cheek")]
            public decimal RightCheek { set; get; }

            /// <summary>
            /// 下巴
            /// </summary>
            [JsonProperty(PropertyName = "chin")]
            public decimal Chin { set; get; }
        }

        /// <summary>
        /// 真实人脸/卡通人脸置信度
        /// </summary>

        public class QualitiesType
        {
            /// <summary>
            /// 真实人脸置信度，[0, 1]
            /// </summary>
            [JsonProperty(PropertyName = "human")]
            public decimal Human { set; get; }

            /// <summary>
            /// 卡通人脸置信度，[0, 1]
            /// </summary>
            [JsonProperty(PropertyName = "cartoon")]
            public decimal Cartoon { set; get; }
        }
        #endregion

    }
}

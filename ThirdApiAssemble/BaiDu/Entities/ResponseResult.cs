using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiDu.Entities
{
    /// <summary>
    /// 百度AI接口基类
    /// </summary>
    public class ResponseResult<T>
    {

        #region 通用
        /// <summary>
        /// 返回个数
        /// </summary>
        [JsonProperty(PropertyName = "result_num")]
        public int ResultNum { set; get; }

        /// <summary>
        /// T 列表
        /// </summary>
        [JsonProperty(PropertyName = "result")]
        public T[] Result { set; get; }

        /// <summary>
        /// 请求标识码，随机数，唯一
        /// </summary>
        [JsonProperty(PropertyName = "log_id")]
        public long LogId { set; get; }
        #endregion

        /// <summary>
        /// 对应参数中的ext_fields
        /// </summary>
        [JsonProperty(PropertyName = "ext_info")]
        public ExtInfo ExtInfo { set; get; }

        #region 错误码相关
        /// <summary>
        /// 错误码
        /// </summary>
        [JsonProperty(PropertyName = "error_code")]
        public int ErrorCode { set; get; }

        /// <summary>
        /// 错误描述信息，帮助理解和解决发生的错误
        /// </summary>
        [JsonProperty(PropertyName = "error_msg")]
        public string ErrorMsg { set; get; } 
        #endregion
    }

    public class ExtInfo {
        /// <summary>
        /// 活体分数，如0.49999。单帧活体检测参考阈值0.834963，超过此分值以上则可认为是活体。注意：活体检测接口主要用于判断是否为二次翻拍，需要限制用户为当场拍照获取图片；推荐配合客户端SDK有动作校验活体使用
        /// </summary>
        [JsonProperty(PropertyName = "faceliveness")]
        public string Faceliveness { set; get; }
    }
}

namespace THD.Web.Mvc.Filters
{
    public class AjaxResponse<T> : AjaxResponse
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        public new T Data { get; set; }
    }

    public class AjaxResponse : IAjaxResponse
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// code
        /// </summary>
        public string Code { get; set; }

        public static AjaxResponse Failed(string message = null, string code = null)
        {
            return Failed(null, message, code);
        }

        /// <summary>
        /// 返回未成功的api结果
        /// </summary>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static AjaxResponse Failed(object data, string message = null, string code = null)
        {
            return new AjaxResponse
            {
                Success = false,
                Code = code,
                Data = data,
                Message = message
            };
        }

        /// <summary>
        /// 返回不包含结果的成功api结果
        /// </summary>
        /// <returns></returns>
        public static AjaxResponse Succeed(string message = null, string code = null)
        {
            return Succeed(null, message, code);
        }

        /// <summary>
        /// 返回成功的api结果
        /// </summary>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static AjaxResponse Succeed(object data, string message = null, string code = null)
        {
            return new AjaxResponse
            {
                Success = true,
                Code = code,
                Data = data,
                Message = message
            };
        }
    }
}

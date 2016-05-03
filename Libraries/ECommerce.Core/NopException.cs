using System;
using System.Runtime.Serialization;

namespace ECommerce.Core
{
    /// <summary>
    /// 表示在应用程序执行期间发生的错误
    /// </summary>
    [Serializable]
    public class NopException : Exception
    {
        /// <summary>
        /// 初始化的异常类的一个新实例。
        /// </summary>
        public NopException()
        {
        }

        /// <summary>
        /// 使用指定的错误信息初始化异常类的一个新实例。
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public NopException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// 使用指定的错误信息初始化异常类的一个新实例。
        /// </summary>
        /// <param name="messageFormat">The exception message format.</param>
        /// <param name="args">The exception message arguments.</param>
        public NopException(string messageFormat, params object[] args)
            : base(string.Format(messageFormat, args))
        {
        }

        /// <summary>
        /// 使用序列化数据的异常类的一个新实例。
        /// </summary>
        /// <param name="info">The SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The StreamingContext that contains contextual information about the source or destination.</param>
        protected NopException(SerializationInfo
            info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// 使用指定的错误信息和参考，是此异常原因的内部异常初始化异常类的一个新实例。
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public NopException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
